using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ParriotWings.Entities
{
    public class AuthorizedUser
    {
        [DataMember]
        [JsonProperty(PropertyName = "id_token")]
        public string Token { get; set; }
    }
}
