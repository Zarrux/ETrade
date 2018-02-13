using ETrade.Models;
using Newtonsoft.Json;
using Store.DAL.Entities;
using Store.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ETrade.Controllers
{
    public class RegistrationController : BaseController
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

            if(ModelState.IsValid && ValidateCaptcha())
            {
                var user = MapFromModel(model);
                var repository = new UserRepository();
                repository.Create(user);
                return RedirectToAction("Login");
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

        public class CaptchaResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("error-codes")]

            public List<string> ErrorCodes { get; set; }
        }

        private bool ValidateCaptcha()
        {
            var response = Request["g-recaptcha-response"];
            //secret that was generated in key value pair
            string secret = ConfigurationManager.AppSettings["reCAPTCHASecretKey"];
            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);
            //when response is false check for the error message
            if (!captchaResponse.Success)
            {
                if (captchaResponse.ErrorCodes.Count <= 0) return false;
                var error = captchaResponse.ErrorCodes[0].ToLower();
                switch (error)
                {
                    case ("missing-input-secret"):
                        ViewBag.message = "The secret parameter is missing.";
                        break;
                    case ("invalid-input-secret"):
                        ViewBag.message = "The secret parameter is invalid or malformed.";
                        break;
                    case ("missing-input-response"):
                        ViewBag.message = "The response parameter is missing. Please, preceed with reCAPTCHA.";
                        break;
                    case ("invalid-input-response"):
                        ViewBag.message = "The response parameter is invalid or malformed.";
                        break;
                    default:
                        ViewBag.message = "Error occured. Please try again";
                        break;
                }
                return false;
            }
            else
            {
                ViewBag.message = "Valid";
            }
            return true;
        }

    }
}