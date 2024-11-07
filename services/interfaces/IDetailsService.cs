using GestionBoutiqueC.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.services.interfaces
{
    public interface IDetailsService
    {
        List<Details> FindAll();
        Details FindById(int id);
        void Save(Details details);
        void Delete(int id);
        void Update(Details details);

    }
}
