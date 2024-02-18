﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pizza_delivery.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public List<Pizza> Pizzas { get; set; }
    }
}
