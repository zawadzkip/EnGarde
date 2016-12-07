using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EnGarde
{
	public partial class ShowCardPage : ContentPage
	{
		public ShowCardPage (Color c)
		{
			InitializeComponent ();
			this.BackgroundColor = c;
			pageFrame.GestureRecognizers.Add (new TapGestureRecognizer (async (View arg1, object arg2) => {
				await Navigation.PopAsync (true);
			}));
		}
	}
}
