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
    public class PedidoService : BaseService
    {
        public async Task<List<Pedido>> BuscaPedidos()
        {
            try
            {
                HttpClient client = new HttpClient();

                var token = await new LoginService().Login(new LoginRequestViewModel()
                {
                    user_nome = Preferences.Get("Username", ""),
                    user_accessKey = Preferences.Get("Password", ""),
                });

                URL = $"{URL}api/Pedido/Usuario/{Preferences.Get("Username", "")}";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var resp = await client.GetAsync(URL);

                if (!resp.IsSuccessStatusCode)
                    return null;

                var pedidos = JsonConvert.DeserializeObject<GetPedidoUsuarioViewModel>(resp.Content.ReadAsStringAsync().Result);
                if (pedidos.pedidos != null)
                    return pedidos.pedidos?.ToList();
                else
                    return null;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<Item>> BuscaItensById(int idPedido)
        {
            try
            {
                HttpClient client = new HttpClient();

                var token = await new LoginService().Login(new LoginRequestViewModel()
                {
                    user_nome = Preferences.Get("Username", ""),
                    user_accessKey = Preferences.Get("Password", ""),
                });

                URL = $"{URL}api/Item/{idPedido}";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var resp = await client.GetAsync(URL);

                if (!resp.IsSuccessStatusCode)
                    return null;

                var item = JsonConvert.DeserializeObject<GetItemReturnViewModel>(resp.Content.ReadAsStringAsync().Result);
                if (item.itens != null)
                    return item.itens?.OrderBy(o=>o.item_id).ToList();
                else
                    return null;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
