
using GestionBoutiqueC.data.enums;
using GestionBoutiqueC.repository.interfaces;
using GestionBoutiqueC.services;
using GestionBoutiqueC.services.interfaces;

namespace GestionBoutiqueC.core.Factory
{   
    public class FactoryService 
    {
        private static IEtudiantRepository etudiantRepository = FactoryRepo.createEtudiantRepository(Persistence.Database)!  ;
         private static IAbsenceRepository AbsenceRepository = FactoryRepo.createAbsenceRepository(Persistence.Database)!  ;


        public static IEtudiantService? createEtudiantService()
        {
            IEtudiantService? etudiantService;
            etudiantService = new EtudiantService(etudiantRepository);
            return etudiantService;
        } 
         public static IAbsenceService? createAbsenceService()
        {
            IAbsenceService? AbsenceService;
            AbsenceService = new AbsenceService(AbsenceRepository);
            return AbsenceService;
        } 
      
        
    }

}