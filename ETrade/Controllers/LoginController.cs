using ETrade.Models;
using Store.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETrade.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid && UserExists(model))
                return RedirectToAction("Index");
            ModelState.AddModelError("", "User does not exists");
            return View(model);
        }

        private bool UserExists(LoginViewModel model)
        {
            var repository = new UserRepository();
            return repository.GetAll().Any(u => u.Username == model.UserName && u.Password == model.Password);
        }
    }
}