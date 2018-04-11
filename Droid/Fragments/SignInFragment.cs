using System;
using Android.OS;
using Microsoft.Practices.ServiceLocation;
using ParriotWings.ViewModels;

namespace ParriotWings.Droid.Fragments
{
    public class SignInFragment: BaseFragment
    {
        private SignInViewModel vm;
        public SignInViewModel Vm => vm ?? (vm = ServiceLocator.Current.GetInstance<SignInViewModel>());

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
        }

        public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.sign_in_fragment, container, false);
            return view;
        }
    }
}
