using GestionBoutiqueC.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.services.interfaces
{
    public interface IDetteService
    {
        List<Dette> FindAll();
        Dette FindById(int id);
        void Save(Dette dette);
        void Delete(int id);
        void Update(Dette dette);

    }
}
