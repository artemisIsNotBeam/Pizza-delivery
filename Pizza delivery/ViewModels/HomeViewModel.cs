using Microsoft.AspNetCore.Mvc;
using Pizza_delivery.Models;

namespace Pizza_delivery.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pizza>? PizzasOfTheWeek { get; set; }
    }
}
