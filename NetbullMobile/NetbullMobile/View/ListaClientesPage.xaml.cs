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
    public partial class ListaClientesPage : ContentPage
    {
        private ListaClienteViewModel _listaClienteViewModel;
        public ListaClientesPage()
        {
            InitializeComponent();
            _listaClienteViewModel = new ListaClienteViewModel(this.Navigation);
            BindingContext = _listaClienteViewModel;
        }

        private void ListView_ItemSelected(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView lv) 
                lv.SelectedItem = null;
            this.Navigation.PushAsync(new DetalheClientePage(e.Item as Pessoa));
        }
    }
}