using System;
using Autofac;

namespace ParriotWings.Droid.Utilities
{
    public class PlatformModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Type[] types =
            {
                    typeof(DroidLocalStorage),
                    typeof(ThreadSafeDroidDialogService),
                    typeof(LocaleService)
            };
            builder.RegisterTypes(types).AsImplementedInterfaces();
        }
    }
}
