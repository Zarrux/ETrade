using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class RegistrationViewModel
    { 
        public int Id { get; set; }

        //[Display(Name = "FirstName", ResourceType = typeof(Resources.Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources.Resources),
        //      ErrorMessageResourceName = "FirstNameRequired")]
        //[StringLength(50, ErrorMessageResourceType = typeof(Resources.Resources),
        //              ErrorMessageResourceName = "FirstNameLong")]
        public string Name { get; set; }

        //[Display(Name = "Surname", ResourceType = typeof(Resources.Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources.Resources),
        //        ErrorMessageResourceName = "SurnameRequired")]
        //[StringLength(50, ErrorMessageResourceType = typeof(Resources.Resources),
        //                ErrorMessageResourceName = "SurnameLong")]
        public string Surname { get; set; }


        //[Display(Name = "Age", ResourceType = typeof(Resources.Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources.Resources),
        //      ErrorMessageResourceName = "AgeRequired")]
        //[Range(17, 130, ErrorMessageResourceType = typeof(Resources.Resources),
        //           ErrorMessageResourceName = "AgeRange")]
        public Int32 Age { get; set; }

        //[Display(Name = "Phone", ResourceType = typeof(Resources.Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources.Resources),
        //        ErrorMessageResourceName = "PhoneRequired")]
        //[StringLength(50, ErrorMessageResourceType = typeof(Resources.Resources),
        //                ErrorMessageResourceName = "PhoneLong")]
        public string Phone { get; set; }

        //[Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources.Resources),
        //      ErrorMessageResourceName = "EmailRequired")]
        //[RegularExpression(".+@.+\\..+", ErrorMessageResourceType = typeof(Resources.Resources),
        //                             ErrorMessageResourceName = "EmailInvalid")]
        public string Email { get; set; }

        //[Display(Name = "Username", ResourceType = typeof(Resources.Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources.Resources),
        //       ErrorMessageResourceName = "UsernameRequired")]
        //[StringLength(50, ErrorMessageResourceType = typeof(Resources.Resources),
        //               ErrorMessageResourceName = "UsernameLong")]
        public string Username { get; set; }

        //[Display(Name = "Password", ResourceType = typeof(Resources.Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources.Resources),
        //       ErrorMessageResourceName = "PasswordRequired")]
        //[StringLength(50, ErrorMessageResourceType = typeof(Resources.Resources),
        //               ErrorMessageResourceName = "PasswordLong")]
        public string Password { get; set; }

        //[Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources.Resources),
        //      ErrorMessageResourceName = "ConfirmPasswordRequired")]
        //[StringLength(50, ErrorMessageResourceType = typeof(Resources.Resources),
        //              ErrorMessageResourceName = "ConfirmPasswordLong")]
        public string ConfirmPassword { get; set; }
    }
}