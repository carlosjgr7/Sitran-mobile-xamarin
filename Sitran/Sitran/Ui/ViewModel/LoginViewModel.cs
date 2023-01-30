using System;
using System.Linq;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Sitran.Ui.Pages;
using Sitran.Utils;
using Xamarin.Essentials;
using Xamarin.Forms;
using Acr.UserDialogs;
using Sitran.Domain;
using System.Threading.Tasks;

namespace Sitran.Ui.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private INavigation navigation;
        public String User { get; set; }
        public String Pass { get; set; }
        public bool Remember { get; set; }

        public LoginViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            User = Preferences.Get(Prefer.User, "");
            Pass = Preferences.Get(Prefer.Pass, "");
        }

        public Command BiometricsCommand => new Command(async () =>
        {
            if (Preferences.Get(Prefer.User, "") == "")
            {
                await DisplayAlert("Error", "No existen datos biometricos guardados", "Ok");
                return;

            }
            var availibility = await CrossFingerprint.Current.IsAvailableAsync();

            if (!availibility)
            {
                await DisplayAlert("Error", "No tienes sistemas biommetricos disponibles", "Ok");
                return;
            }

            var authResult = await
                CrossFingerprint.Current.AuthenticateAsync(new AuthenticationRequestConfiguration(
                    "Verifique su identidad", "Confirma tu huella para continuar!"));

            if (authResult.Authenticated)
            {
                User = Preferences.Get(Prefer.User, "");
                Pass = Preferences.Get(Prefer.Pass, "");
                LoginCommand.Execute(null);
            }

        });
        public Command LoginCommand => new Command(async () =>
        {

            UserDialogs.Instance.ShowLoading("");
            var token = await new MakeLogin().DoLogin(User, Pass, 5);
            UserDialogs.Instance.HideLoading();


            if (token != null)
            {
                Preferences.Set(Prefer.Token, token.token);
                if (Remember)
                {
                    Preferences.Set(Prefer.User, User);
                    Preferences.Set(Prefer.Pass, Pass);

                }
                await navigation.PushAsync(new GraphicsPage());
            }
            else
            {
                await DisplayAlert("Error", "Usuario o Pass invalidos", "Ok");
                

            }

        });
    }
}