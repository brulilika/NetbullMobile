using NetbullMobile.Model;
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
    public partial class DetalheClientePage : ContentPage
    {
        private DetalheClienteViewModel _detalheClienteViewModel;
        public DetalheClientePage(Pessoa pessoa)
        {
            InitializeComponent();
            _detalheClienteViewModel = new DetalheClienteViewModel(this.Navigation, pessoa);
            BindingContext = _detalheClienteViewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}