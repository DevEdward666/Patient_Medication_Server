using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_API.Interface
{
    public class Patients
    {
        public class info
        {
            public string patno { get; set; }
            public string stock { get; set; }
        }
        public class users
        {
            public string user { get; set; }
            public int limit { get; set; }
        }
        public class details
        {
            public string patno { get; set; }
            public string chargeslip { get; set; }
            public string stockcode { get; set; }
          
        }
        public class bydate
        {
            public string year { get; set; }
            public string month { get; set; }
            public string dayofmonth { get; set; }

        }
    }
}