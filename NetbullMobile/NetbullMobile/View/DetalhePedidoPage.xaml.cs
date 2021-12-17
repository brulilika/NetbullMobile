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
    public partial class DetalhePedidoPage : ContentPage
    {
        private DetalhePedidoViewModel _detalhePedidoViewModel;
        public DetalhePedidoPage(Pedido pedido)
        {
            InitializeComponent();
            _detalhePedidoViewModel = new DetalhePedidoViewModel(this.Navigation, pedido);
            BindingContext = _detalhePedidoViewModel;
        }

        private void ListView_ItemSelected(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView lv)
                lv.SelectedItem = null;
        }
    }
}