﻿using NetbullMobile.Model;
using NetbullMobile.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetbullMobile.ViewModel
{
    public class ListaClienteViewModel : BaseViewModel
    {
        #region Propriedades
        private INavigation _navigation;
        private ClienteService _clienteService;
        private List<Pessoa> _listaClientes;
        #endregion

        public ListaClienteViewModel(INavigation navigation)
        {
            _navigation = navigation;
            ListaClientes = new List<Pessoa>();
            CarregaDados();
        }

        #region Encapsulamento
        public List<Pessoa> ListaClientes { get { return _listaClientes; } set { _listaClientes = value; OnPropertyChanged("ListaClientes"); } }
        #endregion

        #region Commands
        #endregion

        #region Métodos
        public async Task CarregaDados()
        {
            try
            {
                ListaClientes = await new ClienteService().BuscaClientes();
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Atenção", "Não foi possível iniciar lisdta de clientes", "OK");
            }
        }
        #endregion
    }
}
