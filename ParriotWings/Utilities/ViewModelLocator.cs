using System;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using ParriotWings.ViewModels;

namespace ParriotWings.Utilities
{
    public class ViewModelLocator
    {
        // Services registration
        public static void RegisterServices(ContainerBuilder registrations = null, bool registerFakes = false)
        {
            var builder = new ContainerBuilder();

            // Cross-platform module registration
            builder.RegisterModule<CrossPlatformModule>();

            // View model registration
            builder.RegisterType<MainViewModel>();

            // Sign
            builder.RegisterType<SignInViewModel>();
            builder.RegisterType<SignUpViewModel>();

            //Transactions
            builder.RegisterType<TransactionsViewModel>();
            builder.RegisterType<NewTransactionViewModel>().SingleInstance();

            var container = builder.Build();

            registrations?.Update(container);

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
        }

    }
}
