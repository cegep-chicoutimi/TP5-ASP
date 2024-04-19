using TP5_ASP.Models;

namespace TP5_ASP.Areas.Admin.ViewModels
{
    public class ReservationListVM
    {
        /*Cette vueModel est pour concevoir une liste de reservations chacune associée à son
         * choix de Menu qui sera proposée dans les view adéquates
         */

        private readonly Dictionary<int, Menu> _menuById = new Dictionary<int, Menu>();

        public List<Menu> Menus
        { 
            get
            {
                return _menuById.Values.ToList();
            }
        }
        public List<Reservation> Reservations { get; }

        //Constructeur
        public ReservationListVM(List<Reservation> reservations, List<Menu> menus)
        {
            this.Reservations = reservations;

            foreach (Menu menu in menus)
            {
                _menuById.Add(menu.Id, menu);
            }
        }

         public String GetMenuNameByReservation(int id)
          {
            if(_menuById.ContainsKey(id))
                return _menuById[id].Description;

            //Au cas où le choix de menu d'une reservation est supprimé en cours d'utilisation !
            return "ce choix de menu à été supprimé !";
          }
    }
}
