using TP5_ASP.Models;

namespace TP5_ASP.Areas.Admin.ViewModels
{
    public class ReservationListVM
    {
        //Cette vueModel est pour concevoir une liste de reservationb qui sera proposée dans les view adéquates

        public List<Reservation> Reservations { get; }

        //Constructeur
        public ReservationListVM(List<Reservation> reservations)
        {
            this.Reservations = reservations;
        }
    }
}
