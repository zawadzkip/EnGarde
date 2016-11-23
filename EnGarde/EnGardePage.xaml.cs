using Xamarin.Forms;
using System;
using Plugin.Vibrate;
using System.Threading.Tasks;

namespace EnGarde
{
	public partial class EnGardePage : ContentPage
	{

		private uint leftScore = 0;
		private uint rightScore = 0;
		private uint currentPeriod = 1;
		private TimeSpan time;
		private bool shouldTimerBeRunning = false;

		//TODO Volume button to start/stop time.
		//TODO timepicker select for min and seconds.

		public EnGardePage ()
		{
			InitializeComponent ();
			time = new TimeSpan (0, 3, 0);
			startStopButton.Clicked += TimeButtonPressed;
			rightFrame.Tapped += RightFramePressed;
			rightFrame.DoubleTapped += RightFrameDoubleTapped;
			leftFrame.Tapped += LeftFramePressed;
			priorityButton.Clicked += PriorityButtonPressed;
			resetButton.Clicked += ResetButtonPressed;
			leftFrame.DoubleTapped += LeftFrameDoubleTapped;
			timeLabel.LongPressed += TimeLabelLongPressed;
		}

		void TimeLabelLongPressed (object arg1, EventArgs arg2)
		{
			startStopButton.Text = "Start";
			startStopButton.BackgroundColor = Color.FromHex ("#3498db");
			Navigation.PushModalAsync (new TimeSelectPage (timeLabel, this.time));
		}

		void ResetButtonPressed (object sender, EventArgs e)
		{
			leftFrame.BackgroundColor = Color.Transparent;
			rightFrame.BackgroundColor = Color.Transparent;
			leftScore = 0;
			rightScore = 0;
			time = new TimeSpan (0, 3, 0);
			shouldTimerBeRunning = false;
			currentPeriod = 1;
			timeLabel.Text = "3:00";
			periodLabel.Text = "Period 1";
			leftScoreText.Text = string.Format ("{0}", leftScore);
			rightScoreText.Text = string.Format ("{0}", rightScore);
		}

		void PriorityButtonPressed (object sender, EventArgs e)
		{
			var r = new Random ();
			var value = r.Next (0, 2);
			Device.BeginInvokeOnMainThread (async () => {
				leftFrame.BackgroundColor = Color.Transparent;
				rightFrame.BackgroundColor = Color.Transparent;
				for (var i = 0; i < 5; i++) {
					await FadeLeftFrameColor ();
					await FadeRightFrameColor ();
				}
				if (value == 0) {
					leftFrame.BackgroundColor = Color.FromHex ("#FF0000");
					await DisplayAlert ("Priority Assigned", "Priority Left", "ok");
				} else {
					rightFrame.BackgroundColor = Color.Lime;
					await DisplayAlert ("Priority Assigned", "Priority Right", "ok");
				}

			});

		}

		async Task FadeLeftFrameColor ()
		{
			leftFrame.BackgroundColor = Color.FromHex ("#FF0000");
			await Task.Delay (200);
			leftFrame.BackgroundColor = Color.Transparent;

		}
		async Task FadeRightFrameColor ()
		{
			rightFrame.BackgroundColor = Color.Lime;
			await Task.Delay (200);
			rightFrame.BackgroundColor = Color.Transparent;
		}

		void TimeButtonPressed (object sender, System.EventArgs e)
		{
			if (startStopButton.Text.Equals ("Start")) {
				startStopButton.BackgroundColor = Color.FromHex ("#FF0000");
				startStopButton.Text = "Stop";
				shouldTimerBeRunning = true;
				Device.StartTimer (new TimeSpan (0, 0, 1), () => {
					if (shouldTimerBeRunning) {
						if (time.Ticks != 0) {
							time = time.Subtract (new TimeSpan (0, 0, 1));
							timeLabel.Text = time.ToString ("m\\:ss");
							return true;
						} else {
							shouldTimerBeRunning = false;
							time = new TimeSpan (0, 3, 0);
							timeLabel.Text = "3:00";
							TimeButtonPressed (null, null);
							if (currentPeriod < 3 && currentPeriod > 0) {
								currentPeriod++;
							}
							periodLabel.Text = string.Format ("Period {0}", currentPeriod);
							//three 250 ms vibrations
							Task.Run (() => {
								CrossVibrate.Current.Vibration (250);
								Task.Delay (100);
								CrossVibrate.Current.Vibration (250);
								Task.Delay (100);
								CrossVibrate.Current.Vibration (250);
							});
							DisplayAlert ("Timer Stopped", "The time has expired", "Ok");
							return false;
						}

					} else {
						return false;
					}
				});
			} else {
				startStopButton.BackgroundColor = Color.FromHex ("#3498db");
				startStopButton.Text = "Start";
				shouldTimerBeRunning = false;
			}

		}

		void RightFramePressed (object arg1, System.EventArgs arg2)
		{
			rightScore++;
			//TODO Animate color change to lime and back to transparent
			rightScoreText.Opacity = 0.5;
			rightScoreText.Text = string.Format ("{0}", rightScore);
			rightScoreText.FadeTo (1);
		}

		void RightFrameDoubleTapped (object sender, MR.Gestures.TapEventArgs e)
		{
			if (rightScore != 0) {
				rightScore--;
			}
			//TODO Animate color change to lime and back to transparent

			rightScoreText.Opacity = 0.5;
			rightScoreText.Text = string.Format ("{0}", rightScore);
			rightScoreText.FadeTo (1);
		}

		void LeftFramePressed (object arg1, System.EventArgs arg2)
		{
			leftScore++;
			//TODO Animate color change to Red and back to transparent
			leftScoreText.Opacity = 0.5;
			leftScoreText.Text = string.Format ("{0}", leftScore);
			leftScoreText.FadeTo (1);
		}

		void LeftFrameDoubleTapped (object sender, MR.Gestures.TapEventArgs e)
		{
			if (leftScore != 0) {
				leftScore--;
			}
			//TODO Animate color change to Red and back to transparent
			leftScoreText.Opacity = 0.5;
			leftScoreText.Text = string.Format ("{0}", leftScore);
			leftScoreText.FadeTo (1);
		}
	}
}
