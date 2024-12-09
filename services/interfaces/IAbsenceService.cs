using GestionBoutiqueC.core;
using GestionBoutiqueC.data.entities;

namespace GestionBoutiqueC.services.interfaces
{
    public interface IAbsenceService : IService<Absence>
    {
        public List<Absence>? FindByEtudiantId(int etudiantId);


    }
}
