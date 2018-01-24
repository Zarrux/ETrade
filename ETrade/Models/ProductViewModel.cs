using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public string Category { get; set; }
        public string Active { get; set; }
        public string Description { get; set; }
    }
}