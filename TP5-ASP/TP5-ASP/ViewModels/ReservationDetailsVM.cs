using TP5_ASP.Models;

namespace TP5_ASP.ViewModels
{
    public class ReservationDetailsVM
    {
        /* Après avoir creer une nouvelle reservation, celle-ci est associée à un Menu, 
         * cette vue est pour concillier cela !
        */

        public Reservation Reservation { get; }

        public Menu Menu { get; }

        public string MenuDescription
        {
            get
            {
                return Menu?.Description ?? string.Empty;
            }
        }

        public ReservationDetailsVM(Reservation reservation, Menu? menu)
        {
            Reservation = reservation;
            Menu = menu;
        }
    }
}
