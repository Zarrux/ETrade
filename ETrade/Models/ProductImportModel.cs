using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class ProductImportModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
    }
}