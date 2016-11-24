using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EnGarde
{
	public partial class RulebookPage : ContentPage
	{
		//TODO Download PDF locally, from website, and check for it, have a spot where it will show the last time the PDF was updated,
		//as well the option to redownload from the URL.
		public RulebookPage ()
		{
			InitializeComponent ();
		}
		protected override async void OnAppearing ()
		{
			base.OnAppearing ();
			if (!DependencyService.Get<ISaveAndLoad> ().CheckFile (WebService.PDF_FILE_NAME)) {
				loadingIndicator.IsVisible = true;
				updateButton.IsEnabled = false;
				await WebService.DownloadRulesPDF ();
				if (DependencyService.Get<ISaveAndLoad> ().CheckFile (WebService.PDF_FILE_NAME)) {
					webView.Uri = WebService.PDF_FILE_NAME;
					var lastUpdatedDate = DependencyService.Get<ISaveAndLoad> ().CheckFileCreationTime (WebService.PDF_FILE_NAME);
					lastUpdatedLabel.Text = string.Format ("Last Updated: {0}", lastUpdatedDate.ToString ("yy-MMM-dd"));
				}
				loadingIndicator.IsVisible = false;
				updateButton.IsEnabled = true;
			}
		}
	}
}
