using System;
using System.Collections.Generic;
using System.Text;

namespace NetbullMobile.Model
{
    public class Pessoa
    {
        public int pessoa_id { get; set; }
        public int pessoa_documento { get; set; }
        public string pessoa_nome { get; set; }
        public EnumTipoPessoa pessoa_tipopessoa { get; set; }
        public bool enviado { get; set; }
    }

    public enum EnumTipoPessoa
    {
        PessoaJuridica = 0,
        PessoaFisica = 1
    }
}
