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
            DateTime dateReservation = DateTime.Now;

            if (mySqlDataReader["DateReservation"] != DBNull.Value)
                dateReservation = (DateTime)mySqlDataReader["DateReservation"];
                

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
               mySqlCmd.CommandText = "SELECT * FROM tp5_reservations;";

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Reservation reservation = CreateFromReader(mySqlDataReader);
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

        public Reservation Get(int id)
        {
            Reservation? reservation = null;
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp5_reservations where Id = @Id";
                mySqlCmd.Parameters.AddWithValue("@Id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    reservation = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return reservation;

        }

        public void Delete(int id)
        {
            MySqlConnection? mySqlCnn = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "DELETE FROM tp5_reservations WHERE Id=@Id";
                mySqlCmd.Parameters.AddWithValue("@Id", id);
                mySqlCmd.ExecuteNonQuery();
            }
            finally
            {
                mySqlCnn?.Close();
            }
        }

        public void Save(Reservation reservation)
        {
            MySqlConnection? mySqlCnn = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                if(reservation.Id == 0)
                {
                    /*on sait que c'est une nouvelle reservation avec Id = 0
                     car c'est ce que nous avons affecter dans la fonction CreateEmpty().
                     */
                    mySqlCmd.CommandText = "INSERT INTO tp5_reservations(Nom, Courriel, NbPersonne, DateReservation, MenuChoiceId) " +
                        "VALUES (@Nom, @Courriel, @NbPersonne, @Date, @MenuChoiceId);";
                }
                else  //Dans l'évatualité où un utilisateur veut modifier une reservation
                {
                    mySqlCmd.CommandText = "Il faudra une requête UPDATE qui set tous les caractères sauf le nom et le " +
                        "courriel de la reservation";
                }

                mySqlCmd.Parameters.AddWithValue("@Nom", reservation.Nom);
                mySqlCmd.Parameters.AddWithValue("@Courriel", reservation.Courriel);
                mySqlCmd.Parameters.AddWithValue("@NbPersonne", reservation.NbPersonne);
                mySqlCmd.Parameters.AddWithValue("@Date", reservation.DateReservation);
                mySqlCmd.Parameters.AddWithValue("@MenuChoiceId", reservation.MenuChoiceId);

                mySqlCmd.ExecuteNonQuery();

                if(reservation.Id == 0)
                {
                    /* S'il s'agit d'une nouvelle reservation (requête INSERT) nous affecterons le nouvel Id de 
                     * l'instance au cas où il serait utilisé dans le code appelant, ou ultérieurement
                     */

                    reservation.Id = (int)mySqlCmd.LastInsertedId;
                }

            }
            finally
            {
                mySqlCnn?.Close();
            }
        }
    }
}
