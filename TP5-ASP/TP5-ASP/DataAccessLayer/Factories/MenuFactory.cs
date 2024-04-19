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
        /// Creer une objet Menu par défaut
        /// </summary>
        /// <returns></returns>
        public Menu CreateEmpty()
        {
            return new Menu(0, "");
        }

        /// <summary>
        /// Obtenir la liste de tous les choix de menu présents dans la BD
        /// </summary>
        /// <returns></returns>
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
                mySqlCmd.CommandText = "SELECT * FROM tp5_menuchoices order by Description;";

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


        /// <summary>
        /// Get un menu à partir de son id (très utile lors de l'édition/creation)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Menu? Get(int id)
        {
            Menu? menu = null;
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp5_menuchoices where Id = @Id";

                mySqlCmd.Parameters.AddWithValue("@Id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    menu = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return menu;
        }


        /// <summary>
        /// Get un choix de Menu selon sa description
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public Menu? GetByDescription(string description)
        {
            Menu? menu = null;
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp5_menuchoices where Description = @Description";
                mySqlCmd.Parameters.AddWithValue("@Description", description);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    menu = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return menu;
        }



        /// <summary>
        ///  Inserer un nouveau choix de menu dans la BD: cette méthode sera à la fois utilisée pour les actions d'ajout et d'édition dans les controllers
        /// </summary>
        /// <param name="menu"></param>
        public void Save(Menu menu)
        {
            MySqlConnection? mySqlCnn = null;


            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                if(menu.Id == 0)
                {
                    // On sait que c'est un nouveau choix de menu avec Id == 0,
                    // car c'est ce que nous avons affecter dans la fonction CreateEmpty().
                    mySqlCmd.CommandText = "INSERT INTO `tp5_menuchoices` (`Description`) VALUES (@Description)";
                }
                else
                {
                    mySqlCmd.CommandText = "update tp5_menuchoices set Description = @Description where Id= @Id";
                }

                mySqlCmd.Parameters.AddWithValue("@Description", menu.Description);
                mySqlCmd.Parameters.AddWithValue("@Id", menu.Id);

                mySqlCmd.ExecuteNonQuery();

                if (menu.Id == 0)
                {
                    // Si c'était un nouveau choix de menu (requête INSERT),
                    // nous affectons le nouvel Id de l'instance au cas où il serait utilisé dans le code appelant.
                    menu.Id = (int)mySqlCmd.LastInsertedId;
                }
            }
            finally
            {
                mySqlCnn?.Close();
            }

        }

        public void Delete(int id)
        {
            MySqlConnection? mySqlCnn = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "DELETE FROM tp5_menuchoices WHERE Id=@Id";
                mySqlCmd.Parameters.AddWithValue("@Id", id);
                mySqlCmd.ExecuteNonQuery();
            }
            finally
            {
                mySqlCnn?.Close();
            }
        }
       

    }
}
