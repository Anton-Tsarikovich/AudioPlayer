using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.App;
using AudioPlayer.SQLite;
using FreshMvvm;
using FreshTinyIoC;
using Xamarin.Forms;


namespace AudioPlayer.Droid
{
    [Activity(Label = "AudioPlayer", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Forms.Init(this, bundle);
            Verify();
            LoadApplication(new App());
        }

        public void Verify()
        {
            string[] permission =
            {
                Manifest.Permission.WriteExternalStorage
            };

            if (ActivityCompat.CheckSelfPermission(this, permission[0]) != Permission.Granted)
            {
                RequestPermissions(permission, 0);
            }
        }
    }


}

