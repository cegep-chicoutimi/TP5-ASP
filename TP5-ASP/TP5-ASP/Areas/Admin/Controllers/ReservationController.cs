using Microsoft.AspNetCore.Mvc;
using TP5_ASP.Areas.Admin.ViewModels;
using TP5_ASP.DataAccessLayer;

namespace TP5_ASP.Areas.Admin.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult List()
        {
            DAL dal = new DAL();

            ReservationListVM viewModel = new ReservationListVM(dal.ReservationFact.GetAll());

            return View(viewModel);
        }
    }
}
