using System;
using Newtonsoft.Json;
using ParriotWings.Helpers;

namespace ParriotWings.Entities
{
    public class TransactionToken
    {
        [JsonProperty(PropertyName = "trans_token")]
        public Transaction transaction { get; set; }
    }
}
