﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NetbullMobile.Model
{
    public class Pedido
    {
        public string codigo { get; set; }
        public string valorTotal { get; set; }
        public bool efetivado { get; set; }

        [Ignore]
        public Color TagColor
        {
            get
            {
                if (efetivado)
                    return Color.FromHex("#770494");
                return Color.FromHex("#a8c030");
            }
        }

        [Ignore]
        public string TagText
        {
            get
            {
                if (efetivado)
                    return "EFETIVADO";
                return "PROCESSO";
            }
        }

    }
}