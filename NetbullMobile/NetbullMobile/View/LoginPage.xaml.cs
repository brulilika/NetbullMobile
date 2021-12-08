using NetbullMobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetbullMobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel _loginViewModel;
        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            _loginViewModel = new LoginViewModel();
            BindingContext = _loginViewModel;
        }
    }
}