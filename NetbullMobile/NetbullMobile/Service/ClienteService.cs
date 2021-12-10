using NetbullMobile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NetbullMobile.Service
{
    public  class ClienteService
    {
        string URL = "http://192.168.0.21:5000/";
        public ClienteService()
        {
        }

        public async Task<List<Pessoa>> BuscaClientes()
        {
            try
            {
                HttpClient client = new HttpClient();

                var token = await new LoginService().Login(new LoginRequestViewModel()
                                                            {
                                                                user_nome = Preferences.Get("Username", ""),
                                                                user_accessKey = Preferences.Get("Password", ""),
                                                            });

                URL = $"{URL}api/Pessoa";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var resp = await client.GetAsync(URL);

                if (!resp.IsSuccessStatusCode)
                    return null;
                
                var clientes = JsonConvert.DeserializeObject<List<Pessoa>>(resp.Content.ReadAsStringAsync().Result);
                return clientes.OrderBy(ob=> ob.pessoa_id).ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
