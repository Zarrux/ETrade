using ETrade.ServiceReference1;
using Store.DAL.Entities;
using Store.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ETrade.Controllers
{
    [Authorize]
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
        public List<Product> GetProducts()
        {
            return new  ProductRepository().GetAll().ToList();
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

        [HttpGet]
        public string GetGeoByIP ()
        {
            string clientAddress = HttpContext.Current.Request.UserHostAddress;
            GeoIP.GeoIPService service = new GeoIP.GeoIPService();
            GeoIP.GeoIP output = service.GetGeoIP(clientAddress.Trim());
            var r = output.CountryName;
            return string.IsNullOrEmpty(r) ? "Undefined" : r;
        }
    }
}
