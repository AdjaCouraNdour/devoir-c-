using GestionBoutiqueC.core.Database;
using GestionBoutiqueC.data.enums;
using GestionBoutiqueC.repository.Bd;
using GestionBoutiqueC.repository.interfaces;

namespace GestionBoutiqueC.core.Factory
{
    public static class FactoryRepo {
        public static IEtudiantRepository? createEtudiantRepository(Persistence type)
        {
            IEtudiantRepository? etudiantRepository;
            switch (type)
            {
                case Persistence.Database:
                    etudiantRepository = new EtudiantRepositoryBd(new DataBase());
                    break;
                default:
                    etudiantRepository = null;
                    break;
            }
            return etudiantRepository;
        }
         public static IAbsenceRepository? createAbsenceRepository(Persistence type)
        {
            IAbsenceRepository? AbsenceRepository;
            switch (type)
            {
                case Persistence.Database:
                    AbsenceRepository = new AbsenceRepositoryBd(new DataBase());
                    break;
                default:
                    AbsenceRepository = null;
                    break;
            }
            return AbsenceRepository;
        }

    }
}