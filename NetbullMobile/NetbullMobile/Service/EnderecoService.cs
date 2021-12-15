using NetbullMobile.Model;
using NetbullMobile.Model.APIViewModel;
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
    public class EnderecoService : BaseService
    {
        public EnderecoService()
        {

        }

        public async Task<List<Endereco>> BuscaEnderecoPessoa(int id)
        {
            try
            {

                var t = new LoginRequestViewModel()
                {
                    user_nome = Preferences.Get("Username", ""),
                    user_accessKey = Preferences.Get("Password", ""),
                };

                HttpClient client = new HttpClient();
                var token = await new LoginService().Login(new LoginRequestViewModel()
                {
                    user_nome = Preferences.Get("Username", ""),
                    user_accessKey = Preferences.Get("Password", ""),
                });

                URL = $"{URL}api/Endereco/{id}";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var resp = await client.GetAsync(URL);

                if (!resp.IsSuccessStatusCode)
                    return null;

                var enderecos = JsonConvert.DeserializeObject<GetEnderecoReturnViewModel>(resp.Content.ReadAsStringAsync().Result);
                return enderecos.lista.OrderBy(ob=>ob.endereco_id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Endereco> RegistraEnderecoPessoa(Endereco endereco)
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
                    endereco_logradouro = endereco.endereco_logradouro,
                    endereco_numero = endereco.endereco_numero,
                    endereco_complemento = endereco.endereco_complemento,
                    endereco_idpessoa = endereco.endereco_idpessoa
                });;
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                URL = $"{URL}api/Endereco";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var resp = await client.PostAsync(URL, content);

                if (!resp.IsSuccessStatusCode)
                    return null;

                var novoEndereco = JsonConvert.DeserializeObject<Endereco>(resp.Content.ReadAsStringAsync().Result);
                return novoEndereco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Endereco> AtualizaTelefonePessoa(Endereco endereco)
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
                    endereco_logradouro = endereco.endereco_logradouro,
                    endereco_numero = endereco.endereco_numero,
                    endereco_complemento = endereco.endereco_complemento
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                URL = $"{URL}api/Endereco/{endereco.endereco_id}";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var resp = await client.PutAsync(URL, content);

                if (!resp.IsSuccessStatusCode)
                    return null;

                var novoEndereco = JsonConvert.DeserializeObject<Endereco>(resp.Content.ReadAsStringAsync().Result);
                return novoEndereco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeletaTelefonesPessoa(int idEndereco)
        {
            try
            {
                HttpClient client = new HttpClient();
                var token = await new LoginService().Login(new LoginRequestViewModel()
                {
                    user_nome = Preferences.Get("Username", ""),
                    user_accessKey = Preferences.Get("Password", ""),
                });

                URL = $"{URL}api/Endereco/{idEndereco}";
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
