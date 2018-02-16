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
using ETrade.Helper;
using System.IO;

namespace ETrade.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private Store.DAL.Entities.Log log = new Store.DAL.Entities.Log()
        {
            Controller = "Base"
        };
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

            try
            {
                log.Action = "Index";
                log.IPAddress = Request.UserHostAddress.ToString();
                log.Method = "Get";
                log.User = User.Identity.Name;

                //products = SearchResult(searchString, cateSearch, products);
                //products = Sort(sortOrder, products);

                LogHelper.Info(log);
            }
            catch (Exception e)
            {
                log.Action = log.Action + "\n" + e.ToString();
                LogHelper.Error(log);
                
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper())
                                       || s.Category.ToUpper().Contains(searchString.ToUpper()));
            }
            //switch (sortOrder)
            //{
            //    case "Name_Desc":
            //        products = products.OrderByDescending(s => s.Name);
            //            break;
            //    case "Category":
            //        products = products.OrderBy(s => s.Category);
            //        break;
            //    case "category_desc":
            //        products = products.OrderByDescending(s => s.Category);
            //        break;
            //    case "Price":
            //        products = products.OrderBy(s => s.Price);
            //        break;
            //    case "price_desc":
            //        products = products.OrderByDescending(s => s.Price);
            //        break;
            //    default:
            //        products = products.OrderBy(s => s.Name);
            //        break;
            //}

            products = Sort(products, sortOrder);
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var res = products.Select(MapToModel);
            return View(res.ToPagedList(pageNumber, pageSize));


        }

        public IQueryable<Product> Sort(IQueryable<Product> products, string sortOrder)
        {
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

            return products;

        }
        
       

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                log.Action = "Create";
                log.IPAddress = Request.UserHostAddress.ToString();
                log.Method = "Get";
                log.User = User.Identity.Name;
                LogHelper.Info(log);
            }
            catch (Exception e)
            {
                log.Action = log.Action + "\n" + e.ToString();
                LogHelper.Error(log);
            }
            return View(new ProductViewModel());
        }
       // [Authorize]
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            log.Action = "Create";
            log.IPAddress = Request.UserHostAddress.ToString();
            log.Method = "Get";
            log.User = User.Identity.Name;

            try
            {
                LogHelper.Info(log);
             
            }
            catch (System.Exception e)
            {
                log.Action = log.Action + "\n" + e.ToString();
                LogHelper.Error(log);
                throw;
            }
            new ProductRepository().Create(MapFromModel(model));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateFromFile()
        {
            try
            {
                log.Action = "CreateFromFile";
                log.IPAddress = Request.UserHostAddress.ToString();
                log.Method = "Get";
                log.User = User.Identity.Name;
                LogHelper.Info(log);
            }
            catch (Exception e)
            {
                log.Action = log.Action + "\n" + e.ToString();
                LogHelper.Error(log);
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateFromFile(FormCollection formCollection)
        {
            log.Action = "CreateFromFile";
            log.IPAddress = Request.UserHostAddress.ToString();
            log.Method = "Get";
            log.User = User.Identity.Name;

            var file = Request.Files["fileToImport"];
            if (file == null)
            {
                ViewBag.Result = "File is missing";
                log.Action = log.Action + "\n File is missing";
                LogHelper.Error(log);
            }

            var products = new List<ProductViewModel>();
            using (var reader = new StreamReader(file.InputStream))
            {
                string line;
                try
                {

                    while ((line = reader.ReadLine()) != null)
                    {

                        var product = new ProductViewModel();

                        try
                        {
                            var tokens = line.Split('|');
                            product.Name = tokens[0];
                            product.Price = decimal.Parse(tokens[1]);
                            product.Category = tokens[2];
                            product.Active = bool.Parse(tokens[3]);
                            product.Description = tokens[4];

                            products.Add(product);
                            var p = MapFromModel(product);
                           new ProductRepository().Create(p);
                        }
                        catch (Exception)
                        {
                            ViewBag.Result = "Incorrect file content format in line:\n" + line;
                            return View();
                        }
                    }
                }
                catch (Exception e)
                {
                    log.Action = log.Action + "\n" + e.ToString();
                    LogHelper.Error(log);
                }
            }

            ViewBag.Products = products;
            LogHelper.Info(log);
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            log.Action = "Update";
            log.IPAddress = Request.UserHostAddress.ToString();
            log.Method = "Get";
            log.User = User.Identity.Name;
            Product pro = null;
            try
            {
                LogHelper.Info(log);
                pro = new ProductRepository().GetById(id);
            }
            catch (System.Exception e)
            {
                log.Action = log.Action + "\n" + e.ToString();
                LogHelper.Error(log);
                throw;
            }
            return View(MapToModel(pro));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProductViewModel product)
        {
            log.Action = "Update";
            log.IPAddress = Request.UserHostAddress.ToString();
            log.Method = "Get";
            log.User = User.Identity.Name;

            if (ModelState.IsValid)
                try
                {
                  new   ProductRepository().Update(MapFromModel(product));
                    LogHelper.Info(log);
                    return RedirectToAction("Index");
                }
                catch (System.Exception e)
                {
                    log.Action = log.Action + "\n" + e.ToString();
                    LogHelper.Error(log);
                    throw;
                }
            log.Action = log.Action + "\nInvalid Model State";
            LogHelper.Error(log);
            return View();
        }
        public ActionResult Delete(int id)
        {
            log.Action = "Delete";
            log.IPAddress = Request.UserHostAddress.ToString();
            log.Method = "Get";
            log.User = User.Identity.Name;

            try
            {
                new ProductRepository().Remove(id);
                LogHelper.Info(log);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                log.Action = log.Action + "\n" + e.ToString();
                LogHelper.Error(log);
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