using NetbullMobile.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetbullMobile.ViewModel
{
    public class DetalhePedidoViewModel : BaseViewModel
    {
        #region Propriedade
        private INavigation _navigation;
        private DetalhePedidoViewModel _pedido;
        private ObservableCollection<Item> _listaItem; 
        #endregion

        public DetalhePedidoViewModel(INavigation navigation)
        {
            _navigation = navigation;
            CarregaDados();
        }

        #region Encapsulamento
        public ObservableCollection<Item> ListaPedido { get { return _listaItem; } set { _listaItem = value; OnPropertyChanged("ListaPedido"); } }
        #endregion

        #region Commands
        #endregion

        #region Métodos
        private async Task CarregaDados()
        {
            try
            {
                
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Atenção", "Não foi possível iniciar detalhes do pedido", "OK");
            }
        }
        #endregion
    }
}
