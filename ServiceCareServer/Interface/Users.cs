﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_API.Interface
{
    public class Users
    {

        public class getselectedusers
        {
            public string username { get; set; }
            public string empanme { get; set; }
        }

        public class gettableusers
        {
            public string fullanme { get; set; }
            public string username { get; set; }
            public string accnt_type { get; set; }
            public string redirectto { get; set; }
            public string type { get; set; }
        }
      
    }
}
