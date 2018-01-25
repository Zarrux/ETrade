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
        public ActionResult Index(string category, string name,
                                        SortCriteria? criteria, SortOrder? order)
        {
            var model = new ProductsModel
            {
                Category = category,
                Name = name,
                Criteria = criteria ?? SortCriteria.Name,
                Order = order ?? SortOrder.ASC
            };

            var products = new ProductRepository().GetAll();
            model.Categories =
                products.Select(p => p.Category).Distinct().Select(c => new SelectListItem { Value = c, Text = c }).ToList();

            if (!string.IsNullOrEmpty(category))
                products = products.Where(p => p.Category.Equals(category));

            if (!string.IsNullOrEmpty(name))
                products = products.Where(p => p.Name.ToLower().Contains(name.ToLower()));

            if(criteria == SortCriteria.Price)
            {
                if (order == SortOrder.DESC)
                    products = products.OrderByDescending(p => p.Price);
                else
                    products = products.OrderBy(p => p.Price);
            }
            else
            {
                if (order == SortOrder.DESC)
                    products = products.OrderByDescending(p => p.Name);
                else
                    products = products.OrderBy(p => p.Name);
            }
            model.Products = products.Select(MapToModel).ToList();

            return View(model);
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