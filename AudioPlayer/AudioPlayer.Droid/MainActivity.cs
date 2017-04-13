using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android;
using Android.Support.V4.App;
using Xamarin.Forms;

namespace AudioPlayer.Droid
{
	[Activity (Label = "AudioPlayer", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
            LoadApplication (new App());
            Verify();
		}

        public void Verify()
        {
            string[] permission =
            {
                Manifest.Permission.WriteExternalStorage
            };

            if(ActivityCompat.CheckSelfPermission(this, permission[0]) != Permission.Granted)
            {   
                RequestPermissions(permission, 0);
            }
        }
    }


}

