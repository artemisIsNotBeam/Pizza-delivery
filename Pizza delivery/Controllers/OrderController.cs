using Microsoft.AspNetCore.Mvc;
using Pizza_delivery.Models;
namespace Pizza_delivery.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderRepository _orderRepository;
		private readonly ShoppingCart _shoppingCart;

		public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
		{
			_orderRepository= orderRepository;
			_shoppingCart= shoppingCart;
		}
		public IActionResult Checkout()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Checkout(Order order)
		{
			var items = _shoppingCart.GetShoppingCartItems();
            if (items.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pizza first!");
            }
			if (ModelState.IsValid)
			{
				_orderRepository.CreateOrder(order);
				_shoppingCart.ClearCart();
				return RedirectToAction("CheckoutComplete");
			} else
			{
				return View(order);
			}
        }

		public IActionResult CheckoutComplete()
		{
			return View();
		}
	}
}
