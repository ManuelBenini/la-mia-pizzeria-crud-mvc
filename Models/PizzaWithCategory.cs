using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Validations;

namespace Models
{
    public class PizzaWithCategory
    {
        public Pizza Pizza { get; set; }
        public List<Category>? Categories { get; set; }

        public List<Ingredient>? Ingredients { get; set; }

        [OneIngredientMinimumValidation]
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