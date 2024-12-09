using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GestionBoutiqueC.core;
using GestionBoutiqueC.data.entities;


namespace GestionBoutiqueC.repository.interfaces
{
    public interface IAbsenceRepository : IRepository<Absence>
    {
        public List<Absence>? SelectByEtudiantId(int etudiantId);

    }
}
