using la_mia_pizzeri_crud_mvc.Models;
using Microsoft.AspNetCore.Mvc;
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
                db.Add(new Pizza("Margherita", "La pizza Margherita è buona", "https://www.finedininglovers.it/sites/g/files/xknfdk1106/files/styles/recipes_1200_800_fallback/public/fdl_content_import_it/margherita-50kalo.jpg?itok=v9nHxNMS", 10.50m));
                db.Add(new Pizza("Napoli", "La pizza Napoli è buona", "https://media-cdn.tripadvisor.com/media/photo-s/18/03/98/d6/received-665664433902722.jpg", 14.50m));
                db.Add(new Pizza("Romana", "La pizza Romana è buona", "https://recipesblob.oetker.com/files/95bdfe7334364b41b557c734cd1c64c4/889e39b112414a9aa2b3ae5a9f787f6b/1272x764/pizza-alla-romanajpg.jpg", 17.50m));
                db.Add(new Pizza("4 Gusti", "La pizza 4 Gusti è buona", "https://media-cdn.tripadvisor.com/media/photo-s/07/61/12/f1/pizza-4-gusti.jpg", 5.50m));
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
            Pizza pizza = db.Pizzas.Where(pizzas => pizzas.PizzaId == id).First<Pizza>();

            return View(pizza);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Store(Pizza model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }

            db.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Pizza pizza = db.Pizzas.Find(id);

            if(pizza == null)
            {
                return NotFound("Non è stato possibile trovare la pizza da modificare");
            }
            else
            {
                return View(pizza);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizza model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            Pizza pizza = db.Pizzas.Find(id);

            pizza.Name = model.Name;
            pizza.Description = model.Description;
            pizza.Image = model.Image;
            pizza.Price = model.Price;

            //db.Pizzas.Update(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Pizza pizza = db.Pizzas.Find(id);

            db.Pizzas.Remove(pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}