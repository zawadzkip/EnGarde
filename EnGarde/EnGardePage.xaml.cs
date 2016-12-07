using Xamarin.Forms;
using System;
using Plugin.Vibrate;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EnGarde
{
	public partial class EnGardePage : ContentPage
	{
		private uint leftScore = 0;
		private uint rightScore = 0;
		private uint currentPeriod = 1;
		private TimeSpan time;
		private bool shouldTimerBeRunning = false;
		private bool isRestPeriod = true;
		//TODO Volume button to start/stop time.

		public EnGardePage ()
		{
			InitializeComponent ();
			time = new TimeSpan (0, 3, 0);
			startStopButton.Clicked += TimeButtonPressed;
			rightFrame.Tapped += RightFramePressed;
			rightFrame.DoubleTapped += RightFrameDoubleTapped;
			leftFrame.Tapped += LeftFramePressed;
			leftFrame.DoubleTapped += LeftFrameDoubleTapped;
			priorityButton.Clicked += PriorityButtonPressed;
			resetButton.Clicked += ResetButtonPressed;
			timeLabel.Tapped += TimeLabelTapped;
			periodLabel.Tapped += PeriodLabelTapped;
			MessagingCenter.Subscribe<TimeSelectPage, TimeSpan> (this, "TimeUpdate", (TimeSelectPage arg1, TimeSpan arg2) => {
				time = arg2;
				timeLabel.Text = time.ToString ("m\\:ss");
			});

		}

		void TimeLabelTapped (object arg1, EventArgs arg2)
		{
			timeLabel.Opacity = 0.25;
			timeLabel.FadeTo (1);
			startStopButton.Text = "Start";
			startStopButton.BackgroundColor = Color.Gray;
			shouldTimerBeRunning = false;
			Navigation.PushModalAsync (new TimeSelectPage (timeLabel, this.time));
		}

		void PeriodLabelTapped (object sender, MR.Gestures.TapEventArgs e)
		{
			//TODO Show period edit
		}

		void ResetButtonPressed (object sender, EventArgs e)
		{
			resetButton.Opacity = 0.25;
			resetButton.FadeTo (1.0);
			leftFrame.BackgroundColor = Color.Transparent;
			rightFrame.BackgroundColor = Color.Transparent;
			leftScore = 0;
			rightScore = 0;
			time = new TimeSpan (0, 3, 0);
			shouldTimerBeRunning = false;
			isRestPeriod = true;
			currentPeriod = 1;
			timeLabel.Text = "3:00";
			periodLabel.Text = "Period 1";
			ResetLabelColors ();
			leftScoreText.Text = string.Format ("{0}", leftScore);
			rightScoreText.Text = string.Format ("{0}", rightScore);
			MessagingCenter.Send<EnGardePage> (this, "ResetCards");
		}

		void PriorityButtonPressed (object sender, EventArgs e)
		{
			var r = new Random ();
			var value = r.Next (0, 2);
			priorityButton.Opacity = 0.25;
			priorityButton.FadeTo (1.0);
			ResetLabelColors ();
			priorityButton.IsEnabled = false;
			Device.BeginInvokeOnMainThread (async () => {
				leftFrame.BackgroundColor = Color.Transparent;
				rightFrame.BackgroundColor = Color.Transparent;
				for (var i = 0; i < 5; i++) {
					await FlashLeftFrameColor ();
					await FlashRightFrameColor ();
				}
				if (value == 0) {
					leftFrame.BackgroundColor = Color.FromHex ("#FF0000");
					leftScoreText.TextColor = Color.Black;
					leftLabel.TextColor = Color.Black;
					await DisplayAlert ("Priority Assigned", "Priority Left", "ok");
				} else {
					rightFrame.BackgroundColor = Color.Lime;
					rightScoreText.TextColor = Color.Black;
					rightLabel.TextColor = Color.Black;
					await DisplayAlert ("Priority Assigned", "Priority Right", "ok");
				}
				if (Device.OS == TargetPlatform.Android) {
					leftFrame.OutlineColor = Color.FromHex ("#FF0000");
					rightFrame.OutlineColor = Color.Lime;
				}
			});
			priorityButton.IsEnabled = true;

		}

		async Task FlashLeftFrameColor ()
		{
			leftFrame.BackgroundColor = Color.FromHex ("#FF0000");
			await Task.Delay (200);
			leftFrame.BackgroundColor = Color.Transparent;

		}
		async Task FlashRightFrameColor ()
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
						App.timerIsRunning = true;
						if (time.Ticks != 0) {
							time = time.Subtract (new TimeSpan (0, 0, 1));
							timeLabel.Text = time.ToString ("m\\:ss");
							return true;
						} else {
							shouldTimerBeRunning = false;
							App.timerIsRunning = false;
							if (currentPeriod == 3) {
								currentPeriod = 1;
								periodLabel.Text = string.Format ("Period {0}", currentPeriod);
								NotifyTimerEnded ("Timer Stopped", "The time has expired, the bout has ended.");
							}
							TimeButtonPressed (null, null);
							if (currentPeriod < 3 && currentPeriod > 0) {
								if (!isRestPeriod) {
									currentPeriod++;
									time = new TimeSpan (0, 3, 0);
									timeLabel.Text = "3:00";
									periodLabel.Text = string.Format ("Period {0}", currentPeriod);
									NotifyTimerEnded ("Timer Stopped", "The rest period has expired.");
								} else {
									time = new TimeSpan (0, 1, 0);
									timeLabel.Text = "1:00";
									periodLabel.Text = "Period: Rest";
									NotifyTimerEnded ("Timer Stopped", "The time has expired, rest period has been set.");
								}
								isRestPeriod = !isRestPeriod;
							}
							return false;
						}

					} else {
						return false;
					}
				});
			} else {
				startStopButton.BackgroundColor = Color.Gray;
				startStopButton.Text = "Start";
				shouldTimerBeRunning = false;
			}

		}

		void RightFramePressed (object arg1, System.EventArgs arg2)
		{
			rightScore++;
			rightScoreText.Opacity = 0.5;
			rightScoreText.Text = string.Format ("{0}", rightScore);
			rightScoreText.FadeTo (1);
		}

		void RightFrameDoubleTapped (object sender, MR.Gestures.TapEventArgs e)
		{
			if (rightScore != 0) {
				rightScore--;
			}
			rightScoreText.Opacity = 0.5;
			rightScoreText.Text = string.Format ("{0}", rightScore);
			rightScoreText.FadeTo (1);
		}


		void LeftFramePressed (object arg1, System.EventArgs arg2)
		{
			leftScore++;
			leftScoreText.Opacity = 0.5;
			leftScoreText.Text = string.Format ("{0}", leftScore);
			leftScoreText.FadeTo (1);
		}

		void LeftFrameDoubleTapped (object sender, MR.Gestures.TapEventArgs e)
		{
			if (leftScore != 0) {
				leftScore--;
			}
			leftScoreText.Opacity = 0.5;
			leftScoreText.Text = string.Format ("{0}", leftScore);
			leftScoreText.FadeTo (1);
		}

		private void ResetLabelColors ()
		{
			leftLabel.TextColor = Color.White;
			leftScoreText.TextColor = Color.White;
			rightLabel.TextColor = Color.White;
			rightScoreText.TextColor = Color.White;
		}

		private async Task NotifyTimerEnded (string title, string message)
		{
			await Task.Run (() => {
				CrossVibrate.Current.Vibration (1000);
				Task.Delay (250);
				CrossVibrate.Current.Vibration (1000);
				Task.Delay (250);
				CrossVibrate.Current.Vibration (1000);
			});
			if (App.isSleeping) {
				//nothing

			} else {
				await DisplayAlert (title, message, "ok");
			}
		}
	}
}
