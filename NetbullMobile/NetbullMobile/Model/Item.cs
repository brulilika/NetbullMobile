using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetbullMobile.Model
{
    public class Item
    {
        public int item_id { get; set; }
        public decimal item_valor { get; set; }
        public int item_qtdproduto { get; set; }
        public int item_idPedido { get; set; }
        public int item_idProduto { get; set; }

        [Ignore]
        public string QuantidadeFormatado
        {
            get
            {
                return $"x{item_qtdproduto}";
            }
        }

        [Ignore]
        public string ValorFormatado
        {
            get
            {
                return $"R$ {item_valor}";
            }
        }
    }
}
