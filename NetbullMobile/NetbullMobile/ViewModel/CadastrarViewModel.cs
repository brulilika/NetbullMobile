using NetbullMobile.Model.APIViewModel;
using NetbullMobile.Service;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetbullMobile.ViewModel
{
    public class CadastrarViewModel : BaseViewModel
    {
        #region Propriedades
        private INavigation _navigation;
        private Command _registrarCommand;
        private string _userName;
        private string _senha;
        private string _email;
        #endregion

        public CadastrarViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

        #region Encapsulamento
        public string UserName { get { return _userName; } set { _userName = value; OnPropertyChanged("UserName"); } }
        public string Senha { get { return _senha; } set { _senha = value; OnPropertyChanged("Senha"); } }
        public string Email { get { return _email; } set { _email = value; OnPropertyChanged("Senha"); } }
        #endregion

        #region Commands
        public Command RegistrarCommand => _registrarCommand ?? (_registrarCommand = new Command(async () => await RegistrarCommandExecute()));
        #endregion

        #region Métodos
        private async Task RegistrarCommandExecute()
        {
            try
            {
                if (string.IsNullOrEmpty(UserName?.Trim()) || string.IsNullOrEmpty(Email?.Trim()) || string.IsNullOrEmpty(Senha?.Trim()))
                    await App.Current.MainPage.DisplayAlert("Atenção","É obrigatório informar Username, Email e Senha","OK");
                else
                {
                    var registro = new RegisterRequestViewModel()
                    {
                        user_nome = UserName,
                        user_email = Email,
                        user_accessKey = Senha,
                    };
                    var service = new LoginService();
                    if(await service.Registrar(registro))
                    {
                        await App.Current.MainPage.DisplayAlert("Atenção", "Usuário registrado com sucesso!", "OK");
                        await _navigation.PopAsync();
                    }

                }
            }
            catch (Exception)
            {

                await App.Current.MainPage.DisplayAlert("Atenção","Não foi possível registrar usuário","OK");
            }
        }
        #endregion
    }
}
