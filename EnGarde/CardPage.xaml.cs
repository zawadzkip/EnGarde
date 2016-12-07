using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace EnGarde
{
	public partial class CardPage : ContentPage
	{

		public int leftYellowCount = 0;
		public int leftRedCount = 0;
		public int leftBlackCount = 0;
		public int rightYellowCount = 0;
		public int rightRedCount = 0;
		public int rightBlackCount = 0;

		public CardPage ()
		{
			InitializeComponent ();
			leftYellowFrame.Tapped += async (sender, e) => { await LeftYellowFrame_Tapped (sender, e); };
			leftYellowFrame.DoubleTapped += async (sender, e) => { await LeftYellowFrameDoubleTapped (sender, e); };
			leftRedFrame.Tapped += async (sender, e) => { await LeftRedFrame_Tapped (sender, e); };
			leftRedFrame.DoubleTapped += async (sender, e) => { await LeftRedFrameDoubleTapped (sender, e); };
			leftBlackFrame.Tapped += async (sender, e) => { await LeftBlackFrame_Tapped (sender, e); };
			leftBlackFrame.DoubleTapped += async (sender, e) => { await LeftBlackFrameDoubletapped (sender, e); };
			rightYellowFrame.Tapped += async (sender, e) => { await RightYellowFrame_Tapped (sender, e); };
			rightYellowFrame.DoubleTapped += async (sender, e) => { await RightYellowFrameDoubleTapped (sender, e); };
			rightRedFrame.Tapped += async (sender, e) => { await RightRedFrame_Tapped (sender, e); };
			rightRedFrame.DoubleTapped += async (sender, e) => { await RightRedFrameDoubleTapped (sender, e); };
			rightBlackFrame.Tapped += async (sender, e) => { await RightBlackFrame_Tapped (sender, e); };
			rightBlackFrame.DoubleTapped += async (sender, e) => { await RightBlackFrameDoubleTapped (sender, e); };
			MessagingCenter.Subscribe<EnGardePage> (this, "ResetCards", (EnGardePage arg1) => {
				Reset ();
			});
		}

		private void Reset ()
		{
			leftYellowCount = 0;
			leftYellowLabel.Text = "0";
			leftRedCount = 0;
			leftRedLabel.Text = "0";
			leftBlackCount = 0;
			leftBlackLabel.Text = "0";
			rightYellowCount = 0;
			rightYellowLabel.Text = "0";
			rightRedCount = 0;
			rightRedLabel.Text = "0";
			rightBlackCount = 0;
			rightBlackLabel.Text = "0";

		}

		async Task LeftYellowFrame_Tapped (object sender, MR.Gestures.TapEventArgs e)
		{
			leftYellowCount++;
			leftYellowLabel.Text = string.Format ("{0}", leftYellowCount);
			await FlashFrameColor ((Frame)sender, Color.Yellow);
		}
		async Task LeftYellowFrameDoubleTapped (object sender, MR.Gestures.TapEventArgs e)
		{
			if (leftYellowCount > 0) {
				leftYellowCount--;
			}
			leftYellowLabel.Text = string.Format ("{0}", leftYellowCount);
			await FlashFrameColor ((Frame)sender, Color.Yellow, false);
		}

		async Task LeftRedFrame_Tapped (object sender, MR.Gestures.TapEventArgs e)
		{
			leftRedCount++;
			leftRedLabel.Text = string.Format ("{0}", leftRedCount);
			await FlashFrameColor ((Frame)sender, Color.Red);
		}

		async Task LeftRedFrameDoubleTapped (object sender, MR.Gestures.TapEventArgs e)
		{
			if (leftRedCount > 0) {
				leftRedCount--;
			}
			leftRedLabel.Text = string.Format ("{0}", leftRedCount);
			await FlashFrameColor ((Frame)sender, Color.Red, false);
		}

		async Task LeftBlackFrame_Tapped (object sender, MR.Gestures.TapEventArgs e)
		{
			leftBlackCount++;
			leftBlackLabel.Text = string.Format ("{0}", leftBlackCount);
			await FlashFrameColor ((Frame)sender, Color.Black);
		}

		async Task LeftBlackFrameDoubletapped (object sender, MR.Gestures.TapEventArgs e)
		{
			if (leftBlackCount > 0) {
				leftBlackCount--;
			}
			leftBlackLabel.Text = string.Format ("{0}", leftBlackCount);
			await FlashFrameColor ((Frame)sender, Color.Black, false);

		}

		async Task RightYellowFrame_Tapped (object sender, MR.Gestures.TapEventArgs e)
		{
			rightYellowCount++;
			rightYellowLabel.Text = string.Format ("{0}", rightYellowCount);
			await FlashFrameColor ((Frame)sender, Color.Yellow);

		}
		async Task RightYellowFrameDoubleTapped (object sender, MR.Gestures.TapEventArgs e)
		{
			if (rightYellowCount > 0) {
				rightYellowCount--;
			}
			rightYellowLabel.Text = string.Format ("{0}", rightYellowCount);
			await FlashFrameColor ((Frame)sender, Color.Yellow, false);

		}

		async Task RightRedFrame_Tapped (object sender, MR.Gestures.TapEventArgs e)
		{

			rightRedCount++;
			rightRedLabel.Text = string.Format ("{0}", rightRedCount);
			await FlashFrameColor ((Frame)sender, Color.Red);
		}

		async Task RightRedFrameDoubleTapped (object sender, MR.Gestures.TapEventArgs e)
		{
			if (rightRedCount > 0) {
				rightRedCount--;
			}
			rightRedLabel.Text = string.Format ("{0}", rightRedCount);
			await FlashFrameColor ((Frame)sender, Color.Red, false);
		}



		async Task RightBlackFrame_Tapped (object sender, MR.Gestures.TapEventArgs e)
		{
			rightBlackCount++;
			rightBlackLabel.Text = string.Format ("{0}", rightBlackCount);
			await FlashFrameColor ((Frame)sender, Color.Black);

		}

		async Task RightBlackFrameDoubleTapped (object sender, MR.Gestures.TapEventArgs e)
		{
			if (rightBlackCount > 0) {
				rightBlackCount--;
			}
			rightBlackLabel.Text = string.Format ("{0}", rightBlackCount);
			await FlashFrameColor ((Frame)sender, Color.Black, false);

		}


		private async Task FlashFrameColor (Frame frame, Color c, bool showColor = true)
		{
			frame.Opacity = 0.1;
			await frame.FadeTo (1, 250);
			if (showColor) {
				await Navigation.PushModalAsync (new ShowCardPage (c));
			}
		}
	}
}

