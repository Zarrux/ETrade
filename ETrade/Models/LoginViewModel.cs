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




        [Required(ErrorMessage = "The Username field is required.")]

        [Display(Name = "Username", ResourceType = typeof(Resources.Global))]

        public string UserName { get; set; }




        [Required(ErrorMessage = "The Password field is required.")]
       
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Global))]
        public string Password { get; set; }
    }
}