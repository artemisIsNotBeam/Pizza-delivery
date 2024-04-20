using System.ComponentModel.DataAnnotations;

namespace Pizza_delivery.Models
{
	public class OrderDetail
	{
		[Key]
		public int OrderDetailId { get; set; }
		
		public int OrderId { get; set; } 
		public int PizzaId { get; set; } 
		public int Amount { get; set; } 
		public double Price { get; set; } 
		public Pizza Pizza { get; set; } 
		public Order Order { get; set; }
	}
}
