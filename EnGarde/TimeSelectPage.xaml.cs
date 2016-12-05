using System;
using System.Net.Http;
using Xamarin.Forms;

namespace EnGarde
{
	public partial class TimeSelectPage : Xamarin.Forms.ContentPage
	{
		TimeSpan t;
		public TimeSelectPage (MR.Gestures.Label TimeLabel, TimeSpan time)
		{
			InitializeComponent ();
			t = time;
			minuteEntry.Text = string.Format ("{0}", time.Minutes);
			secondEntry.Text = string.Format ("{0}", time.Seconds);
			currentTime.Text = string.Format ("Current Time: {0}", time.ToString ("m\\:ss"));
			updateTimeButton.Clicked += UpdateTimePressed;
			oneMinButton.Clicked += OneMinButton_Clicked;
		}

		private void ResetText ()
		{
			minuteEntry.Text = string.Format ("{0}", t.Minutes);
			secondEntry.Text = string.Format ("{0}", t.Seconds);
		}

		void OneMinButton_Clicked (object sender, EventArgs e)
		{
			MessagingCenter.Send<TimeSelectPage, TimeSpan> (this, "TimeUpdate", new TimeSpan (0, 1, 0));
			Navigation.PopModalAsync (true);
		}

		void UpdateTimePressed (object sender, EventArgs e)
		{
			try {
				var minute = Int32.Parse (minuteEntry.Text);
				var second = Int32.Parse (secondEntry.Text);
				if (minute > 3) {
					ResetText ();
					DisplayAlert ("Error", "Cannot have more than 3 minutes", "Ok");
					return;
				} else if (minute < 0) {
					ResetText ();
					DisplayAlert ("Error", "Cannot have less than 0 minutes", "Ok");
					return;
				}
				if (second > 60) {
					ResetText ();
					DisplayAlert ("Error", "Cannot have more than 59 seconds", "Ok");
					return;
				} else if (second < 0) {
					ResetText ();
					DisplayAlert ("Error", "Cannot have less than 0 seconds", "Ok");
					return;
				}
				MessagingCenter.Send<TimeSelectPage, TimeSpan> (this, "TimeUpdate", new TimeSpan (0, minute, second));
				Navigation.PopModalAsync (true);
			} catch (Exception e1) {
				ResetText ();
				DisplayAlert ("Error", "Please only enter integer values", "Ok");
			}

		}
	}
}
