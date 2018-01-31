using System;
using Newtonsoft.Json.Converters;

namespace ParriotWings.Helpers
{
    public class CustomDateTimeConverter: IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = "dd.MM.yyyy";
        }
    }
}
