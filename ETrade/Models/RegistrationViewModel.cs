using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace ETrade.Models
{
    public class RegistrationViewModel
    { 
        public int Id { get; set; }


        [Required(ErrorMessage ="the name is required")]
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Global))]
        [StringLength(50)]
        public string Name { get; set; }

       
        [Required(ErrorMessage = "The surname field is required.")]
       
        [StringLength(50)]
        [Display(Name = "Surname", ResourceType = typeof(Resources.Global))]
        public string Surname { get; set; }

        [Required(ErrorMessage = "The Age++ field is required.")]
        
        [Range(17,120)]
        [Display(Name = "Age", ResourceType = typeof(Resources.Global))]

        public Int32 Age { get; set; }

        [Required(ErrorMessage = "The Phone field is required.")]
        
        [Display(Name = "Phone", ResourceType = typeof(Resources.Global))]
        public string Phone { get; set; }

 
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
        [Display(Name = "Email", ResourceType = typeof(Resources.Global))]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Username field is required.")]
        
        [Display(Name = "Username", ResourceType = typeof(Resources.Global))]
        public string Username { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Global))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",  ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}