using la_mia_pizzeri_crud_mvc.Models;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace la_mia_pizzeri_crud_mvc.Controllers
{
    public class PizzasController : Controller
    {

        PizzaContext db;

        public PizzasController()
        {
            db = new();

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }

        public List<Pizza> Pizzas()
        {
            List<Pizza> pizzas = db.Pizzas.ToList<Pizza>();

            //Se la tabella Pizzas del DB è vuota, aggiungo delle pizze d'esempio
            if (pizzas.Count == 0)
            {
                db.Add(new Category("Pizza bianche"));
                db.Add(new Category("Pizza vegetariane"));
                db.Add(new Category("Pizza classiche"));
                db.Add(new Category("Pizza di mare"));
                db.SaveChanges();

                db.Add(new Ingredient("Acciughe"));
                db.Add(new Ingredient("Pomodoro"));
                db.Add(new Ingredient("Wurstel"));
                db.Add(new Ingredient("Funghi"));
                db.Add(new Ingredient("Panna"));
                db.SaveChanges();

                db.Add(new Pizza("Margherita", "La pizza Margherita è buona", "https://www.finedininglovers.it/sites/g/files/xknfdk1106/files/styles/recipes_1200_800_fallback/public/fdl_content_import_it/margherita-50kalo.jpg?itok=v9nHxNMS", 10.50m, 1, new List<Ingredient>() { db.Ingredients.Find(1) , db.Ingredients.Find(2) }));
                db.Add(new Pizza("Napoli", "La pizza Napoli è buona", "https://media-cdn.tripadvisor.com/media/photo-s/18/03/98/d6/received-665664433902722.jpg", 14.50m, 2, new List<Ingredient>() { db.Ingredients.Find(2), db.Ingredients.Find(3) }));
                db.Add(new Pizza("Romana", "La pizza Romana è buona", "https://recipesblob.oetker.com/files/95bdfe7334364b41b557c734cd1c64c4/889e39b112414a9aa2b3ae5a9f787f6b/1272x764/pizza-alla-romanajpg.jpg", 17.50m, 3, new List<Ingredient>() { db.Ingredients.Find(4), db.Ingredients.Find(5) }));
                db.Add(new Pizza("4 Gusti", "La pizza 4 Gusti è buona", "https://media-cdn.tripadvisor.com/media/photo-s/07/61/12/f1/pizza-4-gusti.jpg", 5.50m, 4, new List<Ingredient>() { db.Ingredients.Find(1), db.Ingredients.Find(5) }));
                db.SaveChanges();
            }

            return pizzas;
        }

        public IActionResult Index()
        {
            return View(Pizzas());
        }

        public IActionResult Show(int id)
        {
            Pizza pizza = db.Pizzas.Where(pizzas => pizzas.PizzaId == id).Include("Category").Include("Ingredients").FirstOrDefault();

            if (pizza == null)
            {
                return NotFound($"La pizza con id {id} non è stata trovata");
            }
            else
            {
                return View(pizza);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            PizzaWithCategory pizzaWithCategory = new()
            {
                Categories = db.Categories.ToList(),
                Ingredients = db.Ingredients.ToList()
            };

            return View(pizzaWithCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Store(PizzaWithCategory model)
        {
            model.Categories = db.Categories.ToList();
            model.Ingredients = db.Ingredients.ToList();

            if (!ModelState.IsValid)
            {
                //model.Categories = db.Categories.ToList();
                //model.Ingredients = db.Ingredients.ToList();
                return View("Create", model);
            }

            model.Pizza.Ingredients = db.Ingredients.Where(ingredient => model.SelectedIngredients.Contains(ingredient.IngredientId)).ToList<Ingredient>();

            db.Add(model.Pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Pizza pizza = db.Pizzas.Include("Category").Include("Ingredients").Where(pizza => pizza.PizzaId == id).FirstOrDefault();

            if (pizza == null)
            {
                return NotFound("Non è stato possibile trovare la pizza da modificare");
            }
            else
            {
                PizzaWithCategory pizzaWithCategory = new();

                pizzaWithCategory.Pizza = pizza;
                pizzaWithCategory.Categories = db.Categories.ToList();
                pizzaWithCategory.Ingredients = db.Ingredients.ToList();

                return View(pizzaWithCategory);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaWithCategory model)
        {
            model.Categories = db.Categories.ToList();
            model.Ingredients = db.Ingredients.ToList();

            if (!ModelState.IsValid)
            {
                //model.Categories = db.Categories.ToList();
                //model.Ingredients = db.Ingredients.ToList();
                return View("Edit", model);
            }

            Pizza pizza = db.Pizzas.Include("Category").Include("Ingredients").Where(pizza => pizza.PizzaId == id).First();

            pizza.Name = model.Pizza.Name;
            pizza.Description = model.Pizza.Description;
            pizza.Image = model.Pizza.Image;
            pizza.Price = model.Pizza.Price;
            pizza.CategoryId = model.Pizza.CategoryId;

            List<Ingredient> SelectedIngredients = db.Ingredients.Where(ingredient => model.SelectedIngredients.Contains(ingredient.IngredientId)).ToList();

            foreach (Ingredient ingredient in SelectedIngredients)
            {
                if (!pizza.Ingredients.Contains(ingredient))
                {
                    pizza.Ingredients.Add(ingredient);
                }
                
            }

            //db.Pizzas.Update(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Pizza pizza = db.Pizzas.Find(id);

            if (pizza == null)
            {
                return NotFound();
                
            }
            else
            {
                db.Pizzas.Remove(pizza);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

        }

    }
}