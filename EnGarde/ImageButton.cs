using System;
using MR.Gestures;
using Xamarin.Forms;

namespace EnGarde
{
	public class ImageButton : MR.Gestures.Frame
	{
		private MR.Gestures.Image image;
		private MR.Gestures.Label label;
		public ImageButton (ImageSource image, string labelText)
		{
			this.image.Source = image;
			this.image.HorizontalOptions = LayoutOptions.Start;
			this.image.VerticalOptions = LayoutOptions.Center;
			this.image.MinimumHeightRequest = 65;
			this.image.MinimumWidthRequest = 50;
			this.label.HorizontalOptions = LayoutOptions.End;
			this.label.VerticalOptions = LayoutOptions.Center;
			this.label.Text = labelText;
			this.BackgroundColor = Color.Transparent;
			this.OutlineColor = Color.White;
			this.Content = new Xamarin.Forms.StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Start,
				Children = {
					this.image,
					this.label,
				},
				Spacing = 5,
				Padding = new Thickness (5, 5, 5, 5),
			};
		}

		public void SetImage (ImageSource image)
		{
			this.image.Source = image;
		}

		public void SetText (string text)
		{
			this.label.Text = text;
		}

	}
}
