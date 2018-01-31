using System;
namespace ParriotWings.Services.Storage
{
    public interface ILocalStorage
    {
        string GetStringValue(string key);
        int GetIntValue(string key);
        bool GetBoolValue(string key);
        void SetStringValue(string key, string value);
        void SetIntValue(string key, int value);
        void SetBoolValue(string key, bool value);
    }
}
