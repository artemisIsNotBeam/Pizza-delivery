using Microsoft.AspNetCore.Mvc;
using Pizza_delivery.Models;
using Pizza_delivery.ViewModels;

namespace Pizza_delivery.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly ICategoryRepository _categoryRepository;
        public PizzaController(IPizzaRepository pizzaRepository, ICategoryRepository categoryRepository)
        {
            _pizzaRepository = pizzaRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            PizzasListViewModel pizzaListViewModel = new PizzasListViewModel();
            pizzaListViewModel.Pizzas = _pizzaRepository.AllPizzas;
            pizzaListViewModel.CurrentCategory = "meat pizzas";
            return View(pizzaListViewModel);
        }

        public IActionResult Detail(int id)
        {
            var pizza = _pizzaRepository.GetPizzaById(id);
            if (pizza == null)
                return NotFound();
            return View(pizza);
        }
    }
}
