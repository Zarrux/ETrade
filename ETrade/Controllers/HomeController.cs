using ETrade.Models;
using Store.DAL.Entities;
using Store.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETrade.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
           
            return View(new ProductRepository().GetAll().Select(MapToModel));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProductViewModel());
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            new ProductRepository().Create(MapFromModel(model));
            return RedirectToAction("Index");
        }

        private Product MapFromModel(ProductViewModel model)
        {
            return new Product
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Category = model.Category,
                Active = model.Active,
                Description = model.Description
            };

        }
        private ProductViewModel MapToModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                Active = product.Active,
                Description = product.Description
            };
        }
    }
}