using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace la_mia_pizzeria_crud_mvc.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index() { return View(); }

    }
}