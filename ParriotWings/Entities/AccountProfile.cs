using System;
using Newtonsoft.Json;

namespace ParriotWings.Entities
{
    public class AccountProfile : PWUser
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "balance")]
        public int? Balance { get; set; }

    }
}
