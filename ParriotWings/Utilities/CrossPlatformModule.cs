using System;
using System.Collections.Generic;

using Autofac;
using ParriotWings.Managers;
using ParriotWings.Services.Web;
using ParriotWings.Services.Web.Base;
using ParriotWings.Services.Web.Mock;

namespace ParriotWings.Utilities
{
    public class CrossPlatformModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Type[] types =
            {
                typeof(RequestHelper),
                typeof(LocaleManager),
                typeof(AccountService),
                typeof(TransactionsService),
                //typeof(FakeAccountService),
                //typeof(FakeTransactionService),
                typeof(AccountManager),
                typeof(TransactionManager),
            };
            builder.RegisterTypes(types).AsImplementedInterfaces().SingleInstance();
        }
    }
}
