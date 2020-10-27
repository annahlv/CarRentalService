using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiplomProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using DiplomProject.Models;
using DiplomProject.Models.ViewModels;
using DiplomProject.Areas.Admin.Controllers;

namespace DiplomProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class ProfileController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private IUserValidator<ApplicationUser> userValidator;
        private IPasswordValidator<ApplicationUser> passwordValidator;
        private IPasswordHasher<ApplicationUser> passwordHasher;
        private IOrderRepository orderRepo;
        private IOrderStateRepository states;
        private ICarRepository carRepo;
        private INotificationRepository notificationRepo;

        public ProfileController(UserManager<ApplicationUser> usrMgr, 
                                 IUserValidator<ApplicationUser> userValid, 
                                 IPasswordValidator<ApplicationUser> passValid, 
                                 IPasswordHasher<ApplicationUser> passwordHash,
                                 IOrderRepository orderService,
                                 INotificationRepository notification,
                                 ICarRepository carService,
                                 IOrderStateRepository stateService)
        {
            userManager = usrMgr;
            userValidator = userValid;
            passwordValidator = passValid;
            passwordHasher = passwordHash;
            orderRepo = orderService;
            notificationRepo = notification;
            carRepo = carService;
            states = stateService;
        }
        public async Task<IActionResult> Index(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            return View(user);
        }

        public async Task<IActionResult> Orders(string id, OrderViewModel model)
        {
            ApplicationUser user = await userManager.GetUserAsync(HttpContext.User);
            id = user.Id;
            model = new OrderViewModel
            {
                Orders = orderRepo.Orders.Where(p => p.UserId == id),
                Cars = carRepo.Cars,
                States = states.States
            };
            return View(model);
        }

        public async Task<IActionResult> Notifications(NotificationViewModel model)
        {
            ApplicationUser user = await userManager.GetUserAsync(HttpContext.User);
            string id = user.Id;
            model = new NotificationViewModel
            {
                UserNotifications = notificationRepo.GetUserNotifications(id).AsEnumerable()
            };
            return View(model);
        }

        public async Task<IActionResult> EditProfile(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            } else
            {
                return RedirectToAction("Index");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string email, string password)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;
                IdentityResult validEmail = await userValidator.ValidateAsync(userManager, user);
                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }
                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager, user, password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = passwordHasher.HashPassword(user, password);
                    } else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }
                if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded && password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    } else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            } else
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }
            return View(user);
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}