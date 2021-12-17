using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NetbullMobile.Model.APIViewModel
{
    public class GetItemReturnViewModel
    {
        public HttpStatusCode status { get; set; }
        public IEnumerable<Item> itens { get; set; }
        public object[] error { get; set; }
    }
}
