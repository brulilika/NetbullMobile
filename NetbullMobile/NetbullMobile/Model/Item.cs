using System;
using System.Collections.Generic;
using System.Text;

namespace NetbullMobile.Model
{
    public class Item
    {
        public int item_id { get; set; }
        public int item_valor { get; set; }
        public int item_qtdproduto { get; set; }
        public int item_idPedido { get; set; }
        public int item_idProduto { get; set; }
    }
}
