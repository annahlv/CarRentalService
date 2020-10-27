using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using DiplomProject.Models;
using DiplomProject.Models.ViewModels;
using NUglify.Helpers;
using Microsoft.EntityFrameworkCore.Query.Internal;


namespace DiplomProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CarListController : Controller
    {

        private ICarRepository repository;
        
        public CarListController(ICarRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var index = new CarListViewModel
            {
                Cars = repository.Cars
                    .OrderBy(p => p.Id),
                Bodytypes = repository.Cars
                .Select(p => p.BodyType)
                .Distinct(),
                Brands = repository.Cars
                .Select(p => p.Brand)
                .Distinct(),
                GearBoxes = repository.Cars
                .Select(p => p.GearBox)
                .Distinct(),
                Years = repository.Cars
                .Select(p => p.Year)
                .Distinct(),
                Fuel = repository.Cars
                .Select(p => p.Fuel)
                .Distinct()

            };
            return View(index);
        }


        //список товаров с сортировкой
        [HttpPost, ActionName("Index")]
        public IActionResult Filtered()
        {
            var year = Request.Form
                .Where(x => x.Key.Contains("year_"))
                .Select(x => x.Key.Remove(0, 5))
                .ToList();
            var gearbox = Request.Form
                .Where(x => x.Key.Contains("gearbox_"))
                .Select(x => x.Key.Remove(0, 8))
                .ToList();
            var brand = Request.Form
                .Where(x => x.Key.Contains("brand_"))
                .Select(x => x.Key.Remove(0, 6))
                .ToList();
            var body = Request.Form
                .Where(x => x.Key.Contains("body_"))
                .Select(x => x.Key.Remove(0, 5))
                .ToList();
            var fuel = Request.Form
                .Where(x => x.Key.Contains("fuel_"))
                .Select(x => x.Key.Remove(0, 5))
                .ToList();

            var pricefromString = Request.Form.FirstOrDefault(p => p.Key == "input_from").Value; 
            var pricetoString = Request.Form.FirstOrDefault(p => p.Key == "input_to").Value;
            var mileageValue = Request.Form.FirstOrDefault(p => p.Key == "mileage").Value;
            
            var pricefrom = Decimal.Parse(pricefromString);
            var priceto = Decimal.Parse(pricetoString);
            var mileage = Decimal.Parse(mileageValue);

            var result = new CarListViewModel
            {
                Cars = repository.Cars
                .Where(p => year.Contains(p.Year.ToString()) || year.Count() == 0) 
                .Where(p => brand.Contains(p.Brand) || brand.Count() == 0)
                .Where(p => body.Contains(p.BodyType) || body.Count() == 0)
                .Where(p => gearbox.Contains(p.GearBox) || gearbox.Count() == 0)
                .Where(p => fuel.Contains(p.Fuel) || fuel.Count() == 0)
                .Where(p => p.MonthlyPrice >= pricefrom && p.MonthlyPrice <= priceto)
                .Where(p => p.Mileage <= mileage)
                .OrderBy(p => p.Id),
                Brands = repository.Cars
                .Select(p => p.Brand)
                .Distinct(),
                Bodytypes = repository.Cars
                .Select(p => p.BodyType)
                .Distinct(),
                GearBoxes = repository.Cars
                .Select(p => p.GearBox)
                .Distinct(),
                Years = repository.Cars
                .Select(p => p.Year)
                .Distinct(),
                Fuel = repository.Cars
                .Select(p => p.Fuel)
                .Distinct(),
                PriceFrom = pricefrom,
                PriceTo = priceto
            };
            return View(result);
        }

        [HttpGet]
        public ViewResult CarProperties(int id) =>
            View(repository.Cars
                .Where(p => p.Id == id).FirstOrDefault());
    }
}