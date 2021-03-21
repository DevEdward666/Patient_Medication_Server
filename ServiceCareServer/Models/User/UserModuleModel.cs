using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB_API.Models
{
    public class UserModuleModel
    {
        [Required]
        public string modid { get; set; }
    }
}