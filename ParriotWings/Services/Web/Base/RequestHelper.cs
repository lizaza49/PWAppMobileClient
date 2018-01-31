using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;
using ParriotWings.Helpers;
using ParriotWings.Services.Web.Abstract;

namespace ParriotWings.Services.Web.Base
{
    public class RequestHelper : IRequestHelper
    {
        private readonly NativeMessageHandler requestHandler;

        public RequestHelper()
        {
            this.requestHandler = new NativeMessageHandler();
        }
        private HttpClient GetClient(String authToken = null)
        {
            var client = new HttpClient(requestHandler)
            {
                Timeout = new TimeSpan(0, 1, 0)
            };

            client.BaseAddress = new Uri(Constants.BaseUrl);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(authToken)) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            return client;
        }

        private System.Net.Http.HttpMethod MapMethod(HttpMethod method)
        {
            switch (method)
            {
                case HttpMethod.Get:
                    return System.Net.Http.HttpMethod.Get;
                case HttpMethod.Post:
                    return System.Net.Http.HttpMethod.Post;
                case HttpMethod.Delete:
                    return System.Net.Http.HttpMethod.Delete;
                case HttpMethod.Put:
                    return System.Net.Http.HttpMethod.Put;
            }
            return System.Net.Http.HttpMethod.Get;
        }

        public virtual async Task<Result<TResponce>> SendRequest<TResponce>(Request request) where TResponce : class
        {
            var auth = request.GetAuth();
            HttpClient client = null;
            try
            {
                String token = string.Empty;
                if (auth.TryGetValue("Token", out string value))
                {
                    token = value;
                }
                client = GetClient(token);
            }
            catch
            {
                return new ErrorResult<TResponce>(new Error() { Message = "server unknown for {request.Uri}", Code = Error.CodeServerUnknown });
            }
            var parameters = request.GetParams();
            var method = MapMethod(request.Method);
            AddAuthHeader(client, request);
            var url = BuildUrl(request.Method, request.Uri, parameters, request.Inner);

            var content = GetContent(request, parameters);

            try
            {
                var response = await SendRequestExt<TResponce>(client, method, url, content, request.JsonConverters);
                if (response == null)
                {
                    return Result<TResponce>.Create(new Error
                    {
                        Message = "null"
                    });
                }
                var result = Result<TResponce>.Create(response);
                return result;
            }
            catch (WebException)
            {
                return Result<TResponce>.Create(new Error
                {
                    Message = LocalizedStrings.ConnectionError
                });
            }
            catch (HttpResponseExceptionCustom ex)
            {
                return Result<TResponce>.Create(new Error
                {
                    Message = ex.ExMessage,
                    Code = ex.Code
                });
            }
            catch (Exception ex)
            {
                return Result<TResponce>.Create(new Error
                {
                    Message = ex.Message
                });
            }
        }

        void AddAuthHeader(HttpClient client, Request request)
        {
            if (request.IsSecure)
            {
                var headers = request.GetAuth();
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
        }

        private string BuildUrl(HttpMethod method, string baseUrl, Dictionary<string, object> parameters, bool inner)
        {
            //var fullUrl = (inner) ? GetServerUrl(messenger) + baseUrl : baseUrl;
            var fullUrl = baseUrl;
            if (method == HttpMethod.Post)
            {
                return fullUrl;
            }
            if (parameters != null && parameters.Count > 0)
            {
                return string.Format("{0}?{1}",
                    fullUrl,
                                     string.Join("&", parameters.Select(kv => string.Format(CultureInfo.InvariantCulture, "{0}={1}", kv.Key, WebUtility.UrlEncode((string)kv.Value)))
                    )
                );
            }
            return fullUrl;
        }

        private HttpContent GetContent(Request request, Dictionary<string, object> parameters)
        {
            if (request.Method == HttpMethod.Get)
            {
                return null;
            }

            return GetJsonContent(parameters);
        }

        private StringContent GetJsonContent(Dictionary<string, object> parameters)
        {
            var body = JsonConvert.SerializeObject(parameters);
            return new StringContent(body, Encoding.UTF8, "application/json");
        }

        private async Task<TResponce> SendRequestExt<TResponce>(HttpClient client, System.Net.Http.HttpMethod method, string url, HttpContent content, List<JsonConverter> jsonConverters)
        {
            using (var message = new HttpRequestMessage(method, url) { Content = content })
            using (var response = await client.SendAsync(message))
            {
                EnsureSuccessStatusCodeCustom(response);
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TResponce>(body, jsonConverters.ToArray());
                return result;
            }
        }

        private void EnsureSuccessStatusCodeCustom(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return;

            var content = response.Content.ReadAsStringAsync().Result;

            response.Content?.Dispose();

            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    switch (content)
                    {
                        case "user not found":
                            throw new HttpResponseExceptionCustom(LocalizedStrings.UserNotFound, Error.CodeUserNotFound);
                        case "A user with that email exists":
                            throw new HttpResponseExceptionCustom(LocalizedStrings.UserExists, Error.CodeUserExists);
                        case "Invalid username.":
                            throw new HttpResponseExceptionCustom(LocalizedStrings.InvalidUser, Error.CodeInvalidUser);
                        case "Balance exceeded. Transaction is impossible":
                            throw new HttpResponseExceptionCustom(LocalizedStrings.BalanceExceeded, Error.CodeBalanceExceeded);
                        case "You must send username and password":
                            throw new HttpResponseExceptionCustom(LocalizedStrings.EmptyUsernameOrPassword, Error.CodeEmptyUsernameOrPassword);
                        case "You must send email and password.":
                            throw new HttpResponseExceptionCustom(LocalizedStrings.EmptyEmailOrPassword, Error.CodeEmptyEmailOrPassword);
                        default:
                            throw new HttpResponseExceptionCustom(response.StatusCode, content);
                    }
                case HttpStatusCode.Unauthorized:
                    switch (content)
                    {
                        case "Invalid email or password.":
                            throw new HttpResponseExceptionCustom(LocalizedStrings.InvalidEmailOrPassword, Error.CodeInvalidEmailOrPassword);
                        case "No search string":
                            throw new HttpResponseExceptionCustom(LocalizedStrings.EmptySearchString, Error.CodeEmptySearchString);
                        default:
                            throw new HttpResponseExceptionCustom(LocalizedStrings.UnauthorizedError, Error.CodeUnauthorizedError);
                    }
                default:
                    throw new HttpResponseExceptionCustom(response.StatusCode, content);
            }
        }
    }

    public class HttpResponseExceptionCustom : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public string Content { get; private set; }

        public string Code { get; private set; }

        public string ExMessage { get; private set; }

        public override string ToString()
        {
            return string.Format("[HttpResponseExceptionCustom: StatusCode={0}, Content={1}, Code={2}]", StatusCode, Content, Code);
        }

        public HttpResponseExceptionCustom(HttpStatusCode statusCode, string content)
            : base(
                statusCode + "(" + (int)statusCode + ")." +
                (string.IsNullOrEmpty(content) ? "No content returned" : "Returned: " + content))
        {
            StatusCode = statusCode;
            Content = content;

            string code = string.Empty;
            string msg = string.Empty;
            try
            {
                dynamic json = JsonConvert.DeserializeObject(Content);
                Code = json.status;
                ExMessage = json.message;
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("json error");
            }
        }

        public HttpResponseExceptionCustom(string message, string code)
            : base(message)
        {
            ExMessage = message;
            Code = code;
        }
    }
}
