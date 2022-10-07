using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeri_crud_mvc.Models
{
    public class PizzaWithCategory
    {
        public Pizza Pizza { get; set; }
        public Category Category { get; set; }

        public PizzaWithCategory()
        {

        }

        public PizzaWithCategory(Pizza pizza, Category category)
        {
            Pizza = pizza;
            Category = category;
        }
    }
}