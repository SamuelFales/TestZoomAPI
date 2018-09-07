using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApiZoom.JWT
{
    public class Header
    {
        public Header()
        {
            alg = "HS256";
            typ = "JWT";
        }
        public string alg { get; set; }
        public string typ { get; set; }
    }
}