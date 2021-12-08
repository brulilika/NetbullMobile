using System;
using System.Collections.Generic;
using System.Text;

namespace NetbullMobile.Model.APIViewModel
{
    public class RegisterReturnViewModel
    {
        public int user_id { get; set; }
        public string user_nome { get; set; }
        public string user_email { get; set; }
        public string user_accessKey { get; set; }
    }
}
