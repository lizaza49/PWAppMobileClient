using System;
using Newtonsoft.Json;

namespace ParriotWings.Entities
{
    public class PWUser
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
