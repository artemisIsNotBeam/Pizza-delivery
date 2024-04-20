
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

		public void CreateOrder(Order order) {
            order.OrderPlaced = DateTime.Now;
			var shoppingCartItems = _shoppingCart.ShoppingCartItems;
			order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
			order.OrderDetails = new List<OrderDetail>();
			foreach (var item in shoppingCartItems)
			{
				var orderDetail = new OrderDetail
				{
					Amount = item.Quantity,
					PizzaId = item.Pizza.PizzaId,
					Price = item.Pizza.Price,
				};
				order.OrderDetails.Add(orderDetail);
			}
			_db.Orders.Add(order);
			_db.SaveChanges();
        }
	}
}
