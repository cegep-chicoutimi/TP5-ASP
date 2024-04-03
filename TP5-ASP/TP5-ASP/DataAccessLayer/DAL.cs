using TP5_ASP.DataAccessLayer.Factories;

namespace TP5_ASP.DataAccessLayer
{
    public class DAL
    {
        private MenuFactory? _menuFactory = null;
        private ReservationFactory? _reservationFactory = null;

        public static string? ConnectionString { get; set; }    

        public MenuFactory MenuFact
        {
            get
            {
                if(_menuFactory == null)
                {
                    _menuFactory = new MenuFactory();
                }

                return _menuFactory;    
            }
        }

        public ReservationFactory ReservationFact
        {
            get
            {
                if(_reservationFactory == null)
                {
                    _reservationFactory = new ReservationFactory();
                }

                return _reservationFactory;
            }
        }
    }
}
