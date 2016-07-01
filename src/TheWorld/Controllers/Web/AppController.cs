using System;
using Microsoft.AspNetCore.Mvc;
using TheWorld.ViewModels;
using TheWorld.Services;
using TheWorld.Models;
using System.Linq;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private WorldContext _context;

        public AppController(IMailService service, WorldContext context)
        {
            _mailService = service;
            _context = context;
        }
        public IActionResult Index()
        {
            var trips = _context.Trips.OrderBy(t => t.Name).ToList();
            return View(trips);
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
    
