using System;
using System.Net;
using EnGarde;
using EnGarde.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof (CustomWebView), typeof (CustomWebViewRenderer))]

namespace EnGarde.Droid
{
	public class CustomWebViewRenderer : WebViewRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<WebView> e)
		{
			base.OnElementChanged (e);

			if (e.NewElement != null) {
				var customWebView = Element as CustomWebView;
				Control.Settings.AllowUniversalAccessFromFileURLs = true;
				///data/user/0/io.patz.en_garde/files/fencing_rules.pdf
				//TODO make shit work
				Control.LoadUrl (string.Format ("file:///android_asset/pdfjs/web/viewer.html?file={0}", string.Format ("file:///android_asset/{0}", WebUtility.UrlEncode (customWebView.Uri))));
			}
		}
	}
}
