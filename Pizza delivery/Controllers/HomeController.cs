using Microsoft.AspNetCore.Mvc;
using Pizza_delivery.Models;
using Pizza_delivery.ViewModels;
using System.Diagnostics;

namespace Pizza_delivery.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;
        public HomeController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PizzasOfTheWeek = _pizzaRepository.PizzasOfTheWeek
            };
            return View(homeViewModel);
        }
    }
}