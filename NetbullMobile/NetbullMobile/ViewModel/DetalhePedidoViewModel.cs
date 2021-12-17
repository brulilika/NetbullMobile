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
    public class DetalhePedidoViewModel : BaseViewModel
    {
        #region Propriedade
        private INavigation _navigation;
        private Pedido _pedido;
        private ObservableCollection<Item> _listaItem;
        private Endereco _endereco;
        #endregion

        public DetalhePedidoViewModel(INavigation navigation, Pedido pedido)
        {
            _navigation = navigation;
            _pedido = pedido;
            CarregaDados();
        }

        #region Encapsulamento
        public Pedido Pedido { get { return _pedido; } set { _pedido = value; OnPropertyChanged("Pedido"); } }
        public Endereco Endereco { get { return _endereco; } set { _endereco = value; OnPropertyChanged("Endereco"); } }
        public ObservableCollection<Item> ListaItem { get { return _listaItem; } set { _listaItem = value; OnPropertyChanged("ListaItem"); } }
        #endregion

        #region Commands
        #endregion

        #region Métodos
        private async Task CarregaDados()
        {
            try
            {
                var listaEnderecosCliente = await new EnderecoService().BuscaEnderecoPessoa(_pedido.pedido_idPessoa);
                Endereco = listaEnderecosCliente.FirstOrDefault(e => e.endereco_id == Pedido.pedido_idEndereco);
                ListaItem = new ObservableCollection<Item>(await new PedidoService().BuscaItensById(_pedido.pedido_id));
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Atenção", "Não foi possível iniciar detalhes do pedido", "OK");
            }
        }
        #endregion
    }
}
