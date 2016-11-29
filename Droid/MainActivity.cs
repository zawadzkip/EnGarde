using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace EnGarde.Droid
{
	[Activity (Label = "Escrime", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			MR.Gestures.Android.Settings.LicenseKey = "STSH-AFTL-Z7DW-LBKD-Z5WT-G4W2-RABL-V8E9-PMYV-J6UU-2PGP-YTHX-V4HW";
			this.Window.SetFlags (WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);
			LoadApplication (new App ());
		}
	}
}
