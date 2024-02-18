using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Pizza_delivery.Models
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly ApplicationDbContext _db;
        public PizzaRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Pizza> AllPizzas { get { return _db.Pizzas.Include(c => c.Category); } }
        public IEnumerable<Pizza> PizzasOfTheWeek { get { return _db.Pizzas.Include(c => c.Category).Where(p=>p.IsPizzaOfTheWeek);  } }
        public Pizza GetPizzaById(int pizzaId) {
            return _db.Pizzas.FirstOrDefault(p => p.PizzaId == pizzaId);
        }

    }
}
