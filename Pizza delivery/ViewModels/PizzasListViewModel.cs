using Pizza_delivery.Models;
namespace Pizza_delivery.ViewModels
{
    public class PizzasListViewModel
    {
        public IEnumerable<Pizza> Pizzas { get; set; }
        public string CurrentCategory { get; set; }
    }
}
