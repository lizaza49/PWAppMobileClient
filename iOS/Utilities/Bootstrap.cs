using System;
using Autofac;
using ParriotWings.Utilities;

namespace ParriotWings.iOS.Utilities
{
    public static class Bootstrap
    {
        public static void RegisterServices()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<PlatformModule>();

            ViewModelLocator.RegisterServices(builder);
        }
    }
}
