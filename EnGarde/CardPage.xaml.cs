using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EnGarde
{
	public partial class CardPage : ContentPage
	{

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
			//TODO Show ability to add cards for each fencer
			//TODO on frame selection, highlight bakground color to be the same color of the card selected for 2 seconds.

		}


		async Task LeftYellowFrame_Tapped (object sender, MR.Gestures.TapEventArgs e)
		{
			App.leftYellowCount++;
			leftYellowLabel.Text = string.Format ("{0}", App.leftYellowCount);
			await FlashFrameColor ((Frame)sender, true);
		}
		async Task LeftYellowFrameDoubleTapped (object sender, MR.Gestures.TapEventArgs e)
		{
			if (App.leftYellowCount > 0) {
				App.leftYellowCount--;
			}
			leftYellowLabel.Text = string.Format ("{0}", App.leftYellowCount);
			await FlashFrameColor ((Frame)sender, true);
		}

		async Task LeftRedFrame_Tapped (object sender, MR.Gestures.TapEventArgs e)
		{
			App.leftRedCount++;
			leftRedLabel.Text = string.Format ("{0}", App.leftRedCount);
			await FlashFrameColor ((Frame)sender, true);
		}

		async Task LeftRedFrameDoubleTapped (object sender, MR.Gestures.TapEventArgs e)
		{
			if (App.leftRedCount > 0) {
				App.leftRedCount--;
			}
			leftRedLabel.Text = string.Format ("{0}", App.leftRedCount);
			await FlashFrameColor ((Frame)sender, true);
		}

		async Task LeftBlackFrame_Tapped (object sender, MR.Gestures.TapEventArgs e)
		{
			App.leftBlackCount++;
			leftBlackLabel.Text = string.Format ("{0}", App.leftBlackCount);
			await FlashFrameColor ((Frame)sender, true);
		}

		async Task LeftBlackFrameDoubletapped (object sender, MR.Gestures.TapEventArgs e)
		{
			if (App.leftBlackCount > 0) {
				App.leftBlackCount--;
			}
			leftBlackLabel.Text = string.Format ("{0}", App.leftBlackCount);
			await FlashFrameColor ((Frame)sender, true);

		}

		async Task RightYellowFrame_Tapped (object sender, MR.Gestures.TapEventArgs e)
		{
			App.rightYellowCount++;
			rightYellowLabel.Text = string.Format ("{0}", App.rightYellowCount);
			await FlashFrameColor ((Frame)sender, false);

		}
		async Task RightYellowFrameDoubleTapped (object sender, MR.Gestures.TapEventArgs e)
		{
			if (App.rightYellowCount > 0) {
				App.rightYellowCount--;
			}
			rightYellowLabel.Text = string.Format ("{0}", App.rightYellowCount);
			await FlashFrameColor ((Frame)sender, true);

		}

		async Task RightRedFrame_Tapped (object sender, MR.Gestures.TapEventArgs e)
		{

			App.rightRedCount++;
			rightRedLabel.Text = string.Format ("{0}", App.rightRedCount);
			await FlashFrameColor ((Frame)sender, false);
		}

		async Task RightRedFrameDoubleTapped (object sender, MR.Gestures.TapEventArgs e)
		{
			if (App.rightRedCount > 0) {
				App.rightRedCount--;
			}
			rightRedLabel.Text = string.Format ("{0}", App.rightRedCount);
			await FlashFrameColor ((Frame)sender, false);
		}



		async Task RightBlackFrame_Tapped (object sender, MR.Gestures.TapEventArgs e)
		{
			App.rightBlackCount++;
			rightBlackLabel.Text = string.Format ("{0}", App.rightBlackCount);
			await FlashFrameColor ((Frame)sender, false);

		}

		async Task RightBlackFrameDoubleTapped (object sender, MR.Gestures.TapEventArgs e)
		{
			if (App.rightBlackCount > 0) {
				App.rightBlackCount--;
			}
			rightBlackLabel.Text = string.Format ("{0}", App.rightBlackCount);
			await FlashFrameColor ((Frame)sender, false);

		}


		private async Task FlashFrameColor (Frame frame, bool isRed)
		{
			//var c = Color.Lime;
			//if (isRed) {
			//	c = Color.FromHex ("#FF0000");
			//}
			//frame.BackgroundColor = c;
			frame.Opacity = 0.1;
			await frame.FadeTo (1, 250);
			//frame.BackgroundColor = Color.Transparent;
		}
	}
}

