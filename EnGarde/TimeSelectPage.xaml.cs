using System;

namespace EnGarde
{
	public partial class TimeSelectPage : Xamarin.Forms.ContentPage
	{
		public TimeSelectPage (MR.Gestures.Label TimeLabel, TimeSpan time)
		{
			InitializeComponent ();
			timePicker.Time = time;
			timePicker.Format = "m\\:ss";
			timePicker.Unfocused += async (sender, e) => {
				TimeLabel.Text = time.ToString ("m\\:ss");
				await Navigation.PopModalAsync (true);
			};
		}
	}
}
