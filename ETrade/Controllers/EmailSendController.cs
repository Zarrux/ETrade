using ETrade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ETrade.Controllers
{
    [Authorize]
    public class EmailSendController : Controller
    {
        // GET: EmailSend
        public ActionResult EmailSend()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmailSend(EmailViewModel model)
        {
            if(ModelState.IsValid)
            {
                @ViewBag.EmailSendingResult = "Email sent successfully";
                try
                {
                    var mailMessage = new MailMessage("wad.2016-2017@yandex.ru", "zsharipov@students.wiut.uz", "new mail from" + model.Name, model.Text);
                    var smtpClient = new SmtpClient("smtp.yandex.ru", 25);
                    smtpClient.Credentials = new NetworkCredential("wad.2016-2017", "wad.2016-2017wiut");
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mailMessage);
                }
                catch (Exception)
                {
                    @ViewBag.EmailSendingResult = "Failed to send email";
                }
            }
            return View(model);
        }
    }
}