using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB_API.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string username { get; set; }
        public string empname { get; set; }
        public string modid { get; set; }
        public string encodedat { get; set; }
        public string encodedby { get; set; }
    }
}