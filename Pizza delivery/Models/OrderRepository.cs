namespace Pizza_delivery.Models
{
	public class OrderRepository : IOrderRepository
	{
		private readonly ApplicationDbContext _db;
		private readonly ShoppingCart _shoppingCart;
		public OrderRepository(ApplicationDbContext db, ShoppingCart shoppingCart)
		{
			_db = db;
			_shoppingCart = shoppingCart;
		}

		public void CreateOrder(Order order);
	}
}
