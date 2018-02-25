using System;
using Android.Support.V7.App;
using Autofac;
using ParriotWings.Droid.Fragments;
using ParriotWings.Navigation;
using ParriotWings.Utilities;

namespace ParriotWings.Droid.Utilities
{
    public static class Bootstrap
    {
        private static ViewModelLocator locator;
        public static ViewModelLocator Locator => locator ?? (locator = new ViewModelLocator());

        public static void RegisterServices(AppCompatActivity activity, int container)
        {
            var builder = new ContainerBuilder();

            // Navigation service
            var nav = new DroidNavigationService();
            nav.Init(activity, container);

            //nav configure
            nav.Configure(new PageConfiguration() { Page = Page.SignInPage, Type = typeof(SignInFragment), IsRoot = true });
            nav.Configure(new PageConfiguration() { Page = Page.SignUpPage, Type = typeof(SignUpFragment), IsRoot = false });
            nav.Configure(new PageConfiguration() { Page = Page.MainPage, Type = typeof(MainFragment), IsRoot = true, RequireAuth = true });
            nav.Configure(new PageConfiguration() { Page = Page.TransactionsPage, Type = typeof(TransactionsFragment), RequireAuth = true });
            nav.Configure(new PageConfiguration() { Page = Page.NewTransactionPage, Type = typeof(NewTransactionFragment), RequireAuth = true });
            nav.Configure(new PageConfiguration() { Page = Page.SelectUser, Type = typeof(SelectUserFragment), RequireAuth = true });


            builder.RegisterInstance(nav).AsImplementedInterfaces();

            // Platform modules registration
            builder.RegisterModule<PlatformModule>();
            ViewModelLocator.RegisterServices(builder, false);
        }
    }
}
