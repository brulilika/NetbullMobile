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
    public partial class ListaPedido : ContentPage
    {
        private ListaPedidosViewModel _listaPedidosViewModel;
        public ListaPedido()
        {
            InitializeComponent();
            _listaPedidosViewModel = new ListaPedidosViewModel(this.Navigation);
            BindingContext = _listaPedidosViewModel;
        }

        private void ListView_ItemSelected(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView lv)
                lv.SelectedItem = null;
        }
    }
}