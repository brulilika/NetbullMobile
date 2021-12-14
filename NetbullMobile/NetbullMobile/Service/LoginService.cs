using NetbullMobile.Model;
using NetbullMobile.Model.APIViewModel;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetbullMobile.Service
{
    public class LoginService : BaseService
    {
        public LoginService()
        {

        }

        public async Task<bool> Registrar(RegisterRequestViewModel registerRequestViewModel)
        {
            try
            {
                var json = JsonConvert.SerializeObject(registerRequestViewModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();

                URL = $"{URL}api/Conta/registrar";
                var resp = await client.PostAsync(URL, content);

                if (!resp.IsSuccessStatusCode)
                    return false;

                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<string> Login(LoginRequestViewModel loginViewModel)
        {
            try
            {
                var json = JsonConvert.SerializeObject(loginViewModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();

                URL = $"{URL}api/Conta/login";
                var resp = await client.PostAsync(URL, content);

                if (!resp.IsSuccessStatusCode)
                    return null;

                var login = JsonConvert.DeserializeObject<LoginReturnViewModel>(resp.Content.ReadAsStringAsync().Result);
                return login.Token;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
