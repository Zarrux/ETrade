using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETrade.Models
{
    public class ProductsModel
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public SortCriteria Criteria { get; set; }
        public SortOrder Order { get; set; }
        public List<SelectListItem> Categories { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}