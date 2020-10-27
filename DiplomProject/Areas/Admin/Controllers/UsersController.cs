using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DiplomProject.Models;
using Microsoft.AspNetCore.Authorization;
using DiplomProject.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiplomProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("Admin")]
    public class UsersController : Controller
    {
        private UserManager<ApplicationUser> userManager;

        public UsersController(UserManager<ApplicationUser> usrMgr)
        {
            userManager = usrMgr;
        }
        public IActionResult Index()
        {
            var model = new AdminPanelViewModel
            {
                Users = userManager.Users,
            };
            return View(model);
        }

        public ViewResult Edit(string Id) =>
            View(userManager.Users
                .FirstOrDefault(p => p.Id == Id));

        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                await userManager.UpdateAsync(user);
                TempData["message"] = "Изменения сохранены";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(user);
            }
        }

        public ViewResult Create() => View("Edit", new ApplicationUser());

    }
}
