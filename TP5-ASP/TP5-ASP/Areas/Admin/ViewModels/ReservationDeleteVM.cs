using TP5_ASP.Models;

namespace TP5_ASP.Areas.Admin.ViewModels
{
    /* Puisque la reservation à supprimer a déja un choix de menu connu, cette nouvelle ViewModel 
     * est formée directement des deux entités (La reservation et son choix de menu associé)
     */
    public class ReservationDeleteVM
    {
        public Reservation Reservation { get;}

        public Menu Menu { get;}

        public string MenuDescription
        {
            get
            {
                return Menu?.Description ?? "ce choix de menu à été supprimé !";
            }
        }

        public ReservationDeleteVM(Reservation reservation, Menu? menu)
        {
            Reservation = reservation;
            Menu = menu;
        }
    }
}
