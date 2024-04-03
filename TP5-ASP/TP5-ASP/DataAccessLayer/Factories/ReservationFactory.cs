using TP5_ASP.Models;
using MySql.Data.MySqlClient;
namespace TP5_ASP.DataAccessLayer.Factories
{
    public class ReservationFactory
    {
        private Reservation CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            int id = (int)mySqlDataReader["Id"];

            string nom = mySqlDataReader["Nom"].ToString() ?? string.Empty;

            string courriel = mySqlDataReader["Courriel"].ToString() ?? string.Empty;

            int nbPersonne = (int)mySqlDataReader["NbPersonne"];
            DateTime dateReservation = (DateTime)mySqlDataReader["DateReservation"];

            int menuChoiceId = (int)mySqlDataReader["MenuChoiceId"];

            return new Reservation(id, nom, courriel, nbPersonne, dateReservation, menuChoiceId);
        }


    }
}
