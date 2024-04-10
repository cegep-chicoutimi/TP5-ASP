using TP5_ASP.Models;
using MySql.Data.MySqlClient;

namespace TP5_ASP.DataAccessLayer.Factories
{
    public class MenuFactory
    {
        /// <summary>
        /// Obternir une catégorie à la suite d'une requête SQL à la BD
        /// </summary>
        /// <param name="mySqlDataReader"></param>
        /// <returns></returns>
        private Menu CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            int id = (int)mySqlDataReader["Id"];

            string description = mySqlDataReader["Description"].ToString() ?? string.Empty;

            return new Menu(id, description);

        }

        /// <summary>
        /// Retourner une objet Menu par défaut
        /// </summary>
        /// <returns></returns>
        public Menu CreateEmpty()
        {
            return new Menu(0, "description de Menu par défaut !");
        }

      public List<Menu> GetAll()
        {
            List<Menu> menus = new List<Menu>();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand(); 
                mySqlCmd.CommandText = "SELECT * FROM h24_web_transac_2130331.tp5_menuchoices;";

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Menu menu = CreateFromReader(mySqlDataReader);
                    menus.Add(menu);
                }

            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return menus;
        }
    }
}
