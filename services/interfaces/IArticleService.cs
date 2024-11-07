using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionBoutiqueC.data.enums;

namespace GestionBoutiqueC.services.interfaces
{
    public interface IArticleService: IService<Article>
    {
        List<Article> FindByEtat(EtatArticle etat);

    }
}
