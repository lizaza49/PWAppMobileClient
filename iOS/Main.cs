using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using ParriotWings.iOS.Utilities;
using ParriotWings.Utilities;
using UIKit;

namespace ParriotWings.iOS
{
    public class Application
    {
        private static ViewModelLocator locator;
        public static ViewModelLocator Locator => locator ?? (locator = new ViewModelLocator());

        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // DI
            Bootstrap.RegisterServices();
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
