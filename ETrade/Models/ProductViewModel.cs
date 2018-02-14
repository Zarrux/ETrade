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
        //[Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources.Resources),
        //    ErrorMessageResourceName = "NameRequired")]
        //[StringLength(255, ErrorMessageResourceType = typeof(Resources.Resources),
        //            ErrorMessageResourceName = "NameLong")]
        public string Name { get; set; }

        //[Display(Name = "Price", ResourceType = typeof(Resources.Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources.Resources),
        //   ErrorMessageResourceName = "PriceRequired")]
        //[Range(0, 9999999, ErrorMessageResourceType = typeof(Resources.Resources),
        //           ErrorMessageResourceName = "PriceMaximum")]
        public Decimal Price { get; set; }

        //[Display(Name = "Category", ResourceType = typeof(Resources.Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources.Resources),
        //  ErrorMessageResourceName = "CategoryRequired")]
        //[StringLength(50, ErrorMessageResourceType = typeof(Resources.Resources),
        //          ErrorMessageResourceName = "Category")]
        public string Category { get; set; }

        //[Display(Name = "Active", ResourceType = typeof(Resources.Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources.Resources),
        // ErrorMessageResourceName = "ActiveRequired")]
        //[StringLength(50, ErrorMessageResourceType = typeof(Resources.Resources),
        //         ErrorMessageResourceName = "Active")]
        public bool Active { get; set; }

        //[Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources.Resources),
        //ErrorMessageResourceName = "DescriptionRequired")]
        //[StringLength(255, ErrorMessageResourceType = typeof(Resources.Resources),
        //        ErrorMessageResourceName = "Description")]
        public string Description { get; set; }
    }
}