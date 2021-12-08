using NetbullMobile.Model;
using NetbullMobile.Service.Interface;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetbullMobile.Service
{
    public class LoginService : ILoginService
    {
        HttpClient httpClient = new HttpClient();
        string URL = "http://localhost:7035/";
        public LoginService()
        {

        }


        public async Task<LoginViewModel> Login(LoginViewModel loginViewModel)
        {
            
            var api = RestService.For<ILoginService>(URL);
            var user = await api.Login(loginViewModel);
            return user;
        }

        public Task<LoginViewModel> Registrar([Body] LoginViewModel loginViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
