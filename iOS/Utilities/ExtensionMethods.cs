using System;
using Foundation;
using UIKit;

namespace ParriotWings.iOS.Utilities
{
    public static class ExtensionMethods
    {
        public static string Localize(this string source)
        {
            var res = NSBundle.MainBundle.LocalizedString(source, "optional");
            return res;
        }

        static DateTime reference = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime ToDateTime(this NSDate date)
        {
            var utcDateTime = reference.AddSeconds(date.SecondsSinceReferenceDate);
            var dateTime = utcDateTime.ToLocalTime();
            return dateTime;
        }

        public static NSDate ToNSDate(this DateTime datetime)
        {
            var utcDateTime = datetime.ToUniversalTime();
            var date = NSDate.FromTimeIntervalSinceReferenceDate((utcDateTime - reference).TotalSeconds);
            return date;
        }

        public static bool Contains(this UINavigationController navController, UIViewController controller)
        {
            foreach (var item in navController.ViewControllers)
            {
                if (item == controller) return true;
            }
            return false;
        }
    }
}
