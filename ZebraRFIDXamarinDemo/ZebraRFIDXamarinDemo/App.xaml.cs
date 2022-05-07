using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace ZebraRFIDXamarinDemo
{
	public partial class App : Application
	{
		private MainPage mainPage;
		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(mainPage = new MainPage());
		}

		protected override void OnStart ()
		{
            // Handle when your app starts
            mainPage.OnResume();
        }

		protected override void OnSleep ()
		{
            // Handle when your app sleeps
            mainPage.OnSleep();
        }

		protected override void OnResume ()
		{
			// Handle when your app resumes
			mainPage.OnResume();
		}

	}
}
