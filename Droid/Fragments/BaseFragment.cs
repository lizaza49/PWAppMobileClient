using System.Collections.Generic;
using Android.App;
using Android.Views.InputMethods;
using GalaSoft.MvvmLight.Helpers;
using Plugin.CurrentActivity;

namespace ParriotWings.Droid.Fragments
{
    public class BaseFragment : Fragment
    {
        protected readonly List<Binding> Bindings = new List<Binding>();

        public BaseFragment()
        {
        }

        public override void OnDestroyView()
        {
            foreach (var binding in Bindings)
            {
                binding.Detach();
            }
            Bindings.Clear();
            HideKeyboard();
            base.OnDestroyView();
        }

        protected void HideKeyboard()
        {
            var imm = (InputMethodManager)CrossCurrentActivity.Current.Activity.GetSystemService(Android.Content.Context.InputMethodService);
            var wt = CrossCurrentActivity.Current.Activity?.CurrentFocus?.WindowToken;
            if (wt != null)
            {
                imm?.HideSoftInputFromWindow(wt, HideSoftInputFlags.NotAlways);
            }
        }
    }
}
