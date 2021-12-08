using NetbullMobile.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetbullMobile.Service.Interface
{
    public interface ILoginService
    {
        [Post("/Conta/v1/login")]
        Task<LoginViewModel> Login([Body] LoginViewModel loginViewModel);
        [Post("/Conta/v1/registrar")]
        Task<LoginViewModel> Registrar([Body] LoginViewModel loginViewModel);
    }
}
