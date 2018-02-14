using ETrade.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETrade.Controllers
{
    public class ProductImportController : Controller
    {
        // GET: ProductImport
        public ActionResult ProductImport()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProductImport(FormCollection formCollection)
        {
            var file = Request.Files["fileToImport"];

            if(file == null)
            {
                ViewBag.Result = "File is missing";
                return View();
            }

            var products = new List<ProductImportModel>();
            using (var reader = new StreamReader(file.InputStream))
            {
                string line;
                while((line = reader.ReadLine()) !=null )
                {
                    var tokens = line.Split('|');
                    var product = new ProductImportModel();

                    product.Name = tokens[0];
                    product.Price = decimal.Parse(tokens[1]);
                    product.Category = tokens[2];
                    product.Active = bool.Parse( tokens[3]);
                    product.Description = tokens[4];

                    products.Add(product);
                }
            }
            ViewBag.Products = products;
            return View();
        }
    }
}