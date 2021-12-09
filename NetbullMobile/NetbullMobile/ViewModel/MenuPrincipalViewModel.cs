using NetbullMobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace NetbullMobile.ViewModel
{
    public class MenuPrincipalViewModel : BaseViewModel
    {
        #region Propriedades
        private INavigation _navigation;
        private Command _expandeClientes;
        private List<Pessoa> _listaClientes;
        private List<Pedido> _listaPedido;
        #endregion

        public MenuPrincipalViewModel(INavigation navigation)
        {
            try
            {
                _listaClientes = new List<Pessoa>();
                _listaClientes.Add(new Pessoa() { pessoa_id = 0, pessoa_nome = "Bruna", pessoa_documento = 1, pessoa_tipopessoa = EnumTipoPessoa.PessoaFisica });
                _listaClientes.Add(new Pessoa() { pessoa_id = 1, pessoa_nome = "Lika", pessoa_documento = 2, pessoa_tipopessoa = EnumTipoPessoa.PessoaJuridica });
                _listaClientes.Add(new Pessoa() { pessoa_id = 2, pessoa_nome = "Tamake", pessoa_documento = 3, pessoa_tipopessoa = EnumTipoPessoa.PessoaFisica });

                _listaPedido = new List<Pedido>();
                _listaPedido.Add(new Pedido() { codigo = "#1", valorTotal = "R$ 150,00", efetivado = false }) ;
                _listaPedido.Add(new Pedido() { codigo = "#2", valorTotal = "R$ 200,00", efetivado = true });
                _listaPedido.Add(new Pedido() { codigo = "#3", valorTotal = "R$ 250,00", efetivado = false });
                _listaPedido.Add(new Pedido() { codigo = "#4", valorTotal = "R$ 300,00", efetivado = false });
                _listaPedido.Add(new Pedido() { codigo = "#5", valorTotal = "R$ 350,00", efetivado = true });
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
        #endregion

        #region Métodos
        #endregion
    }
}
