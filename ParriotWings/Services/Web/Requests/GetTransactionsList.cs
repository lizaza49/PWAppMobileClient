using System;
using System.Collections.Generic;
using ParriotWings.Services.Web.Base;

namespace ParriotWings.Services.Web.Requests
{
    public class GetTransactionsList : Request
    {
        private readonly string accessToken;

        public GetTransactionsList(string accessToken)
        {
            this.accessToken = accessToken;
        }

        public override bool IsSecure => true;

        public override HttpMethod Method => HttpMethod.Get;

        public override string Uri => "/api/protected/transactions";

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
