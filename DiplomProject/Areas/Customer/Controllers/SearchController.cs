using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomProject.Models;
using DiplomProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiplomProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class SearchController : Controller
    {
        private ICarRepository repository;
        public SearchController(ICarRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index(string searchString)
        {
            var result = new CarListViewModel
            {
                Cars = repository.Cars
            };
            if (!String.IsNullOrEmpty(searchString))
            {
                result.SearchTerm = searchString;
                result.Cars = result.Cars
                    .Where(q => (q.Brand + " " + q.Model + " " + q.Description)
                    .ToLower()
                    .Contains(searchString.ToLower()))
                    .OrderBy(p => p.Id);
            };
            return View(result);
        }
    }
}