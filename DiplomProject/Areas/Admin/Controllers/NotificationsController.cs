using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomProject.Models;
using DiplomProject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiplomProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("Admin")]
    public class NotificationsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IOrderRepository repository;
        private ICarRepository cars;
        private INotificationRepository notificationRepo;
        public NotificationsController(IOrderRepository repo, ICarRepository car, UserManager<ApplicationUser> userManager, INotificationRepository notification)
        {
            repository = repo;
            cars = car;
            _userManager = userManager;
            notificationRepo = notification;
        }
        public IActionResult Index()
        {
            var model = new AdminPanelViewModel
            {
                Orders = repository.Orders,
                Users = _userManager.Users,
                Cars = cars.Cars,
                Notifications = notificationRepo.GetAllNotifications().OrderByDescending(p => p.Id)
            };
            return View(model);
        }
    }
}