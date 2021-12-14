using NetbullMobile.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NetbullMobile.ViewModel
{
    public class DetalheClienteViewModel : BaseViewModel
    {
        #region Propriedades
        private INavigation _navigation;
        private Pessoa _pessoa;
        private List<Telefone> _listaTelefone;
        private List<Endereco> _listaEndereco;
        #endregion

        public DetalheClienteViewModel(INavigation navigation, Pessoa pessoa)
        {
            _navigation = navigation;
            _pessoa = pessoa;
            CarregaDados();
        }

        #region Encapsulamento
        public Pessoa Pessoa { get { return _pessoa; } set { _pessoa = value; OnPropertyChanged("Pessoa"); } }
        public List<Telefone> ListaTelefone { get { return _listaTelefone; } set { _listaTelefone = value; OnPropertyChanged("ListaTelefone"); } }
        public List<Endereco> ListaEndereco { get { return _listaEndereco; } set { _listaEndereco = value; OnPropertyChanged("ListaEndereco"); } }
        #endregion

        #region Commands
        #endregion

        #region Métodos
        private async Task CarregaDados()
        {

        }
        #endregion
    }
}
