﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeri_crud_mvc.Models
{
    [Table("Categories")]
    public class Category
    {
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public List<Pizza> Pizzas { get; set; }

        public Category()
        {

        }

        public Category(string name)
        {
            Name = name;
        }
    }
}