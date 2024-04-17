using Microsoft.AspNetCore.Mvc;
using TP5_ASP.ViewModels;
using TP5_ASP.DataAccessLayer;
using TP5_ASP.Models;
using TP5_ASP.ViewModels;

namespace TP5_ASP.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Details(int id)
        {
            DAL dal = new DAL();
            Reservation newReservation = dal.ReservationFact.Get(id);

            if(newReservation == null)
            {
                return View("AdminMessage", new AdminMessageVM("Cette reservation n'existe pas ! !"));
            }

            //Le model qui sera utilie à la vue "Details"
            ReservationDetailsVM newVm = new ReservationDetailsVM(newReservation, dal.MenuFact.Get(newReservation.MenuChoiceId));
            return View(newVm);
        }
    }
}
