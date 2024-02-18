using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pizza_delivery.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Shortdesc { get; set; }
        public string Longdesc { get; set; }
        [Required]
        public string Allergyinfo { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public string ImgThumbnailUrl { get; set; }
        public bool IsPizzaOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
