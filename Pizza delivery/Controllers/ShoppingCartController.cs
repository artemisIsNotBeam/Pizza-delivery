using Microsoft.AspNetCore.Mvc;
using Pizza_delivery.Models;
using Pizza_delivery.ViewModels;

namespace Pizza_delivery.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IPizzaRepository pizzaRepository, ShoppingCart shoppingCart)
        {
            _pizzaRepository = pizzaRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            List<ShoppingCartItem> items= _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems=items;
            var shoppingCartViewModel = new ShoppingCartViewModel {
                ShoppingCart= _shoppingCart,
                ShoppingCartTotal=_shoppingCart.GetShoppingCartTotal() 
            };
            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int pizzaId)
        {
            var selectedPizza = _pizzaRepository.AllPizzas.FirstOrDefault(p => p.PizzaId == pizzaId);
            if (selectedPizza != null)
            {
                _shoppingCart.AddToCart(selectedPizza, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemovingShoppingCart(int pizzaId)
        {
            var selectedPizza = _pizzaRepository.AllPizzas.FirstOrDefault(p => p.PizzaId == pizzaId);
            if (selectedPizza != null)
            {
                _shoppingCart.RemoveFromCart(selectedPizza);
            } 
            return RedirectToAction("Index");
        }
    }
}
