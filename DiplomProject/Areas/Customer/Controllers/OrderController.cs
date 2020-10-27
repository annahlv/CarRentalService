using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiplomProject.Models;
using DiplomProject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DiplomProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IOrderRepository repository;
        private ICarRepository cars;
        private INotificationRepository notificationrepo;

        public OrderController(IOrderRepository repoService, 
                                ICarRepository carService, 
                                UserManager<ApplicationUser> userManager, 
                                INotificationRepository notificationRepository)
        {
            repository = repoService;
            cars = carService;
            _userManager = userManager;
            notificationrepo = notificationRepository;
        }


        public async Task<IActionResult> Checkout(int id)
        {
            var model = new CheckoutViewModel
            {
                Car = cars.Cars.FirstOrDefault(p => p.Id == id),
                User = await _userManager.GetUserAsync(HttpContext.User),
                
            };
            model.Name = model.User.Name;
            model.Surname = model.User.Surname;
            model.Phone = model.User.Phone;
            model.Address = model.User.Address;
            model.City = model.User.City;
            model.StartRent = DateTime.Now;
            model.EndRent = model.StartRent.AddMonths(6);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(int id, CheckoutViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                Car orderedCar = cars.Cars.FirstOrDefault(p => p.Id == id);
                var user = await _userManager.GetUserAsync(HttpContext.User);
                Order order = new Order();
                
                if (orderedCar != null)
                {   
                    if (user != null)
                    {
                        order.Car = orderedCar;
                        order.OrderPlaced = DateTime.Now;
                        order.CarId = orderedCar.Id;
                        order.UserId = user.Id;
                        order.StateId = 1;
                        order.StartRent = model.StartRent;
                        order.EndRent = model.EndRent;
                        user.Name = model.Name;
                        user.Surname = model.Surname;
                        user.Phone = model.Phone;
                        user.Address = model.Address;
                        user.City = model.City;
                        var result = await _userManager.UpdateAsync(user);
                        repository.SaveOrder(order);
                        var notification = new Notification
                        {
                            Heading = "Новый заказ",
                            Text = $"Пользователь {user.Name + ' ' + user.Surname} забронировал {orderedCar.Brand + ' ' + orderedCar.Model}".ToString()
                        };
                        notificationrepo.Create(notification);
                        return RedirectToAction(nameof(Completed));
                    }
                    else
                    {
                        return View(model);
                    }
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }

        }

        public ViewResult Completed()
        {
            return View();
        }
    }
}