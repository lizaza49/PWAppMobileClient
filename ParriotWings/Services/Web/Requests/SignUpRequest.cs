using System;
using System.Collections.Generic;
using ParriotWings.Helpers;
using ParriotWings.Services.Web.Base;

namespace ParriotWings.Services.Web.Requests
{
    public class SignUpRequest : Request
    {
        private readonly string email;
        private readonly string password;
        private readonly string username;

        public SignUpRequest(string email, string username, string password)
        {
            this.email = email;
            this.password = password;
            this.username = username;
        }

        public override bool IsSecure => false;

        public override HttpMethod Method => HttpMethod.Post;

        public override string Uri => "/users";

        public override Dictionary<string, object> GetParams()
        {
            var parameters = base.GetParams();
            parameters.Add("email", email);
            parameters.Add("password", password);
            parameters.Add("username", username);
            return parameters;
        }
    }
}
