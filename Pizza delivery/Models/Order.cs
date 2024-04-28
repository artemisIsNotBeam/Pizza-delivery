using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;


namespace Pizza_delivery.Models
{
	public class Order
	{
		[Key]
		public int OrderId { get; set; }
		public List<OrderDetail>? OrderDetails { get; set; }

		[Required(ErrorMessage = "Please enter your first name")]
		[Display(Name = "First name")]
		[StringLength(50)] 
		public string FirstName { get; set; }
		[Required(ErrorMessage = "Please enter your last name")]
		[Display(Name = "Last name")]
		[StringLength(50)]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Please enter your Address")]
		[Display(Name = "Address")]
		[StringLength(50)]
		public string StreetAddress { get; set; }
		[Display(Name = "Address 2")]
		public string? StreetAddress2 { get; set; }
		[Required(ErrorMessage = "Please enter your City")]
		[StringLength(50)]
		public string City { get; set; }
		[Required(ErrorMessage = "Please enter your State")]
		[StringLength(3)]
		public string State { get; set; }
		[Required(ErrorMessage = "Please enter your State")]
		[Display(Name ="Postal Code")]
		[StringLength(10,MinimumLength =4)]
		public string PostalCode { get; set; }
		[Required(ErrorMessage = "Please enter your Phone Number")]
		[Display(Name = "Phone Number")]
		[DataType(DataType.PhoneNumber)]
		[StringLength(25)]
		public string PhoneNumber { get; set; }
		[Required(ErrorMessage = "Please enter your Email")]
		[DataType(DataType.EmailAddress)]
		[StringLength(25)]
		public string Email { get; set; }
		public double? OrderTotal { get; set; }
		public DateTime? OrderPlaced { get; set; }

	}
}
