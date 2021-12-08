using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NetbullMobile.Model
{
    public class LoginReturnViewModel
    {
        public HttpStatusCode status { get; set; }
        public string Token { get; set; }
    }
}
