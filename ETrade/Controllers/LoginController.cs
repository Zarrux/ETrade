using ETrade.Models;
using Store.DAL.Entities;
using Store.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ETrade.Controllers
{
    public class LoginController : BaseController
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
        [HttpGet]
        public ActionResult Logout()
        {
            var httpCookie = HttpContext.Response.Cookies["UserLoginData"];
            if(httpCookie != null)
            {
                httpCookie.Value = string.Empty;

            }
            return RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = UserExists(model);
            if (user != null)
            {
                var ticket = new FormsAuthenticationTicket(1, string.Format("{0} {1}", user.Name, user.Surname),
                    DateTime.Now,
                    DateTime.Now.Add(FormsAuthentication.Timeout),
                    false,
                    user.Id.ToString(),
                    FormsAuthentication.FormsCookiePath);
                var encryptedTicket = FormsAuthentication.Encrypt(ticket);

                var AuthCookie = new HttpCookie("UserLoginData")
                {
                    Value = encryptedTicket,
                    Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
                };
                HttpContext.Response.Cookies.Set(AuthCookie);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "User does not exists");
            return View(model);
        }

        //[HttpGet]
        //public ActionResult Logout()
        //{
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("Login");
        //}
        private User UserExists(LoginViewModel model)
        {
            var repository = new UserRepository();
            return repository.GetAll().FirstOrDefault(u => u.Username == model.UserName && u.Password == model.Password);
        }
    }
}