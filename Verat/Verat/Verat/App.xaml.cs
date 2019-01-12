using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Verat
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent(); 

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            var mp = new MainPage();
            mp.reloadItems();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            var mp = new MainPage();
            mp.reloadItems();
        }
    }
}
