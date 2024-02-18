namespace Pizza_delivery.Models
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> AllPizzas { get; }
        IEnumerable<Pizza> PizzasOfTheWeek { get; }
        Pizza GetPizzaById(int pizzaId);
    }
}
