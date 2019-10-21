using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SendgridEmailInAspNetCore.Models;
using SendgridEmailInAspNetCore.Services;

namespace SendgridEmailInAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSender _emailSender;

        public HomeController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                var emails = new List<string>();
                emails.Add(model.Email);
                await _emailSender.SendEmailAsync(emails, model.Subject, model.Message);
            }
            return View(model);
        }
    }
}
