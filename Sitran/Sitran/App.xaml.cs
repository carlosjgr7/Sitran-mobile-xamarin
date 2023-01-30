using System;
using Sitran.Ui.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sitran
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

