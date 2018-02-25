using System;
using Microsoft.Practices.ServiceLocation;
using ParriotWings.ViewModels;

namespace ParriotWings.Droid.Fragments
{
    public class MainFragment: BaseFragment
    {
        private MainViewModel vm;
        public MainViewModel Vm => vm ?? (vm = ServiceLocator.Current.GetInstance<MainViewModel>());

        public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.main_fragment, container, false);
            return view;
        }

    }
}
