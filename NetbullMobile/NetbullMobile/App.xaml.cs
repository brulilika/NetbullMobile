using NetbullMobile.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetbullMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage())
            {
                BarBackgroundColor = Color.FromHex("#a8c030")
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
