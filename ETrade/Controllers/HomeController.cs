using ETrade.Models;
using Store.DAL.Entities;
using Store.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Newtonsoft.Json;
using System.Configuration;
using System.Net;
using System.Data;
using System.Reflection;


namespace ETrade.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
       public ActionResult Index(string sortOrder, string searchString, string cateSearch,
           string currentFilter, string currentCateFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.CateSortParm = sortOrder == "Category" ? "type_desc" : "Category";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            if(cateSearch != null)
            {
                page = 1;
            }
            else
            {
                cateSearch = currentCateFilter;
            }
            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentCateFilter = cateSearch;

            var products = new ProductRepository().GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper())
                                       || s.Category.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Name_Desc":
                    products = products.OrderByDescending(s => s.Name);
                        break;
                case "Category":
                    products = products.OrderBy(s => s.Category);
                    break;
                case "category_desc":
                    products = products.OrderByDescending(s => s.Category);
                    break;
                case "Price":
                    products = products.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(s => s.Price);
                    break;
                default:
                    products = products.OrderBy(s => s.Name);
                    break;
               

            }
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var res = products.Select(MapToModel);
            return View(res.ToPagedList(pageNumber, pageSize));


        }

      

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProductViewModel());
        }
       // [Authorize]
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            new ProductRepository().Create(MapFromModel(model));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            Product pro = null;
            try
            {
                pro = new ProductRepository().GetById(id);
            }
            catch (Exception e)
            {

                throw;
            }
            return View(MapToModel(pro));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProductViewModel product)
        {
            if(ModelState.IsValid)
                try
                {
                  new   ProductRepository().Update(MapFromModel(product));
                    return RedirectToAction("Index");
                }
                catch (System.Exception e)
                {

                    throw;
                }
           
            return View();
        }
        public ActionResult Delete(int id)
        {
            try
            {
                new ProductRepository().Remove(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
                
            }
            
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