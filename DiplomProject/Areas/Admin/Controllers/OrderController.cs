using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DiplomProject.Models;
using DiplomProject.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DiplomProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("Admin")]
    public class OrderController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private IOrderRepository repository;
        private ICarRepository cars;
        private IOrderStateRepository states;
        private INotificationRepository message;
        public OrderController(IOrderRepository repo, ICarRepository car, UserManager<ApplicationUser> userManager, IOrderStateRepository stateManager, INotificationRepository notificationService)
        {
            repository = repo;
            cars = car;
            _userManager = userManager;
            states = stateManager;
            message = notificationService;
        }
        public ViewResult Index()
        {
            var model = new AdminPanelViewModel {
                Orders = repository.Orders,
                Users = _userManager.Users,
                Cars = cars.Cars,
                States = states.States
            };
            SelectList orderStates = new SelectList(states.States, "Id", "State");
            ViewBag.States = orderStates;
            return View(model);
        }

        //public async Task<IActionResult> ChangeState(int id)
        //{
        //    Order order = repository.Orders.FirstOrDefault(p => p.Id == id);
        //    order.State = states.States.FirstOrDefault(p => p.State == State);
        //    repository.SaveOrder(order);
        //    return RedirectToAction("Index");
        //}
        public IActionResult Edit(int id)
        {
            
            Order order = repository.Orders.Where(p => p.Id == id).FirstOrDefault();
            OrderViewModel model = new OrderViewModel
            {
                Order = order,
                State = states.States.FirstOrDefault(p => p.Id == order.StateId).State,
                StateId = order.StateId
            };
            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(OrderViewModel model)
        {
            var state = Request.Form.FirstOrDefault(p => p.Key == "state").Value;
            var id = Int32.Parse(state);
            Order order = repository.Orders.FirstOrDefault(p => p.Id == model.Order.Id);
            if (ModelState.IsValid)
            {
                order.StateId = id;
                order.StartRent = model.Order.StartRent;
                order.EndRent = model.Order.EndRent;
                if (id == 2)
                {
                    order.OrderApproved = DateTime.Now;
                    var notification = new Notification
                    {
                        Heading = "Ваш заказ подтвержден",
                        Text = $"Ваш заказ №{order.Id} был подтвержден {order.OrderApproved}. Ожидайте звонка администратора.".ToString()
                    };
                    message.Create(notification);
                    message.Assign(notification, order.UserId);
                }
                if (id == 3)
                {
                    var notification = new Notification
                    {
                        Heading = "Ваш заказ отклонен",
                        Text = $"Ваш заказ №{order.Id} был отклонен. Уточнить детали можно, написав на нашу почту: info@dexcar.by".ToString()
                    };
                    var user = new NotificationApplicationUser
                    {
                        Notification = notification,
                        UserId = order.UserId
                    };
                    message.Create(notification);
                    message.Assign(notification, order.UserId);
                }                
                repository.UpdateOrder(order);
                TempData["message"] = "Заказ был изменен";
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

    }
}