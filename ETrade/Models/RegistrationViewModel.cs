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
        [DisplayName("First Name")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string Surname { get; set; }
        [DisplayName("Your Age")]
        //[Range(16,99)]
        [Required]
        public DateTime Age { get; set; }
        [DisplayName("Phone Number")]
        [Required]
        public string Phone { get; set; }
        [DisplayName("Email Address")]
        [Required]
        public string Email { get; set; }
        [DisplayName("Username")]
        [Required]
        public string Username { get; set; }
        [DisplayName("Password")]
        [Required]
        public string Password { get; set; }

        [DisplayName("Confrim Password")]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}