using System;
using Foundation;
using UIKit;

namespace EnGarde.iOS
{
	public class Notify_iOS : INotify
	{
		public void LocalNotification (string title, string message, double timeFromNow = 1)
		{
			var n = new UILocalNotification ();
			n.FireDate = NSDate.FromTimeIntervalSinceNow (timeFromNow);
			n.AlertAction = title;
			n.AlertBody = message;
			UIApplication.SharedApplication.ScheduleLocalNotification (n);
		}
	}
}
