using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DiplomProject.Infrastructure;
using DiplomProject.Models;
using DiplomProject.Models.ViewModels;


namespace DiplomProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class FavoriteController : Controller
    {
        private ICarRepository repository;
        private Favorite favorite;
        public FavoriteController(ICarRepository repo, Favorite favoriteService)
        {
            repository = repo;
            favorite = favoriteService;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new FavoriteIndexViewModel
            {
                Favorite = favorite,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToActionResult AddToFavorite(int Id, string returnUrl)
        {
            Car car = repository.Cars
                .FirstOrDefault(p => p.Id == Id);
            if (car != null)
            {
                favorite.AddItem(car);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromFavorite(int carId, string returnUrl)
        {
            Car car = repository.Cars
                .FirstOrDefault(p => p.Id == carId);

            if (car != null)
            {
                favorite.RemoveItem(car);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}