using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Support.V4.Widget;
using ParriotWings.Droid.Utilities;
using ParriotWings.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace ParriotWings.Droid
{
    [Activity(Label = "@string/app_name", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class MainActivity : AppCompatActivity, Android.Support.V4.App.FragmentManager.IOnBackStackChangedListener, View.IOnClickListener
    {
        private MainViewModel vm;
        public MainViewModel Vm => vm ?? (vm = ServiceLocator.Current.GetInstance<MainViewModel>());

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Init toolbar
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.app_toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            // DI
            Bootstrap.RegisterServices(this, Resource.Id.main_content);


            // Init Vm
            Vm.InitLocale();
            Vm.OnLoadCommand.Execute(null);

            // Fragment manager
            SupportFragmentManager.AddOnBackStackChangedListener(this);
        }

        public void OnBackStackChanged()
        {
            //if (SupportFragmentManager.BackStackEntryCount > 0)
            //    SetDrawerState(false);
            //else
                //SetDrawerState(true);     
        }

        public void OnClick(View v)
        {
            OnBackPressed();
        }

    }
}

