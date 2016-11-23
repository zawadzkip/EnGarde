using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace EnGarde.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();
			MR.Gestures.iOS.Settings.LicenseKey = "6TYF-PUZS-LB5B-EDH4-DXGB-BADT-NESN-S8JZ-E8GA-FL5B-PVH8-3Q8Q-EXB6";
			LoadApplication (new App ());
			UIApplication.SharedApplication.IdleTimerDisabled = true;
			return base.FinishedLaunching (app, options);
		}
	}
}
