using GestionBoutiqueC.data.entities;
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

    }
}
