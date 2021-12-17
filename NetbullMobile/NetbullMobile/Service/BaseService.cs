using System;
using System.Collections.Generic;
using System.Text;

namespace NetbullMobile.Service
{
    public class BaseService
    {
        public string URL { get; set; }

        public BaseService()
        {
            URL = "http://192.168.0.21:4200/";
        }
    }
}
