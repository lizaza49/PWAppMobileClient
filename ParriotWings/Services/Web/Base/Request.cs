using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ParriotWings.Services.Web.Base
{
    public abstract class Request
    {
        public List<JsonConverter> JsonConverters { get; } = new List<JsonConverter>();
        public abstract Boolean IsSecure { get; }
        public abstract HttpMethod Method { get; }
        public abstract String Uri { get; }
        public virtual bool Inner
        {
            get
            {
                return true;
            }
        }

        public virtual Dictionary<string, object> GetParams()
        {
            var dict = new Dictionary<string, object> { };
            return dict;
        }

        public virtual Dictionary<string, string> GetAuth()
        {
            var auth = new Dictionary<string, string> { };
            return auth;
        }
    }
}
