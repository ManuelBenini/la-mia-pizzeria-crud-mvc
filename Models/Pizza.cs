﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeri_crud_mvc.Models
{
    [Table("Pizzas")]
    public class Pizza
    {
        public int PizzaId { get; set; }

        [Required(ErrorMessage = "Il campo nome è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il nome non può avere più di 50 caratteri")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Il campo descrizione è obbligatorio")]
        [MoreThanFiveWordsValidation]
        public string Description { get; set; }

        [Required(ErrorMessage = "Il campo immagine è obbligatorio")]
        [Url(ErrorMessage = "L'immagine inserita non è valida")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Il campo prezzo è obbligatorio")]
        [MoreThanZeroValidation]
        public decimal Price { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public Pizza()
        {

        }

        public Pizza(string name, string description, string image, decimal price)
        {
            Name = name;
            Description = description;
            Image = image;
            Price = price;
        }
        public Pizza(string name, string description, string image, decimal price, int categoryId)
        {
            Name = name;
            Description = description;
            Image = image;
            Price = price;
            CategoryId = categoryId;
        }

    }
}