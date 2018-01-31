using System;
using Newtonsoft.Json;

namespace ParriotWings.Entities
{
    public class Transaction
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "date")]
        public String Date { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public int? Amount { get; set; }

        [JsonProperty(PropertyName = "balance")]
        public int? Balance { get; set; }
    }
}
