using System;
using Android.App;
using Android.Content;
using Android.Support.V7.App;

namespace ParriotWings.Droid.Activities
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            var intent = new Intent(Application.Context, typeof(MainActivity));
            if (Intent.Extras != null)
            {
                intent.PutExtras(Intent.Extras);
            }
            StartActivity(intent);
        }
    }
}
