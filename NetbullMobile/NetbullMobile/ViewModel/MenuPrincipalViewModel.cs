using NetbullMobile.Model;
using NetbullMobile.Service;
using NetbullMobile.View;
using System;
using System.Collections.Generic;
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
        private ClienteService _clienteService;
        private List<Pessoa> _listaClientes;
        private List<Pedido> _listaPedido;
        #endregion

        public MenuPrincipalViewModel(INavigation navigation)
        {
            try
            {
                _navigation = navigation;
                ListaClientes = new List<Pessoa>();
                ListaPedido = new List<Pedido>();
                _clienteService = new ClienteService(); 
                
                CarregaDados();
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        #region Encapsulamento
        public List<Pessoa> ListaClientes { get { return _listaClientes; } set { _listaClientes = value; OnPropertyChanged("ListaClientes"); } }
        public List<Pedido> ListaPedido { get { return _listaPedido; } set { _listaPedido = value; OnPropertyChanged("ListaPedido"); } }
        #endregion

        #region Commands
        public Command ExpandeClientes => _expandeClientes ?? (_expandeClientes = new Command(async () => await ExpandeClientesExecute()));
        #endregion

        #region Métodos
        private async Task CarregaDados()
        {
            try
            {
                ListaClientes = (await _clienteService.BuscaClientes()).Take(5).ToList();

                ListaPedido.Add(new Pedido() { codigo = "#1", valorTotal = "R$ 150,00", efetivado = false });
                ListaPedido.Add(new Pedido() { codigo = "#2", valorTotal = "R$ 200,00", efetivado = true });
                ListaPedido.Add(new Pedido() { codigo = "#3", valorTotal = "R$ 250,00", efetivado = false });
                ListaPedido.Add(new Pedido() { codigo = "#4", valorTotal = "R$ 300,00", efetivado = false });
                ListaPedido.Add(new Pedido() { codigo = "#5", valorTotal = "R$ 350,00", efetivado = true });
            }
            catch (Exception)
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
        #endregion
    }
}
