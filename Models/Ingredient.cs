using la_mia_pizzeri_crud_mvc.Models;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_crud_mvc.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public List<Pizza>? Pizzas { get; set; }

        public Ingredient()
        {

        }

        public Ingredient(string name)
        {
            Name = name;
        }

    }
}
