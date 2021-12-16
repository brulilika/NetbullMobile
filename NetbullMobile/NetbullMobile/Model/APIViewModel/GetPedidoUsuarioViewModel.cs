using System;
using System.Collections.Generic;
using System.Text;

namespace NetbullMobile.Model.APIViewModel
{
    public class GetPedidoUsuarioViewModel
    {

        public IEnumerable<Pedido> pedidos { get; set; }
        public int status { get; set; }
        public object[] error { get; set; }
        
    }

}
