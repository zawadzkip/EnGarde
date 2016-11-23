using System;

namespace EnGarde
{
	public partial class TimeSelectPage : Xamarin.Forms.ContentPage
	{
		public TimeSelectPage (MR.Gestures.Label TimeLabel, TimeSpan time)
		{
			InitializeComponent ();
			minuteEntry.Text = string.Format ("{0}", time.Minutes);
			secondEntry.Text = string.Format ("{0}", time.Seconds);
			currentTime.Text = string.Format ("Current Time: {0}", time.ToString ("m\\:ss"));
			updateTimeButton.Clicked += UpdateTimePressed;
		}

		void UpdateTimePressed (object sender, EventArgs e)
		{
			Navigation.PopModalAsync (true);
		}
	}
}
