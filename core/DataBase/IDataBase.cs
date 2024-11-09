using MySql.Data.MySqlClient;

namespace GestionBoutiqueC.core.Database
{
    public interface IDataBase
    {
        MySqlConnection getConnection();
        void closeConnection();
        
    }
}