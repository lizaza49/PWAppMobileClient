using System;
using Autofac;
using ParriotWings.iOS.ViewControllers;
using ParriotWings.Navigation;

namespace ParriotWings.iOS.Utilities
{
    public class PlatformModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var nav = new IOSNavigationService();

            nav.Configure(new PageConfiguration() { Page = Page.SignInPage,  Type = typeof(SignInViewController), IsRoot = true });
            nav.Configure(new PageConfiguration() { Page = Page.SignUpPage, Type = typeof(SignUpViewController), IsRoot = false });
            nav.Configure(new PageConfiguration() { Page = Page.MainPage, Type = typeof(MainViewController), IsRoot = true, RequireAuth = true });
            nav.Configure(new PageConfiguration() { Page = Page.TransactionsPage, Type = typeof(TransactionsViewController), RequireAuth = true });
            nav.Configure(new PageConfiguration() { Page = Page.NewTransactionPage, Type = typeof(NewTransactionViewController), RequireAuth = true });
            nav.Configure(new PageConfiguration() { Page = Page.SelectUser, Type = typeof(SelectUserViewController), RequireAuth = true });

            builder.RegisterInstance(nav).AsImplementedInterfaces();

            Type[] types =
            {
                typeof(AppleLocalStorage),
                typeof(IOSDialogService),
                typeof(LocaleService)
            };

            builder.RegisterTypes(types).AsImplementedInterfaces();
        }
    }
}
