using System;
using System.Collections.Generic;
using ParriotWings.Helpers;
using ParriotWings.Services.Web.Base;

namespace ParriotWings.Services.Web.Requests
{
    public class SignInRequest : Request
    {
        private readonly string email;
        private readonly string password;

        public SignInRequest(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public override bool IsSecure => false;

        public override HttpMethod Method => HttpMethod.Post;

        public override string Uri => "/sessions/create";

        public override Dictionary<string, object> GetParams()
        {
            var parameters = base.GetParams();
            parameters.Add("email", email);
            parameters.Add("password", password);
            return parameters;
        }
    }
}
