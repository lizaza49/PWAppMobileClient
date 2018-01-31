using System;
using System.Collections.Generic;
using ParriotWings.Services.Web.Base;

namespace ParriotWings.Services.Web.Requests
{
    public class GetPWUsersList: Request
    {
        private readonly string accessToken;
        private readonly string searchString;

        public GetPWUsersList(string searchString, string accessToken)
        {
            this.accessToken = accessToken;
            this.searchString = searchString;
        }

        public override bool IsSecure => true;

        public override HttpMethod Method => HttpMethod.Post;

        public override string Uri => "/api/protected/users/list";

        public override Dictionary<string, string> GetAuth()
        {
            var auth = base.GetAuth();
            auth.Add("Token", accessToken);
            return auth;
        }

        public override Dictionary<string, object> GetParams()
        {
            var parameters = base.GetParams();
            parameters.Add("filter", searchString);
            return parameters;
        }
    }
}
