using System;
using Microsoft.AspNetCore.Mvc;
using TheWorld.ViewModels;
using TheWorld.Services;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;

        public AppController(IMailService service)
        {
            _mailService = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContañtViewModel model)
        {
            if (ModelState.IsValid)
            {
                var email = Startup.Configuration["AppSetting:SiteEmailAdress"];

                    if (string.IsNullOrWhiteSpace(email)) 
                {
                    ModelState.AddModelError("", "Could not send email, configuration problem.");
                }

                if (_mailService.SendMail(email,
                     email,
                     $"Contact Page from {model.Name} ({model.Email})",
                     model.Message))
                {
                    ModelState.Clear();

                    ViewBag.Message = "Mail sent. Thanks!";
                }
            }
            return View();
        }
    }
}
    
