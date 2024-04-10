using Microsoft.AspNetCore.Mvc;
using TP5_ASP.Areas.Admin.ViewModels;
using TP5_ASP.DataAccessLayer;
using TP5_ASP.Models;

namespace TP5_ASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult List()
        {
            DAL dal = new DAL();

            MenuListVM viewModel = new MenuListVM(dal.MenuFact.GetAll());

            return View(viewModel);
        }
    }
}
