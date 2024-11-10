using GestionBoutiqueC.core;
using GestionBoutiqueC.core.Database;
using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.repository.Bd
{
    public class ClientRepositoryBd : RepositoryBdImpl<Client>, IClientRepository
    {

    public ClientRepositoryBd(IDataBase dataBase) : base(dataBase)
    {
    }

        protected override string GetColumnNames()
        {
            return "surname, telephone, address, createAt, updateAt";
        }

        // Implémentation spécifique pour obtenir les noms des paramètres
        protected override string GetParameterNames()
        {
            return "@surname, @telephone, @address, @createAt, @updateAt";
        }

        // Implémentation spécifique pour mapper les résultats à l'entité Client
        protected override Client MapEntity(MySqlDataReader reader)
        {
            return new Client
            {
                Id = reader.GetInt32("id"),
                Surnom = reader.GetString("surname"),
                Telephone = reader.GetString("telephone"),
                Address = reader.GetString("address")
            };
        }

        // Implémentation spécifique pour définir les paramètres d'insertion
        protected override void SetInsertParameters(MySqlCommand cmd, Client entity)
        {
            cmd.Parameters.AddWithValue("@surname", entity.Surnom);
            cmd.Parameters.AddWithValue("@telephone", entity.Telephone);
            cmd.Parameters.AddWithValue("@address", entity.Address);
            cmd.Parameters.AddWithValue("@createAt", DateTime.Now);
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now);
        }

        // Implémentation spécifique pour définir les paramètres de mise à jour
        protected override void SetUpdateParameters(MySqlCommand cmd, Client entity)
        {
            cmd.Parameters.Clear();
            // cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@surname", entity.Surnom);
            cmd.Parameters.AddWithValue("@telephone", entity.Telephone);
            cmd.Parameters.AddWithValue("@address", entity.Address);
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now);


        }

        // Implémentation spécifique pour définir les colonnes à mettre à jour
        protected override string GetUpdateColumns()
        {
            return "surname = @surname, telephone = @telephone, address = @address, updateAt = @updateAt";
        }


        public Client? SelectByTelephone(string telephone)
        {

            return null;
        }

    }
}
