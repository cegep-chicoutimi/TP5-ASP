using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP5_ASP.Models;

namespace TP5_ASP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}