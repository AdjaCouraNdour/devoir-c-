using GestionBoutiqueC.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.services.interfaces
{
    public interface IArticleService
    {
        List<Article> FindAll();
        Article FindById(int id);
        void Save(Article article);
        void Delete(int id);
        void Update(Article article);

    }
}
