using System;
using System.Collections.Generic;
using ParriotWings.Services.Web.Base;

namespace ParriotWings.Services.Web.Requests
{
    public class CreateTransactionRequest : Request
    {
        private readonly string accessToken;
        private readonly string name;
        private readonly int amount;

        public CreateTransactionRequest(string name, int amount, string accessToken)
        {
            this.name = name;
            this.amount = amount;
            this.accessToken = accessToken;
        }

        public override bool IsSecure => true;

        public override HttpMethod Method => HttpMethod.Post;

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
            parameters.Add("name", name);
            parameters.Add("amount", amount);
            return parameters;
        }
    }
}
