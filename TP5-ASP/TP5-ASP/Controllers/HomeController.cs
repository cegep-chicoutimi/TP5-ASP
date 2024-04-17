using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP5_ASP.ViewModels;
using TP5_ASP.DataAccessLayer;
using TP5_ASP.Models;
using TP5_ASP.ViewModels;

namespace TP5_ASP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            DAL dal = new DAL();    
            ReservationCreateEditVM viewModel = new ReservationCreateEditVM(
                dal.ReservationFact.CreateEmpty(),
                dal.MenuFact.GetAll());

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReservationCreateEditVM viewModel)
        {
            if (viewModel != null && viewModel.Reservation != null)
            {
                DAL dal = new DAL();

                //J'ai fait des vérifications du genre "existing" comme dans les demo 
                Reservation existingReservation = dal.ReservationFact.Get(viewModel.Reservation.Id);

                if(existingReservation == null)
                {
                    dal.ReservationFact.Save(viewModel.Reservation);

                    return RedirectToAction("Details", "Reservation", new {Id = viewModel.Reservation.Id});
                }
                else
                {
                    return View("AdminMessage", new AdminMessageVM("Cette reservation existe déja !"));
                }           
            }

            return View("AdminMessage", new AdminMessageVM("Cette reservation est inexistante !"));

        }


    }
}