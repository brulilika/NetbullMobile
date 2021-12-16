using NetbullMobile.Model;
using NetbullMobile.Service;
using NetbullMobile.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetbullMobile.ViewModel
{
    public class MenuPrincipalViewModel : BaseViewModel
    {
        #region Propriedades
        private INavigation _navigation;
        private Command _expandeClientes;
        private Command _expandePedido;
        private ClienteService _clienteService;
        private ObservableCollection<Pessoa> _listaClientes;
        private ObservableCollection<Pedido> _listaPedido;
        #endregion

        public MenuPrincipalViewModel(INavigation navigation)
        {
            try
            {
                _navigation = navigation;
                ListaClientes = new ObservableCollection<Pessoa>();
                ListaPedido = new ObservableCollection<Pedido>();
                _clienteService = new ClienteService(); 
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        #region Encapsulamento
        public ObservableCollection<Pessoa> ListaClientes { get { return _listaClientes; } set { _listaClientes = value; OnPropertyChanged("ListaClientes"); } }
        public ObservableCollection<Pedido> ListaPedido { get { return _listaPedido; } set { _listaPedido = value; OnPropertyChanged("ListaPedido"); } }
        #endregion

        #region Commands
        public Command ExpandeClientes => _expandeClientes ?? (_expandeClientes = new Command(async () => await ExpandeClientesExecute()));
        public Command ExpandePedido => _expandePedido ?? (_expandePedido = new Command(async () => await ExpandePedidoExecute()));
        #endregion

        #region Métodos
        public async Task CarregaDados()
        {
            try
            {
                ListaClientes = new ObservableCollection<Pessoa>((await _clienteService.BuscaClientes()).Take(5));
                ListaPedido = new ObservableCollection<Pedido>((await new PedidoService().BuscaPedidos()).Take(5));
                OnPropertyChanged("ListaClientes");
                OnPropertyChanged("ListaPedido");
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Atenção", "Não foi possível iniciar página principal", "OK");
            }
        }

        private async Task ExpandeClientesExecute()
        {
            try
            {
                await _navigation.PushAsync(new ListaClientesPage());
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Atenção", "Não foi possível abrir lista de clientes", "OK");
            }
        }

        private async Task ExpandePedidoExecute()
        {
            try
            {
                await _navigation.PushAsync(new ListaPedido());
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Atenção", "Não foi possível abrir lista de clientes", "OK");
            }
        }
        #endregion
    }
}
