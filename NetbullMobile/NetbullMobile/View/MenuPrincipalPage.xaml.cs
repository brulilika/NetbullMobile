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
    public partial class MenuPrincipalPage : ContentPage
    {
        private MenuPrincipalViewModel _menuPrincipalViewModel;
        public MenuPrincipalPage()
        {
            InitializeComponent();
            _menuPrincipalViewModel = new MenuPrincipalViewModel(this.Navigation);
            BindingContext = _menuPrincipalViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _menuPrincipalViewModel.CarregaDados();
        }
    }
}