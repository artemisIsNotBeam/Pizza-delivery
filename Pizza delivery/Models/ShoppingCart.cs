using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Pizza_delivery.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _appDbContext;
        private ShoppingCart(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Pizza pizza, int amount)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(s => s.Pizza.PizzaId == pizza.PizzaId && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null) {
                shoppingCartItem = new ShoppingCartItem
                {
                    Pizza = pizza,
                    Quantity = amount,
                    ShoppingCartId = ShoppingCartId
                };

                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            } else
            {
                shoppingCartItem.Quantity += amount;
            }
            _appDbContext.SaveChanges();
        }

        public void RemoveFromCart(Pizza pizza)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(s => s.Pizza.PizzaId == pizza.PizzaId && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity> 1)
                {
                    shoppingCartItem.Quantity--;
                } else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
                _appDbContext.SaveChanges();
            }
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Include(s => s.Pizza).ToList());
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);
            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }

        public double GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Select(c => c.Pizza.Price * c.Quantity).Sum();
            return total;
        }
    }
}
