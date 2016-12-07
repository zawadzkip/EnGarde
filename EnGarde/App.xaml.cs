using Xamarin.Forms;
using System.Diagnostics;

namespace EnGarde
{
	public partial class App : Application
	{
		public static bool isSleeping = false;
		public static bool timerIsRunning = false;
		public App ()
		{
			InitializeComponent ();
			var carouselPage = new CarouselPage {
				BackgroundColor = Color.Gray,
			};
			var engardePage = new EnGardePage ();
			carouselPage.Children.Add (new RulebookPage ());
			carouselPage.Children.Add (engardePage);
			carouselPage.Children.Add (new CardPage ());
			carouselPage.CurrentPage = engardePage;

			MainPage = carouselPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			isSleeping = true;
			// Handle when your app sleeps
			if (timerIsRunning) {

			}

		}

		protected override void OnResume ()
		{
			isSleeping = false;
			// Handle when your app resumes
		}
	}
}
