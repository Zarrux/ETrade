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
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Registration()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegistrationViewModel model)
        {
            if (model.Password != model.ConfirmPassword)
                ModelState.AddModelError("ConfirmPassword", "should match the password");
            if(ModelState.IsValid)
            {
                var user = MapFromModel(model);
                var repository = new UserRepository();
                repository.Create(user);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        private User MapFromModel(RegistrationViewModel model)
        {
            return new User
            {
                Name = model.Name,
                Surname = model.Surname,
                Age = model.Age,
                Phone = model.Phone,
                Email = model.Email,
                Username = model.Username,
                Password = model.Password
            };
        }
    }
}