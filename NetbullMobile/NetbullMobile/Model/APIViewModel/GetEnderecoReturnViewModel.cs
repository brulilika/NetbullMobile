using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NetbullMobile.Model.APIViewModel
{
    public class GetEnderecoReturnViewModel
    {
        public HttpStatusCode status { get; set; }
        public IEnumerable<Endereco> lista { get; set; }
    }
}
