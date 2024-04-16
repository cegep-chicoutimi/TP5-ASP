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

        /*C'est à ce niveau qu'on se rend premièrement avant d'aller dans la page d'édition/ajout*/
        public IActionResult Create()
        {
            DAL dal = new DAL();

            Menu menu = dal.MenuFact.CreateEmpty();

            return View("CreateEdit", menu);  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Menu menu)
        {
            if(menu != null)
            {
                DAL dal = new DAL();
                Menu existingMenu = dal.MenuFact.GetByDescription(menu.Description);

                //On vérifie d'abord si le choix de Menu recu par la vewModel n'existe pas déja dans la BD
                if(existingMenu != null)
                {
                    ModelState.AddModelError("Menu.Description", "Ce choix de menu existe déja !");
                }

                if(!ModelState.IsValid)
                {
                    // Si le modèle n'est pas valide, on retourne à la vue CreateEdit où les messages seront affichés.
                    // Le ViewModèle reçu en POST n'est pas complet (seulement les info dans le <form> sont conservées),
                    // il faut donc réaffecter le choix de Menu.

                    return View("CreateEdit", menu);
                }

                dal.MenuFact.Save(menu);

            }

            return RedirectToAction("List");
        }


        public IActionResult Edit(int id)
        {
            if(id > 0)
            {
                DAL dal = new DAL();
                Menu? menu = dal.MenuFact.Get(id);

                if(menu != null)
                {
                    return View("CreateEdit", menu);
                }
            }

            return View("AdminMessage", new AdminMessageVM("L'identifiant de la catégorie est introuvable ou la catégorie est introuvable."));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Menu menuChoice)
        {
            if(menuChoice != null)
            {
                DAL dal = new DAL();
                Menu? existingMenu = dal.MenuFact.GetByDescription(menuChoice.Description);

                if(existingMenu != null)    //On s'assure que dans la BD il n'existe pas déja un choix de Menu avec la meme description
                {
                    ModelState.AddModelError("Menu.Description", "La description de ce choix de Menu existe déjà.");
                }

                if (!ModelState.IsValid)
                {
                    return View("CreateEdit", menuChoice);
                }

                dal.MenuFact.Save(menuChoice);
            }

            return RedirectToAction("List");
        }

        /*C'est à ce niveau qu'on se rend premièrement avant d'aller dans la page de suppression*/
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                DAL dal = new DAL();
                Menu? menu = dal.MenuFact.Get(id);

                if(menu != null)
                {
                    return View(menu);
                }
            }

            return View("AdminMessage", new AdminMessageVM("L'identifiant de la catégorie est introuvable ou la catégorie est inexistante."));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        /*àprès avoir confirmer la suppression*/
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if(id > 0)
            {
                new DAL().MenuFact.Delete(id);
            }

            return RedirectToAction("List");
        }
    }


}
