using Acr.UserDialogs;
using NetbullMobile.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetbullMobile.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region Propriedades
        private INavigation _navigation;
        private Command _loginCommand;
        private Command _cadastroCommand;
        private string _userName;
        private string _senha;
        #endregion

        public LoginViewModel()
        {

        }

        #region Encapsulamento
        public string UserName { get { return _userName; } set { _userName = value; OnPropertyChanged("UserName"); } }
        public string Senha { get { return _senha; } set { _senha = value; OnPropertyChanged("Senha"); } }
        #endregion

        #region Commands
        public Command LoginCommand => _loginCommand ?? (_loginCommand = new Command(async () => await LoginCommandExecute()));
        #endregion

        #region Métodos
        private async Task LoginCommandExecute()
        {
            try
            {
                if(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Senha))
                    await App.Current.MainPage.DisplayAlert("Atenção", "É obrigatório informar usuário e senha", "Ok");
                else
                {
                    var loginViewmodel = new Model.LoginViewModel()
                    {
                        user_nome = "Bruna",
                        user_email = "brunalika@msn.com",
                        user_accessKey = "123"
                    };
                    var loginService = new LoginService();
                    var teste = loginService.Login(loginViewmodel);
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Atenção", "Não foi possível entrar no aplicativo", "Ok");
            }
        }
        #endregion
    }
}
