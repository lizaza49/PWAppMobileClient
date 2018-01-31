using System;
using System.Collections.Generic;
using ParriotWings.Entities;

namespace ParriotWings.Helpers
{
    public static class Constants
    {
        public static string BaseUrl = "http://193.124.114.46:3001";

        public static List<LocaleEntity> Locales = new List<LocaleEntity>()
        {
            new LocaleEntity(){ Locale="en", LocaleName="English"},
            new LocaleEntity(){ Locale="ru", LocaleName="Russian"}
        };
    }
}
