using MySql.Data.MySqlClient;

namespace GestionBoutiqueC.core.Database
{
    public class DataBase : IDataBase
    {
        protected MySqlConnection? conn;
        private readonly string connectionString = "Server=localhost;Port=3306;Database=gestion_boutique_C#;User ID=root;Password=;";
        public void closeConnection()
        {
            if (conn != null && conn.State != System.Data.ConnectionState.Open){
                conn.Close();
                conn = null;
            } 
        }

        public MySqlConnection getConnection()
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}