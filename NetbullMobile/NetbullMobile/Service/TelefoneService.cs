using NetbullMobile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NetbullMobile.Service
{
    public class TelefoneService: BaseService
    {
        public TelefoneService()
        {
                
        }

        public async Task<List<Telefone>> BuscaTelefonesPessoa(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                var token = await new LoginService().Login(new LoginRequestViewModel()
                {
                    user_nome = Preferences.Get("Username", ""),
                    user_accessKey = Preferences.Get("Password", ""),
                });

                URL = $"{URL}api/Telefone/{id}";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var resp = await client.GetAsync(URL);

                if (!resp.IsSuccessStatusCode)
                    return null;

                var telefones = JsonConvert.DeserializeObject<List<Telefone>>(resp.Content.ReadAsStringAsync().Result);
                return telefones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Telefone> RegistraTelefonePessoa(Telefone telefone)
        {
            try
            {
                HttpClient client = new HttpClient();
                var token = await new LoginService().Login(new LoginRequestViewModel()
                {
                    user_nome = Preferences.Get("Username", ""),
                    user_accessKey = Preferences.Get("Password", ""),
                });

                var json = JsonConvert.SerializeObject(new
                {
                    telefone_numero = telefone.telefone_numero,
                    telefone_idPessoa = telefone.telefone_idPessoa
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                URL = $"{URL}api/Telefone";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var resp = await client.PostAsync(URL, content);

                if (!resp.IsSuccessStatusCode)
                    return null;

                var novoTelefone = JsonConvert.DeserializeObject<Telefone>(resp.Content.ReadAsStringAsync().Result);
                return novoTelefone;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Telefone> AtualizaTelefonePessoa(Telefone telefone)
        {
            try
            {
                HttpClient client = new HttpClient();
                var token = await new LoginService().Login(new LoginRequestViewModel()
                {
                    user_nome = Preferences.Get("Username", ""),
                    user_accessKey = Preferences.Get("Password", ""),
                });

                var json = JsonConvert.SerializeObject(new
                {
                    telefone_numero = telefone.telefone_numero,
                    telefone_idPessoa = telefone.telefone_idPessoa
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                URL = $"{URL}api/Telefone";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var resp = await client.PutAsync(URL, content);

                if (!resp.IsSuccessStatusCode)
                    return null;

                var novoTelefone = JsonConvert.DeserializeObject<Telefone>(resp.Content.ReadAsStringAsync().Result);
                return novoTelefone;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeletaTelefonesPessoa(int idTelefone)
        {
            try
            {
                HttpClient client = new HttpClient();
                var token = await new LoginService().Login(new LoginRequestViewModel()
                {
                    user_nome = Preferences.Get("Username", ""),
                    user_accessKey = Preferences.Get("Password", ""),
                });

                URL = $"{URL}api/Telefone/{idTelefone}";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var resp = await client.DeleteAsync(URL);

                if (!resp.IsSuccessStatusCode)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
