using TP5_ASP.Models;

namespace TP5_ASP.ViewModels
{
    public class ReservationCreateEditVM
    {
        /* Puisque lors de l'édition d'une reservation, il va falloir proposer une liste déroulantre de choix de menus, 
         * cette nouvelle ViewModel est pour concillier cela !
         */
        
        public Reservation Reservation { get; set; } = new Reservation();
        public List<Menu> Menus { get; set; }     //Car pour la création d'une reservation est proposée une liste de choix de Menu

        //Constructeur vide requis pour la désérialisation
        public ReservationCreateEditVM() { }

        public ReservationCreateEditVM(Reservation reservation, List<Menu> menus)
        {
            Reservation = reservation;
            Menus = menus;

        }
    }
}
