using ETrade.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ETrade.Controllers
{
    public class ProductController : ApiController
    {

        private static List<string> _products { get; set; }
        private static List<string> products
        {
            get
            {
                if (_products == null)
                    _products = new List<string>();
                return _products;
            }
        }
        [HttpGet]
        public bool AddProduct(string name)
        {
            return new ServiceClient().AddProduct(name);
        }
        [HttpGet]
        public string[] GetProducts()
        {
            return new ServiceClient().GetProducts();
        }
        public string GetString()
        {
            return "Heelo";
        }
        [HttpGet]
        public string TestSoap(int value)
        {
            return new ServiceClient().GetData(value);
        }
    }
}
