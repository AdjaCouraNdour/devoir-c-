using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.data.enums;
using GestionBoutiqueC.repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly List<Article> articles = new List<Article>();

        public List<Article> SelectAll()
        {
            return articles;
        }
        public Article SelectById(int id)
        {
            foreach (var article in articles)
            {
                if (article.Id == id)
                    return article;
            }
            return null;
        }
        public void Insert(Article article)
        {
            articles.Add(article);
        }
        public void Update(Article article)
        {
            int position = articles.FindIndex(art => art.Id == article.Id);
            if (position != -1)
                articles[position] = article;
        }
        public void Delete(int id)
        {
            Article articleToRemove = articles.Find(art => art.Id == id);
            if (articleToRemove != null)
                articles.Remove(articleToRemove);
        }

        //public List<Article> SelectByEtat(EtatArticle etat)
        //{
        //    if (etat == null)
        //    {
        //        return new List<Article>();
        //    }
        //    return articles.Where(art => art.EtatArticle != null && art.EtatArticle == etat).ToList();


        //}
        public List<Article> SelectByEtat(EtatArticle etat)
        {
            // Si l'état est null, retourner une liste vide
            if (etat == null)
            {
                return new List<Article>();
            }

            // Si la liste est vide ou null, retourner aussi une liste vide
            if (articles == null || !articles.Any())
            {
                return new List<Article>();
            }

            // Filtrer les articles en fonction de l'état
            var result = articles.Where(art => art.EtatArticle != null && art.EtatArticle == etat).ToList();

            // Si aucun article n'a été trouvé, retourner une liste vide
            if (!result.Any())
            {
                return new List<Article>();
            }

            return result;
        }

    }
}
