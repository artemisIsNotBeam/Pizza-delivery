namespace Pizza_delivery.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Pizza Pizza { get; set; }
        public int Quantity { get; set; }
        
        public string ShoppingCartId { get; set; }

    }
}
