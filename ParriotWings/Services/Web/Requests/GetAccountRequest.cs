using System;
using System.Collections.Generic;
using ParriotWings.Services.Web.Base;

namespace ParriotWings.Services.Web.Requests
{
    public class GetAccountRequest : Request
    {
        private readonly string accessToken;

        public GetAccountRequest(string accessToken)
        {
            this.accessToken = accessToken;
        }

        public override bool IsSecure => true;

        public override HttpMethod Method => HttpMethod.Get;

        public override string Uri => "/api/protected/user-info";

        public override Dictionary<string, string> GetAuth()
        {
            var auth = base.GetAuth();
            auth.Add("Token", accessToken);
            return auth;
        }

        public override Dictionary<string, object> GetParams()
        {
            var parameters = base.GetParams();
            return parameters;
        }
    }
}
