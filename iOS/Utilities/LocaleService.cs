using System;
using Foundation;
using ParriotWings.Services.Platformspecific;

namespace ParriotWings.iOS.Utilities
{
    public class LocaleService : ILocaleService
    {
        public string GetSystemLocale()
        {
            var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;
            var iosLanguageAuto = NSLocale.AutoUpdatingCurrentLocale.LanguageCode;
            var netLocale = iosLocaleAuto.Replace("_", "-");
            var netLanguage = iosLanguageAuto.Replace("_", "-");

            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                netLanguage = pref.Replace("_", "-");
                Console.WriteLine("preferred:" + netLanguage);
            }
            else
            {
                netLanguage = "en";
            }
            return netLanguage;
        }
    }
}
