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
			MR.Gestures.iOS.Settings.LicenseKey = "STSH-AFTL-Z7DW-LBKD-Z5WT-G4W2-RABL-V8E9-PMYV-J6UU-2PGP-YTHX-V4HW";
			LoadApplication (new App ());
			var defaults = NSUserDefaults.StandardUserDefaults;
			var isNotFirstTime = defaults.BoolForKey (new NSString ("FirstTime"));
			if (!isNotFirstTime) {
				defaults.SetBool (true, "FirstTime");
				var settings = UIUserNotificationSettings.GetSettingsForTypes (UIUserNotificationType.Alert | UIUserNotificationType.Badge, null);
				var notificationSettings = UIApplication.SharedApplication.CurrentUserNotificationSettings;
				if (notificationSettings.Types != UIUserNotificationType.Alert && notificationSettings.Types != UIUserNotificationType.Badge) {
					var alert = new UIAlertView ("Notification Request", "Please accept notifications in order to notify you of a timer stopping when the phone is locked.", null, "Ok");
					alert.Clicked += (sender, e) => {
						UIApplication.SharedApplication.RegisterUserNotificationSettings (settings);
					};
					alert.Show ();
				}
			}
			UIApplication.SharedApplication.IdleTimerDisabled = true;
			return base.FinishedLaunching (app, options);
		}
	}
}
