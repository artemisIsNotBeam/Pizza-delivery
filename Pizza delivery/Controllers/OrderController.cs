using Microsoft.AspNetCore.Mvc;

namespace Pizza_delivery.Controllers
{
	public class HomeController1 : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
