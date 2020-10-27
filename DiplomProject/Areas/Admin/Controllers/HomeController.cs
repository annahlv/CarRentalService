using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DiplomProject.Models;
using Microsoft.AspNetCore.Identity;
using DiplomProject.Models.ViewModels;

namespace DiplomProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IOrderRepository repository;
        private ICarRepository cars;
        public HomeController(IOrderRepository repo, ICarRepository car, UserManager<ApplicationUser> userManager)
        {
            repository = repo;
            cars = car;
            _userManager = userManager;
        }
        public ViewResult Index()
        {
            var model = new AdminPanelViewModel
            {
                Orders = repository.Orders,
                Users = _userManager.Users,
                Cars = cars.Cars
            };
            return View(model);
        }

        //сделать селект лист из состояний
        //[HttpPost]
        //public IActionResult MarkShipped(int orderID)
        //{
        //    Order order = repository.Orders
        //        .FirstOrDefault(o => o.Id == orderID);
        //    if (order != null)
        //    {
        //        order.Shipped = true;
        //        repository.SaveOrder(order);
        //    }
        //    return RedirectToAction(nameof(Index));
        //}
    }
}