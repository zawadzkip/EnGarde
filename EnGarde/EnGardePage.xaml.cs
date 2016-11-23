using Xamarin.Forms;
using System;

namespace EnGarde
{
	public partial class EnGardePage : ContentPage
	{

		private uint leftScore = 0;
		private uint rightScore = 0;
		private TimeSpan time;
		private bool shouldTimerBeRunning = false;
		//TODO use Device.starTimer and use a time object or something to store time.
		public EnGardePage()
		{
			InitializeComponent();
			time = new TimeSpan(0, 3, 0);
			startStopButton.Clicked += TimeButtonPressed;
			rightFrame.Tapped += RightFramePressed;
			rightFrame.DoubleTapped += RightFrameDoubleTapped;
			leftFrame.Tapped += LeftFramePressed;
			leftFrame.DoubleTapped += LeftFrameDoubleTapped;
			timeLabel.GestureRecognizers.Add(new TapGestureRecognizer(TimeLabelPressed));


		}

		void TimeLabelPressed(View arg1, object arg2)
		{
			startStopButton.Text = "Start";
			startStopButton.BackgroundColor = Color.FromHex("#3498db");
			timeLabel.Text = "3:00";
		}

		void TimeButtonPressed(object sender, System.EventArgs e)
		{
			if (startStopButton.Text.Equals("Start"))
			{
				startStopButton.BackgroundColor = Color.FromHex("#FF0000");
				startStopButton.Text = "Stop";
				shouldTimerBeRunning = true;
				Device.StartTimer(new TimeSpan(0, 0, 1), () =>
				{
					if (shouldTimerBeRunning)
					{
						time = time.Subtract(new TimeSpan(0, 0, 1));
						timeLabel.Text = time.ToString("m\\:ss");
						return true;
					}
					else
					{
						return false;
					}
				});
			}
			else
			{
				startStopButton.BackgroundColor = Color.FromHex("#3498db");
				startStopButton.Text = "Start";
				shouldTimerBeRunning = false;
			}

		}

		void RightFramePressed(object arg1, System.EventArgs arg2)
		{
			rightScore++;
			rightScoreText.Opacity = 0.5;
			rightScoreText.Text = string.Format("{0}", rightScore);
			rightScoreText.FadeTo(1);
		}

		void RightFrameDoubleTapped(object sender, MR.Gestures.TapEventArgs e)
		{
			if (rightScore != 0)
			{
				rightScore--;
			}
			rightScoreText.Opacity = 0.5;
			rightScoreText.Text = string.Format("{0}", rightScore);
			rightScoreText.FadeTo(1);
		}

		void LeftFramePressed(object arg1, System.EventArgs arg2)
		{
			leftScore++;
			leftScoreText.Opacity = 0.5;
			leftScoreText.Text = string.Format("{0}", leftScore);
			leftScoreText.FadeTo(1);
		}

		void LeftFrameDoubleTapped(object sender, MR.Gestures.TapEventArgs e)
		{
			if (leftScore != 0)
			{
				leftScore--;
			}
			leftScoreText.Opacity = 0.5;
			leftScoreText.Text = string.Format("{0}", leftScore);
			leftScoreText.FadeTo(1);
		}
	}
}
