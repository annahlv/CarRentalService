using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DiplomProject.Models;
using DiplomProject.ViewModels;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace DiplomProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IFeedbackRepository repo;
        private INotificationRepository notificationrepo;
        public HomeController(ILogger<HomeController> logger, IFeedbackRepository repository, INotificationRepository notifications)
        {
            _logger = logger;
            repo = repository;
            notificationrepo = notifications;
        }
        
        
        public IActionResult Index()
        {            
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult Single()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendFeedback(string email, string user_message)
        {
            if (ModelState.IsValid)
            {
                Feedback message = new Feedback();
                message.Email = email;
                message.Text = user_message;
                repo.SaveFeedback(message);
                var notification = new Notification
                {
                    Heading = "Новое сообщение",
                    Text = $"Новое сообщение от {message.Email}: {message.Text}".ToString()
                };
                notificationrepo.Create(notification);
            }
            
            return RedirectToAction(nameof(Index));
        }

    }
}