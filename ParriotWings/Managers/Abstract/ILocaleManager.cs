using System;
using System.Collections.Generic;
using ParriotWings.Entities;

namespace ParriotWings.Managers.Abstract
{
    public interface ILocaleManager
    {
        string GetCurrentLocale();
        void InitLocale();
        void SetLocale(string locale);
        List<LocaleEntity> Locales { get; }
    }
}
