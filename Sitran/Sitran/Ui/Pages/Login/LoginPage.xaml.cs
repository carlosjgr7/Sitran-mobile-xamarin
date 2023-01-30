using System;
using System.Collections.Generic;
using Sitran.Ui.ViewModel;
using Xamarin.Forms;

namespace Sitran.Ui.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);

        }
    }
}

