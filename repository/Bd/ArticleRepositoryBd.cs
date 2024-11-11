using GestionBoutiqueC.core;
using GestionBoutiqueC.core.Database;
using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.data.enums;
using GestionBoutiqueC.repository.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GestionBoutiqueC.repository.Bd
{
    public class ArticleRepositoryBd : RepositoryBdImpl<Article>, IArticleRepository
    {
        public ArticleRepositoryBd(IDataBase dataBase) : base(dataBase)
        {
        }

        public List<Article>? SelectByEtat(EtatArticle etat)
        {
            List<Article>? articles = new List<Article>();
            string query = $"SELECT * FROM article WHERE etat_article = @etat";
            using (var conn = dataBase.getConnection())
            {
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@etat", etat.ToString());
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            articles.Add(MapEntity(reader));
                        }
                    }
                }
            }
            return articles;
        }

        protected override string GetColumnNames()
        {
            return "reference, libelle, prix, qte_stock, etat_article, createAt, updateAt";
        }

        protected override string GetParameterNames()
        {
            return "@reference, @libelle, @prix, @qte_stock, @etat_article, @createAt, @updateAt";
        }

        protected override string GetUpdateColumns()
        {
            return "reference = @reference, libelle = @libelle, prix = @prix, qte_stock = @qte_stock, etat_article = @etat_article, updateAt = @updateAt";
        }

        protected override Article MapEntity(MySqlDataReader reader)
        {
            return new Article
            {
                Id = reader.GetInt32("id"),
                Reference = reader.GetString("reference"),
                Libelle = reader.GetString("libelle"),
                Prix = reader.GetInt32("prix"),
                QteStock = reader.GetDouble("qte_stock"),
                // EtatArticle = Enum.Parse<EtatArticle>(reader.GetString("etat_article"))
                EtatArticle = EtatArticleExtensions.GetEtatArticleById(reader.GetInt32("etat_article")).GetValueOrDefault()

            };
        }

        protected override void SetInsertParameters(MySqlCommand cmd, Article entity)
        {
            cmd.Parameters.AddWithValue("@reference", entity.Reference);
            cmd.Parameters.AddWithValue("@libelle", entity.Libelle);
            cmd.Parameters.AddWithValue("@prix", entity.Prix);
            cmd.Parameters.AddWithValue("@qte_stock", entity.QteStock);
            cmd.Parameters.AddWithValue("@etat_article", entity.EtatArticle.ToString());
            cmd.Parameters.AddWithValue("@createAt", DateTime.Now);
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now);
        }

        protected override void SetUpdateParameters(MySqlCommand cmd, Article entity)
        {
            cmd.Parameters.AddWithValue("@reference", entity.Reference);
            cmd.Parameters.AddWithValue("@libelle", entity.Libelle);
            cmd.Parameters.AddWithValue("@prix", entity.Prix);
            cmd.Parameters.AddWithValue("@qte_stock", entity.QteStock);
            cmd.Parameters.AddWithValue("@etat_article", entity.EtatArticle.ToString());
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        }
    }
}
