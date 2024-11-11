using GestionBoutiqueC.core;
using GestionBoutiqueC.core.Database;
using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GestionBoutiqueC.repository.Bd
{
    public class DetailsRepositoryBd : RepositoryBdImpl<Details>, IDetailsRepository
    {
        private IArticleRepository articleRepository;
        private IDetteRepository detteRepository;

        public DetailsRepositoryBd(IDataBase dataBase ,IDetteRepository detteRepository,IArticleRepository articleRepository): base(dataBase)
        {
            this.detteRepository = detteRepository;
            this.articleRepository = articleRepository;

        }

        // public DetailsRepositoryBd(IDataBase dataBase) : base(dataBase)
        // {
        // }

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
            Details details = new Details();
            details.Id = reader.GetInt32("id");
            details.QteDette = reader.GetDouble("qte_dette");

            // Récupération de l'objet Dette à partir de son ID
            int detteId = reader.GetInt32("dette_id");
            if (detteId > 0)
            {
                Dette dette = detteRepository.SelectById(detteId);
                details.Dette = dette;
            }

            // Récupération de l'objet Article à partir de son ID
            int articleId = reader.GetInt32("article_id");
            if (articleId > 0)
            {
                Article article = articleRepository.SelectById(articleId);
                details.Article = article;
            }

            return details;
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
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        }
    }
}
