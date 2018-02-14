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
       
       

        //[Display(Name = "UserName / Login", ResourceType = typeof(Resources.Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources.Resources),
        //      ErrorMessageResourceName = "UserNameRequired")]
        //[StringLength(50, ErrorMessageResourceType = typeof(Resources.Resources),
        //              ErrorMessageResourceName = "UserNameLong")]

        public string UserName { get; set; }

       

        //[Display(Name = "Password", ResourceType = typeof(Resources.Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources.Resources),
        //      ErrorMessageResourceName = "PasswordRequired")]
        //[StringLength(50, ErrorMessageResourceType = typeof(Resources.Resources),
        //              ErrorMessageResourceName = "PasswordLong")]

        public string Password { get; set; }
    }
}