using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DiplomProject.Models;
using DiplomProject.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace DiplomProject.Areas.Admin.Controllers
{
    [Authorize(Roles="admin")]
    [Area("Admin")]
    public class CrudController : Controller
    {
        private ICarRepository repository;
        public CrudController(ICarRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Cars);
        public ViewResult Edit(int carId) =>
            View(repository.Cars
                .FirstOrDefault(p => p.Id == carId));

        [HttpPost]
        public IActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCar(car);
                TempData["message"] = "Позиция была сохранена";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(car);
            }
        }

        public ViewResult Create() => View("Edit", new Car());

        [HttpPost]
        public IActionResult Delete(int carId)
        {
            Car deletedCar = repository.DeleteCar(carId);
            if (deletedCar != null)
            {
                TempData["message"] = "Позиция была удалена";
            }
            return RedirectToAction("Index");
        }
        //mark as available
        [HttpPost]
        public IActionResult MarkAsAvailable(int id)
        {
            Car car = repository.Cars
                .FirstOrDefault(o => o.Id == id);
            if (car != null)
            {
                if (car.IsAvailable == false)
                {
                    car.IsAvailable = true;
                    repository.SaveCar(car);
                }
                else
                {
                    car.IsAvailable = false;
                    repository.SaveCar(car);
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}