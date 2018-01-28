using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("User Name / Login")]

        public string UserName { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}