using NetbullMobile.Model;
using NetbullMobile.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetbullMobile.ViewModel
{
    public class DetalheClienteViewModel : BaseViewModel
    {
        #region Propriedades
        private INavigation _navigation;
        private Pessoa _pessoa;
        private ObservableCollection<Telefone> _listaTelefone;
        private ObservableCollection<Endereco> _listaEndereco;
        #endregion

        public DetalheClienteViewModel(INavigation navigation, Pessoa pessoa)
        {
            _navigation = navigation;
            _pessoa = pessoa;
            CarregaDados();
        }

        #region Encapsulamento
        public Pessoa Pessoa { get { return _pessoa; } set { _pessoa = value; OnPropertyChanged("Pessoa"); } }
        public ObservableCollection<Telefone> ListaTelefone { get { return _listaTelefone; } set { _listaTelefone = value; OnPropertyChanged("ListaTelefone"); } }
        public ObservableCollection<Endereco> ListaEndereco { get { return _listaEndereco; } set { _listaEndereco = value; OnPropertyChanged("ListaEndereco"); } }
        #endregion

        #region Commands
        #endregion

        #region Métodos
        private async Task CarregaDados()
        {
            try
            {
                try
                {
                    ListaEndereco = new ObservableCollection<Endereco>(await new EnderecoService().BuscaEnderecoPessoa(Pessoa.pessoa_id)); 
                }
                catch (Exception) { }

                try
                {
                    ListaTelefone = new ObservableCollection<Telefone>(await new TelefoneService().BuscaTelefonesPessoa(Pessoa.pessoa_id)); 
                }
                catch (Exception) { }
                OnPropertyChanged("ListaEndereco");
                OnPropertyChanged("ListaTelefone");
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Atenção","Não foi possível encontrar todas as informações do cliente","OK");
            }
            
        }
        #endregion
    }
}
