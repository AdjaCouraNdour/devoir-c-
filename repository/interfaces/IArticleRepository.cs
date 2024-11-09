using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GestionBoutiqueC.core;
using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.data.enums;


namespace GestionBoutiqueC.repository.interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        List<Article>? SelectByEtat(EtatArticle etat);
    }
}
