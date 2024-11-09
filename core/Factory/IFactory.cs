using GestionBoutiqueC.repository.interfaces;

namespace GestionBoutiqueC.core.Factory
{
    public interface IFactory {
        
            IClientRepository getInstanceRepoClient();
            IUserRepository getInstanceRepoUser();
            IArticleRepository getInstanceRepoArticle();
            IDetteRepository getInstanceRepoDette();
            IPaiementRepository getInstanceRepoPaiement();
            IDetailsRepository getInstanceRepoDetails();
    }
}