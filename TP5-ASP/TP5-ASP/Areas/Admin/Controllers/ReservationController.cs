using Microsoft.AspNetCore.Mvc;
using TP5_ASP.Areas.Admin.ViewModels;
using TP5_ASP.DataAccessLayer;
using TP5_ASP.Models;

namespace TP5_ASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        public IActionResult List()
        {
            DAL dal = new DAL();

            ReservationListVM viewModel = new ReservationListVM(dal.ReservationFact.GetAll(), dal.MenuFact.GetAll());

            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            if(id > 0)
            {
                DAL dal = new DAL();
                Reservation existingReservation = dal.ReservationFact.Get(id);
                Menu? menuReservation = dal.MenuFact.Get(existingReservation.MenuChoiceId);

                if(existingReservation != null)
                {
                    ReservationDeleteVM viewModel = new ReservationDeleteVM(
                        existingReservation, dal.MenuFact.GetByDescription(menuReservation.Description));

                    return View(viewModel);
                }
            }

            return View("AdminMessage", new AdminMessageVM("L'identifiant de cette reservation est introuvable ou" +
                                                           " cette reservation est inexistante !."));           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (id > 0)
            { 
                new DAL().ReservationFact.Delete(id);
            }

            return RedirectToAction("List");
        }
    }
}
