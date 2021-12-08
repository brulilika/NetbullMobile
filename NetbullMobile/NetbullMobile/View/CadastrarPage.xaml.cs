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
    public partial class CadastrarPage : ContentPage
    {
        private CadastrarViewModel _cadastrarViewModel;
        public CadastrarPage()
        {
            InitializeComponent();
            _cadastrarViewModel = new CadastrarViewModel(this.Navigation);
            BindingContext = _cadastrarViewModel;
        }
    }
}