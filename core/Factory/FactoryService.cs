
using GestionBoutiqueC.data.enums;
using GestionBoutiqueC.repository.interfaces;
using GestionBoutiqueC.services;
using GestionBoutiqueC.services.interfaces;

namespace GestionBoutiqueC.core.Factory
{   
    public class FactoryService 
    {
        private static IClientRepository clientRepository = FactoryRepo.createClientRepository(Persistence.Database)!  ;
        private static IUserRepository userRepository = FactoryRepo.createUserRepository(Persistence.Database)!;
        private static IArticleRepository articleRepository =FactoryRepo.createArticleRepository(Persistence.Database)!;
        private static IDetteRepository detteRepository = FactoryRepo.createDetteRepository(Persistence.Database)!;
        private static IDetailsRepository detailsRepository = FactoryRepo.createDetailsRepository(Persistence.Database)!;
        private static IPaiementRepository paiementRepository = FactoryRepo.createPaiementRepository(Persistence.Database)!;

        public static IClientService? createClientService()
        {
            IClientService? clientService;
            clientService = new ClientService(clientRepository);
            return clientService;
        } 
        public static IUserService? createUserService()
        {
            IUserService? userService;
            userService = new UserService(userRepository);
            return userService;
        } 
        public static IArticleService? createArticleService()
        {
            IArticleService? articleService;
            articleService = new ArticleService(articleRepository);
            return articleService;
        } 
        public static IDetteService? createDetteService()
        {
            IDetteService? detteService;
            detteService = new DetteService(detteRepository);
            return detteService;
        } 
         public static IPaiementService? createPaiementService()
        {
            IPaiementService? paiementService;
            paiementService = new PaiementService(paiementRepository);
            return paiementService;
        } 
        public static IDetailsService? createDetailsService()
        {
            IDetailsService? detailsService;
            detailsService = new DetailsService(detailsRepository);
            return detailsService;
        }   
    }

}