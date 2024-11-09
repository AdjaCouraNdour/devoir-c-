using GestionBoutiqueC.core;
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
    public class ArticleRepository : RepositoryImpl<Article>, IArticleRepository
    {
        public List<Article> SelectByEtat(EtatArticle etat)
        {
            // Si l'état est null, retourner une liste vide
            if (etat == null)
            {
                return new List<Article>();
            }

            // Si la liste est vide ou null, retourner aussi une liste vide
            if (list == null || !list.Any())
            {
                return new List<Article>();
            }

            // Filtrer les list en fonction de l'état
            var result = list.Where(art => art.EtatArticle != null && art.EtatArticle == etat).ToList();

            // Si aucun article n'a été trouvé, retourner une liste vide
            if (!result.Any())
            {
                return new List<Article>();
            }

            return result;
        
        }
    }
}
