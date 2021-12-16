using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NetbullMobile.Model
{
    public class Pedido
    {
        public int pedido_id { get; set; }
        public string pedido_time { get; set; }
        public int pedido_idEndereco { get; set; }
        public decimal pedido_valor { get; set; }
        public int pedido_idPessoa { get; set; }
        public int pedido_idUsuario { get; set; }
        public EnumStatusPedido pedido_status { get; set; }

        [Ignore]
        public virtual List<Item> itens { get; set; }

        [Ignore]
        public Color TagColor
        {
            get
            {
                return Color.FromHex("#44d9e6");
            }
        }

        [Ignore]
        public string ValorFormatado
        {
            get
            {
                return $"R$ {pedido_valor}";
            }
        }

        [Ignore]
        public string TagText
        {
            get
            {
                switch (pedido_status)
                {
                    case EnumStatusPedido.pedido_reservado:
                        return "RESERVADO";
                    case EnumStatusPedido.pedido_acaminho:
                        return "A CAMINHO";
                    case EnumStatusPedido.pedido_cancelado:
                        return "CANCELADO"; 
                    case EnumStatusPedido.pedido_entregue:
                        return "ENTREGUE";
                        default: return string.Empty;
                }
                
            }
        }

    }

    public enum EnumStatusPedido
    {
        pedido_reservado,
        pedido_acaminho,
        pedido_cancelado,
        pedido_entregue
    }  

}
