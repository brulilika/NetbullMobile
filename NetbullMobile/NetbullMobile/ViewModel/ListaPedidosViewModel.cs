using NetbullMobile.Model;
using NetbullMobile.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetbullMobile.ViewModel
{
    public class ListaPedidosViewModel : BaseViewModel
    {
        #region Propriedades
        private INavigation _navigation;
        private ObservableCollection<Pedido> _listaPedido;
        #endregion

        public ListaPedidosViewModel(INavigation navigation)
        {
            _navigation = navigation;
            CarregaDados();
        }

        #region Encapsulamento
        public ObservableCollection<Pedido> ListaPedido { get { return _listaPedido; } set { _listaPedido = value; OnPropertyChanged("ListaPedido"); } }
        #endregion

        #region Commands
        #endregion

        #region Métodos
        private async Task CarregaDados()
        {
            try
            {
                ListaPedido = new ObservableCollection<Pedido>((await new PedidoService().BuscaPedidos()).ToList());
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Atenção", "Não foi possível iniciar página lista de pedidos", "OK");
            }
        }
        #endregion
    }
}
