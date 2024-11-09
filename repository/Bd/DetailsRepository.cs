using GestionBoutiqueC.core;
using GestionBoutiqueC.core.Database;
using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GestionBoutiqueC.repository.Bd
{
    public class DetailsRepository : RepositoryBdImpl<Details>, IDetailsRepository
    {
        public DetailsRepository(IDataBase dataBase) : base(dataBase)
        {
        }

        protected override string GetColumnNames()
        {
            return "qte_dette, dette_id, article_id, createAt, updateAt";
        }

        protected override string GetParameterNames()
        {
            return "@qte_dette, @dette_id, @article_id, @createAt, @updateAt";
        }

        protected override string GetUpdateColumns()
        {
            return "qte_dette = @qte_dette, dette_id = @dette_id, article_id = @article_id, updateAt = @updateAt";
        }

        protected override Details MapEntity(MySqlDataReader reader)
        {
            return new Details
            {
                Id = reader.GetInt32("id"),
                QteDette = reader.GetDouble("qte_dette"),
                Dette = new Dette { Id = reader.GetInt32("dette_id") }, // Chargement léger de Dette
                Article = new Article { Id = reader.GetInt32("article_id") } // Chargement léger de Article
            };
        }

        protected override void SetInsertParameters(MySqlCommand cmd, Details entity)
        {
            cmd.Parameters.AddWithValue("@qte_dette", entity.QteDette);
            cmd.Parameters.AddWithValue("@dette_id", entity.Dette?.Id);
            cmd.Parameters.AddWithValue("@article_id", entity.Article?.Id);
             cmd.Parameters.AddWithValue("@createAt", DateTime.Now);
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now);
        }

        protected override void SetUpdateParameters(MySqlCommand cmd, Details entity)
        {
            cmd.Parameters.AddWithValue("@qte_dette", entity.QteDette);
            cmd.Parameters.AddWithValue("@dette_id", entity.Dette?.Id);
            cmd.Parameters.AddWithValue("@article_id", entity.Article?.Id);
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now);

        }
    }
}
