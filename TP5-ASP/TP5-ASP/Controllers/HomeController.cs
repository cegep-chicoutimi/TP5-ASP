using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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

                //J'ai pas fair de vérification du genre "existing" comme dans les demo 

                dal.ReservationFact.Save(viewModel.Reservation);

                //Le model qui sera utilie à la vue "Details"
            }

            return View("Details", viewModel.Reservation);
        }


    }
}