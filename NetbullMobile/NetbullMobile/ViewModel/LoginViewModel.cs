﻿using Acr.UserDialogs;
using NetbullMobile.Service;
using NetbullMobile.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
                    var loginViewmodel = new Model.LoginRequestViewModel()
                    {
                        user_nome = UserName,
                        user_accessKey = Senha
                    };
                    var loginService = new LoginService();
                    var token = await loginService.Login(loginViewmodel);
                    if (!string.IsNullOrEmpty(token))
                    {
                        Preferences.Set("Username", UserName);
                        Preferences.Set("Password", Senha);
                        App.Current.MainPage = new NavigationPage(new MenuPrincipalPage());
                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Atenção", "Não foi possível fazer o login. Verifique usuário e senha informado.", "Ok");
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
