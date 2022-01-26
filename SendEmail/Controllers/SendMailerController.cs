using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
//using System.Web.Mvc;

namespace SendEmail.Controllers
{
    public class SendMailerController : Controller
    {
        //  
        // GET: /SendMailer/   
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendEmail.Models.MailModel _objModelMail)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("email", "password"); // Enter sender's User name and password  
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return RedirectToAction();
            }
            else
            {
                return View();
            }
        }
    }
}
