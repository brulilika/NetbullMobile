using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NetbullMobile.Model.APIViewModel
{
    public class GetTelefoneReturnViewModel
    {
        public IEnumerable<Telefone> telefones { get; set; }
        public HttpStatusCode status { get; set; }
        public object[] error { get; set; }
    }


}
