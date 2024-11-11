using GestionBoutiqueC.core.Database;
using GestionBoutiqueC.data.enums;
using GestionBoutiqueC.repository.Bd;
using GestionBoutiqueC.repository.List;
using GestionBoutiqueC.repository.interfaces;

namespace GestionBoutiqueC.core.Factory
{
    public static class FactoryRepo {
        public static IClientRepository? createClientRepository(Persistence type)
        {
            IClientRepository? clientRepository;
            switch (type)
            {
                case Persistence.Database:
                    clientRepository = new ClientRepositoryBd(new DataBase());
                    break;
                case Persistence.List:
                    clientRepository = new ClientRepository();
                    break;
                default:
                    clientRepository = null;
                    break;
            }
            return clientRepository;
        }
        public static IArticleRepository? createArticleRepository(Persistence type)
        {
            IArticleRepository? articleRepository;
            switch (type)
            {
                case Persistence.Database:
                    articleRepository = new ArticleRepositoryBd(new DataBase());
                    break;
                case Persistence.List:
                    articleRepository = new ArticleRepository();
                    break;
                default:
                    articleRepository = null;
                    break;
            }
            return articleRepository;
        }
        public static IDetteRepository? createDetteRepository(Persistence type)
        {
            IDetteRepository? detteRepository;
            switch (type)
            {
                case Persistence.Database:
                    detteRepository = new DetteRepositoryBd(new DataBase(),createClientRepository(type),createArticleRepository(type));
                    break;
                case Persistence.List:
                    detteRepository = new DetteRepository();
                    break;
                default:
                    detteRepository = null;
                    break;
            }
            return detteRepository;
        }
          public static IPaiementRepository? createPaiementRepository(Persistence type)
        {
            IPaiementRepository? paiementRepository;
            switch (type)
            {
                case Persistence.Database:
                    paiementRepository = new PaiementRepositoryBd(new DataBase(),createDetteRepository(type));
                    break;
                case Persistence.List:
                    paiementRepository = new PaiementRepository();
                    break;
                default:
                    paiementRepository = null;
                    break;
            }
            return paiementRepository;
        }
          public static IUserRepository? createUserRepository(Persistence type)
        {
            IUserRepository? userRepository;
            switch (type)
            {
                case Persistence.Database:
                    userRepository = new UserRepositoryBd(new DataBase());
                    break;
                case Persistence.List:
                    userRepository = new UserRepository();
                    break;
                default:
                    userRepository = null;
                    break;
            }
            return userRepository;
        }
         public static IDetailsRepository? createDetailsRepository(Persistence type)
        {
            IDetailsRepository? detailsRepository;
            switch (type)
            {
                case Persistence.Database:
                    detailsRepository = new DetailsRepositoryBd(new DataBase(),createDetteRepository(type),createArticleRepository(type));
                    break;
                case Persistence.List:
                    detailsRepository = new DetailsRepository();
                    break;
                default:
                    detailsRepository = null;
                    break;
            }
            return detailsRepository;
        }
    }
}