using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ParriotWings.Helpers
{
    public static class Extensions
    {
        public static bool IsValidEmail(this string emailAddress)
        {
            string regexPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"; // ASP.NET
            Match matches = Regex.Match(emailAddress, regexPattern);
            return matches.Success;
        }

        public static void ShallowConvert<T, U>(this T parent, U child)
        {
            foreach (PropertyInfo property in parent.GetType().GetRuntimeProperties())
            {
                if (property.CanWrite)
                {
                    property.SetValue(child, property.GetValue(parent, null), null);
                }
            }
        }
    }
}
