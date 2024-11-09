using System;
using System.Collections.Generic;
using GestionBoutiqueC.core.Database;
using GestionBoutiqueC.data.entities;
using MySql.Data.MySqlClient;

namespace GestionBoutiqueC.core
{
    public abstract class RepositoryBdImpl<T> : IRepository<T> where T : IIdentifiable 
    {
        protected readonly IDataBase dataBase;

        public RepositoryBdImpl(IDataBase dataBase)
        {
            this.dataBase = dataBase;
        }

        protected abstract string GetColumnNames(); 
        protected abstract string GetParameterNames();
        protected abstract T MapEntity(MySqlDataReader reader);
        protected abstract void SetInsertParameters(MySqlCommand cmd, T entity);
        protected abstract void SetUpdateParameters(MySqlCommand cmd, T entity);
        protected abstract string GetUpdateColumns();

        public void Insert(T entity)
        {
            using (var conn = dataBase.getConnection()) // Utilisation de getConnection() pour obtenir la connexion
            {
                string insertQuery = $"INSERT INTO {typeof(T).Name.ToLower()} ({GetColumnNames()}) VALUES ({GetParameterNames()})";

                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                {
                    SetInsertParameters(cmd, entity);
                    cmd.ExecuteNonQuery();

                    if (cmd.LastInsertedId != 0)
                    {
                        entity.Id = (int)cmd.LastInsertedId;
                    }
                }
            }
        }

        public T? SelectById(int id)
        {
            using (var conn = dataBase.getConnection()) // Utilisation de getConnection() pour obtenir la connexion
            {
                string selectQuery = $"SELECT * FROM {typeof(T).Name.ToLower()} WHERE id = @id";
                
                using (MySqlCommand cmd = new MySqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapEntity(reader);
                        }
                    }
                }
            }
            return default;
        }

        public List<T> SelectAll()
        {
            List<T> entities = new List<T>();
            string selectQuery = $"SELECT * FROM {typeof(T).Name.ToLower()}";
            
            using (var conn = dataBase.getConnection()) // Utilisation de getConnection() pour obtenir la connexion
            {
                using (MySqlCommand cmd = new MySqlCommand(selectQuery, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entities.Add(MapEntity(reader));
                        }
                    }
                }
            }
            return entities;
        }

        public void Update(T entity)
        {
            string updateQuery = $"UPDATE {typeof(T).Name.ToLower()} SET {GetUpdateColumns()} WHERE id = @id";
            
            using (var conn = dataBase.getConnection()) // Utilisation de getConnection() pour obtenir la connexion
            {
                using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                {
                    SetUpdateParameters(cmd, entity);
                    cmd.Parameters.AddWithValue("@id", entity.Id);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Updated successfully.");
                }
            }
        }

        public void Delete(int id)
        {
            string deleteQuery = $"DELETE FROM {typeof(T).Name.ToLower()} WHERE id = @id";
            
            using (var conn = dataBase.getConnection()) // Utilisation de getConnection() pour obtenir la connexion
            {
                using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Deleted successfully.");
                }
            }
        }

    }
}
