using la_mia_pizzeri_crud_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace la_mia_pizzeri_crud_mvc.Controllers
{
    public class EserciziController : Controller
    {
        private readonly ILogger<EserciziController> _logger;

        public EserciziController(ILogger<EserciziController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}