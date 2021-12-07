using System;
using System.Collections.Generic;
using System.Text;

namespace NetbullMobile.Model
{
    public class Telefone
    {
        public int telefone_id { get; set; }
        public int telefone_numero { get; set; }

        //ForeignKey Pessoa
        public int telefone_idPessoa { get; set; }

        public bool enviado { get; set; }
    }
}
