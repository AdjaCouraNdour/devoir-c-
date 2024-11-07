using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.data.enums;
using GestionBoutiqueC.repository.interfaces;
using GestionBoutiqueC.services.interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public List<Article> FindAll()
        {
            return articleRepository.SelectAll();
        }

        public Article FindById(int id)
        {
            return articleRepository.SelectById(id);
        }

        public void Save(Article article)
        {
            articleRepository.Insert(article);
        }

        public void Delete(int id)
        {
            articleRepository.Delete(id);
        }

        public void Update(Article article)
        {
            articleRepository.Update(article);
        }

        public List<Article> FindByEtat(EtatArticle etat)
        {
            return articleRepository.SelectByEtat(etat);
        }
    }
}
