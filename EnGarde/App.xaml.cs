using Xamarin.Forms;

namespace EnGarde
{
	public partial class App : Application
	{
		public static int leftYellowCount = 0;
		public static int leftRedCount = 0;
		public static int leftBlackCount = 0;
		public static int rightYellowCount = 0;
		public static int rightRedCount = 0;
		public static int rightBlackCount = 0;
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
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
