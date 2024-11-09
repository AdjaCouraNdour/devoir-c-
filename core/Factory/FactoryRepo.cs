// using GestionBoutiqueC.repository.interfaces;

// namespace GestionBoutiqueC.core.Factory
// {
//     public class FactoryRepo {
//         public static IClientRepository? createClientRepository(Persistence type)
//         {
//             IClientRepository? clientRepository;
//             switch (type)
//             {
//                 case Persistence.DATABASE:
//                     clientRepository = new ClientRepositoryBd(new DataBase());
//                     break;
//                 case Persistence.LIST:
//                     clientRepository = new ClientRepository();
//                     break;
//                 default:
//                     clientRepository = null;
//                     break;
//             }
//             return clientRepository;
//         }
//     }
// }