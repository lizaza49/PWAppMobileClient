using System;
using Newtonsoft.Json;

namespace ParriotWings.Entities
{
    public class UserInfoToken
    {
        [JsonProperty(PropertyName = "user_info_token")]
        public AccountProfile UserInfo{ get; set; }
    }
}
