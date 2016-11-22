using Xamarin.Forms;
using System;

namespace EnGarde
{
	public partial class EnGardePage : ContentPage
	{

		private uint leftScore = 0;
		private uint rightScore = 0;
		public EnGardePage ()
		{
			InitializeComponent ();
			startStopButton.Clicked += TimeButtonPressed;
			rightFrame.Tapped += RightFramePressed;
			rightFrame.DoubleTapped += RightFrameDoubleTapped;
			leftFrame.Tapped += LeftFramePressed;
			leftFrame.DoubleTapped += LeftFrameDoubleTapped;

		}


		void TimeButtonPressed (object sender, System.EventArgs e)
		{
			if (startStopButton.Text.Equals ("Start")) {
				startStopButton.BackgroundColor = Color.FromHex ("#FF0000");
				startStopButton.Text = "Stop";
			} else {
				startStopButton.BackgroundColor = Color.FromHex ("#3498db");
				startStopButton.Text = "Start";
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
	}
}
