using System;
using ParriotWings.Managers.Abstract;
using ParriotWings.Services.Storage;
using I18NPortable;
using System.Reflection;
using ParriotWings.Services.Platformspecific;
using ParriotWings.Helpers;
using System.Collections.Generic;
using ParriotWings.Entities;
using System.Linq;

namespace ParriotWings.Managers
{
    public class LocaleManager : ILocaleManager
    {
        private readonly ILocalStorage localStorage;
        private readonly ILocaleService localeService;

        public LocaleManager(ILocalStorage localStorage, ILocaleService localeService)
        {
            this.localStorage = localStorage;
            this.localeService = localeService;
        }

        public string GetCurrentLocale()
        {
            var savedLocale = localStorage.GetStringValue("Locale");
            if (string.IsNullOrEmpty(savedLocale))
            {
                var systemLocale = localeService.GetSystemLocale();
                var splited = systemLocale?.Split('-');
                var lang = splited?[0];
                var systemValidatedLocale = Constants.Locales.Where(x => x.Locale == lang).SingleOrDefault()?.Locale;
                if (systemValidatedLocale == null) return FallbackLocale;
                else
                {
                    localStorage.SetStringValue("Locale", systemValidatedLocale);
                    return systemValidatedLocale;
                }
            }
            else return savedLocale;
        }

        private string FallbackLocale => Constants.Locales[0].Locale;

        public List<LocaleEntity> Locales => Constants.Locales;

        public void InitLocale()
        {
            I18N.Current.SetFallbackLocale(FallbackLocale)
                .Init(this.GetType().GetTypeInfo().Assembly);
            string currentLocale = GetCurrentLocale();
            if (!string.IsNullOrEmpty(currentLocale))
                I18N.Current.Locale = currentLocale;
        }

        public void SetLocale(string locale)
        {
            localStorage.SetStringValue("Locale", locale);
            I18N.Current.Locale = locale;
        }
    }
}
