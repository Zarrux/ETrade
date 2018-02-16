using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class EmailViewModel
    {
        [Required]
        [StringLength(50)]

        [Display(Name = "Subject", ResourceType = typeof(Resources.Global))]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Email", ResourceType = typeof(Resources.Global))]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Name", ResourceType = typeof(Resources.Global))]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(250)]
        [Required]
        [Display(Name = "Text", ResourceType = typeof(Resources.Global))]
        public string Text { get; set; }

    }
}