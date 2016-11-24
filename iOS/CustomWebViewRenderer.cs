using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using EnGarde;
using Xamarin.Forms;
using EnGarde.iOS;
using System.IO;
using Foundation;
using System.Net;

[assembly: ExportRenderer (typeof (CustomWebView), typeof (CustomWebViewRenderer))]
namespace EnGarde.iOS
{
	public class CustomWebViewRenderer : ViewRenderer<CustomWebView, UIWebView>
	{
		protected override void OnElementChanged (ElementChangedEventArgs<CustomWebView> e)
		{
			base.OnElementChanged (e);

			if (Control == null) {
				SetNativeControl (new UIWebView ());
			}
			if (e.OldElement != null) {
				// Cleanup
			}
			if (e.NewElement != null) {
				var customWebView = Element as CustomWebView;
				string fileName = Path.Combine (NSBundle.MainBundle.BundlePath, string.Format ("{0}", WebUtility.UrlEncode (customWebView.Uri)));
				Control.LoadRequest (new NSUrlRequest (new NSUrl (fileName, false)));
				Control.ScalesPageToFit = true;
			}
		}
	}
}
