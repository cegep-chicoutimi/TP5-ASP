using Microsoft.AspNetCore.Mvc;

namespace TP5_ASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuChoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
