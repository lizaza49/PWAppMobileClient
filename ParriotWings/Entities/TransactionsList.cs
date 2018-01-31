using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ParriotWings.Entities
{
    public class TransactionsList
    {
        [JsonProperty(PropertyName = "trans_token")]
        public List<Transaction> tokenList { get; set; }
    }
}
