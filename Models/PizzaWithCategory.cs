using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeri_crud_mvc.Models
{
    public class PizzaWithCategory
    {
        public Pizza Pizza { get; set; }
        public List<Category>? Categories { get; set; }

        public List<Ingredient>? Ingredients { get; set; }
        public List<int>? SelectedIngredients { get; set; }

        public PizzaWithCategory()
        {
            Pizza = new Pizza();
            Categories = new List<Category>();
            Ingredients = new List<Ingredient>();
            SelectedIngredients = new List<int>();
        }
    }
}