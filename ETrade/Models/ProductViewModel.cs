using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Resources;
using System.Diagnostics;

namespace ETrade.Models
{
    public class ProductViewModel
    {
    
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]

        [StringLength(50)]
        [Display(Name = "Name", ResourceType = typeof(Resources.Global))]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        [Display(Name = "Price", ResourceType = typeof(Resources.Global))]
        [Range(1,9999999)]

        public Decimal Price { get; set; }

        [Required(ErrorMessage = "The Category field is required.")]
        [StringLength(50)]
        [Display(Name = "Category", ResourceType = typeof(Resources.Global))]
        public string Category { get; set; }

        [Required(ErrorMessage = "The Active field is required.")]
      
        [Display(Name = "Active", ResourceType = typeof(Resources.Global))]
        public bool Active { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(50)]
        [Display(Name = "Description", ResourceType = typeof(Resources.Global))]
        public string Description { get; set; }
    }
}