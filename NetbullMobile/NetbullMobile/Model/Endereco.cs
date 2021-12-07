using System;
using System.Collections.Generic;
using System.Text;

namespace NetbullMobile.Model
{
    public class Endereco
    {
        public int endereco_id { get; set; }
        public string endereco_logradouro { get; set; }
        public int endereco_numero { get; set; }
        public string endereco_complemento { get; set; }

        //ForeignKey Pessoa
        public int endereco_idpessoa { get; set; }

        public bool enviado { get; set; }
    }
}
