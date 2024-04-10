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

        /// <summary>
        /// Creer une reservation par défaut !
        /// </summary>
        /// <returns></returns>
        public Reservation CreateEmpty()
        {
            return new Reservation(0, string.Empty, string.Empty, 0, DateTime.Now, 0);
        }

        public List<Reservation> GetAll()
        {
            List<Reservation> reservations = new List<Reservation>();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
               mySqlCnn = new MySqlConnection(DAL.ConnectionString);
               mySqlCnn.Open();

               MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
               mySqlCmd.CommandText = "";

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                { 
                    Reservation reservation = new Reservation();
                    reservations.Add(reservation);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }


            return reservations;
        }


    }
}
