using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NetbullMobile.Model
{
    public class Pessoa
    {
        public int pessoa_id { get; set; }
        public int pessoa_documento { get; set; }
        public string pessoa_nome { get; set; }
        public EnumTipoPessoa pessoa_tipopessoa { get; set; }
        public bool enviado { get; set; }

        [Ignore]
        public Color TagColor
        {
            get
            {
                if (pessoa_tipopessoa == EnumTipoPessoa.PessoaFisica)
                    return Color.FromHex("#44d9e6");
                return Color.FromHex("#44d9e6");
            }
        }

        [Ignore]
        public string TagText
        {
            get
            {
                if (pessoa_tipopessoa == EnumTipoPessoa.PessoaFisica)
                    return "P.F.";
                return "P.J.";
            }
        }
    }

    public enum EnumTipoPessoa
    {
        PessoaJuridica = 0,
        PessoaFisica = 1
    }

    
}
