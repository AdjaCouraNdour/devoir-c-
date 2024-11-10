using GestionBoutiqueC.repository;
using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.data.enums;
using GestionBoutiqueC.services.interfaces;
using GestionBoutiqueC.views;
using GestionBoutiqueC.core.Factory;

namespace GestionBoutiqueC
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // IDataBase dataBase =new DataBase();
            // IClientRepository clientRepository = new ClientRepositoryBd(dataBase);

            IClientService clientService = FactoryService.createClientService()!;
            IUserService userService = FactoryService.createUserService()!;
            IArticleService articleService = FactoryService.createArticleService()!;
            IDetteService detteService = FactoryService.createDetteService()!;
            IDetailsService detailsService = FactoryService.createDetailsService()!;

            int choice;
            do
            {
                choice = MenuAcceuil();
                switch (choice)
                {
                    case 1:
                        int choiceClient;
                        do
                        {
                            choiceClient = MenuClient();
                            switch (choiceClient)
                            {
                                case 1:
                                    Client client = ClientView.CreateClient();
                                    while (clientService.FindByTelephone(client.Telephone) != null)
                                    {
                                        Console.WriteLine("Ce numéro existe déjà, veuillez en saisir un autre : ");
                                        client.Telephone = Console.ReadLine();
                                    }
                                    clientService.Save(client);
                                    break;
                                case 2:
                                    ClientView.ListClients(clientService.FindAll());
                                    break;
                                case 3:
                                    ClientView.ListClients(clientService.FindAll());
                                    Client client1 = clientService.FindById(ClientView.SaisirId());
                                    if (client1 != null)
                                    {
                                        ClientView.UpdateClient(client1);
                                        clientService.Update(client1);
                                    }
                                    break;
                                case 4:
                                    ClientView.ListClients(clientService.FindAll());
                                    Client client2 = clientService.FindById(ClientView.SaisirId());
                                    if (client2 != null)
                                        clientService.Delete(client2.Id);

                                    break;
                                case 0:
                                    Console.WriteLine("Au revoir!");
                                    break;
                                default:
                                    Console.WriteLine("Choix invalide!");
                                    break;
                            }
                          
                        } while (choiceClient != 0);
                        break;
                    case 2:
                        int choiceUser;
                        do
                        {
                            choiceUser = MenuUser();
                            switch (choiceUser)
                            {
                                case 1:
                                    
                                    Console.WriteLine("1- Pour un client existant");
                                    Console.WriteLine("2- Nouveau User");
                                    if (UserView.ChoiceToContinue() == 1)
                                    {
                                        ClientView.ListClients(clientService.FindAll());
                                        Client client = clientService.FindById(ClientView.SaisirId());

                                        if (client != null && client.User == null)
                                        {
                                            User user = UserView.CreateUserForClient();

                                            while (userService.FindByEmail(user.Email) != null)
                                            {
                                                Console.WriteLine("Cet Email existe déjà, veuillez en saisir un autre : ");
                                                user.Email = Console.ReadLine();
                                            }

                                            do
                                            {
                                                if (userService.FindByLogin(user.Login) != null)
                                                {
                                                    Console.WriteLine("Ce Login existe déjà, veuillez en saisir un autre : ");
                                                    user.Login = Console.ReadLine();
                                                }
                                            } while (userService.FindByLogin(user.Login) != null);

                                            // Associer l'utilisateur au client et sauvegarder
                                            user.Client = client;
                                            client.User = user;
                                            userService.Save(user);

                                            Console.WriteLine("Utilisateur créé avec succès !");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Client non trouvé ou possede deja un compte.");
                                        }

                                    }
                                    else
                                    {
                                        User user = UserView.CreateUserWithChoice();
                                        while (userService.FindByEmail(user.Email) != null)
                                        {
                                            Console.WriteLine("Cet Email existe déjà, veuillez en saisir un autre : ");
                                            user.Email = Console.ReadLine();
                                        }

                                        do
                                        {
                                            if (userService.FindByLogin(user.Login) != null)
                                            {
                                                Console.WriteLine("Ce Login existe déjà, veuillez en saisir un autre : ");
                                                user.Login = Console.ReadLine();
                                            }
                                        } while (userService.FindByLogin(user.Login) != null);
                                        userService.Save(user);
                                    }
                                    break;
                                case 2:
                                    UserView.ListUsers(userService.FindAll());
                                    break;
                                case 3:
                                    UserView.ListUsers(userService.FindAll());
                                    User user1 = userService.FindById(UserView.SaisirId());
                                    if (user1 != null)
                                    {
                                        UserView.UpdateUser(user1);
                                        userService.Update(user1);
                                    }
                                    break;
                                case 4:
                                    UserView.ListUsers(userService.FindAll());
                                    User user2 = userService.FindById(UserView.SaisirId());
                                    if (user2 != null)
                                        userService.Delete(user2.Id);

                                    break;
                                case 0:
                                    Console.WriteLine("Au revoir!");
                                    break;
                                default:
                                    Console.WriteLine("Choix invalide!");
                                    break;
                                }
                            }while (choiceUser != 0) ;
                        break;
                    case 3:
                        int choiceArticle;
                        do
                        {
                            choiceArticle = MenuArticle();
                            switch (choiceArticle)
                            {
                                case 1:
                                    Article art = ArticleView.CreateArticle();
                                    articleService.Save(art);
                                    break;
                                case 2:
                                    ArticleView.ListArticles(articleService.FindAll());
                                    break;
                                case 3:
                                    ArticleView.ListArticles(articleService.FindAll());
                                    Article art1 = articleService.FindById(ArticleView.SaisirId());
                                    if (art1 != null)
                                    {
                                        ArticleView.UpdateArticle(art1);
                                        articleService.Update(art1);
                                    }
                                    break;
                                case 4:
                                    ArticleView.ListArticles(articleService.FindAll());
                                    Article art2 = articleService.FindById(ArticleView.SaisirId());
                                    if (art2 != null)
                                        articleService.Delete(art2.Id);

                                    break;
                                case 0:
                                    Console.WriteLine("Au revoir!");
                                    break;
                                default:
                                    Console.WriteLine("Choix invalide!");
                                    break;
                            }
                        } while (choiceArticle != 0);
                        break;
                    case 4:
                        int choiceDette;
                        do
                        {
                            choiceDette = MenuDette();
                            switch (choiceDette)
                            {
                                case 1:
                                    ClientView.ListClients(clientService.FindAll());
                                    Client client = clientService.FindById(ClientView.SaisirId());
                                    if (client != null)
                                    {
                                        ArticleView.ListArticles(articleService.FindAll());
                                        Article art = articleService.FindById(ArticleView.SaisirId());
                                        if (art != null)
                                        {
                                            Details details = new Details();
                                            Dette dette = new Dette();

                                            double qteDette;
                                            do
                                            {
                                                Console.Write("Quantité de dette : ");
                                                qteDette = double.Parse(Console.ReadLine());
                                                if (qteDette > 0 && qteDette <= art.QteStock)
                                                {
                                                    details.QteDette = qteDette;
                                                    details.Article = art;
                                                    art.AddDetails(details);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Veuillez entrer une quantité valide.");
                                                }

                                            } while (qteDette <= 0 || qteDette > art.QteStock);
                                            dette.TypeDette = TypeDette.nonSolde;
                                            dette.EtatDette = EtatDette.EnCours;

                                            dette.Client = client;
                                            dette.AddDetails(details);
                                            dette.Montant = details.QteDette * art.Prix;
                                            dette.MontantVerse = 0;
                                            dette.MontantRestant = dette.Montant - dette.MontantRestant;
                                            art.QteStock = art.QteStock - details.QteDette;
                                            detteService.Save(dette);
                                            client.AddDette(dette);

                                        }
                                        else
                                        {
                                            Console.WriteLine("article inexistant");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("client pas trouve");
                                    }
                                    break;
                                case 2:
                                    ClientView.ListClients(clientService.FindAll());
                                    Client client1 = clientService.FindById(ClientView.SaisirId());
                                    if (client1 != null)
                                    {
                                        List<Dette> dettes = detteService.GetDettesByClient(client1);
                                        if (dettes !=null)
                                            {
                                                Console.WriteLine("Liste des dettes du client:");
                                                foreach (var dette in dettes)
                                                {
                                                    Console.WriteLine(dette);
                                                    // Affichez d'autres informations si nécessaire
                                                }   
                                            }
                                        else
                                        {
                                            Console.WriteLine("ce client n'a pas de dette ");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ce client n'existe pas");
                                    }                       
                                    break;
                                case 0:
                                    Console.WriteLine("Au revoir!");
                                    break;
                                default:
                                    Console.WriteLine("Choix invalide!");
                                    break;
                            }
                        } while (choiceDette != 0);
                        break;
                }
            } while (choice != 0);
        }
                 

        public static int MenuAcceuil()
        {
            Console.WriteLine("1. Client");
            Console.WriteLine("2. User");
            Console.WriteLine("3. Article");
            Console.WriteLine("4. Dette");
            Console.WriteLine("5. Paiement");
            Console.WriteLine("0. Quitter");
            Console.Write("Votre choix : ");
            // return int.Parse(Console.ReadLine());
            // double.Parse(Console.ReadLine());
            return Convert.ToInt32(Console.ReadLine());
        }

        public static int MenuClient()
        {
            Console.WriteLine("1. Créer un client");
            Console.WriteLine("2. Afficher tous les clients");
            Console.WriteLine("3. Modifier un client");
            Console.WriteLine("4. Supprimer un client");
            Console.WriteLine("0. Quitter");
            Console.Write("Votre choix : ");
            // return int.Parse(Console.ReadLine());
            // double.Parse(Console.ReadLine());
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int MenuUser()
        {
            Console.WriteLine("1. Créer un user");
            Console.WriteLine("2. Afficher tous les users");
            Console.WriteLine("3. Modifier un user");
            Console.WriteLine("4. Supprimer un user");
            Console.WriteLine("0. Quitter");
            Console.Write("Votre choix : ");
            // return int.Parse(Console.ReadLine());
            // double.Parse(Console.ReadLine());
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int MenuArticle()
        {
            Console.WriteLine("1. Créer un article");
            Console.WriteLine("2. Afficher tous les articles");
            Console.WriteLine("3. Modifier un article");
            Console.WriteLine("4. Supprimer un article");
            Console.WriteLine("0. Quitter");
            Console.Write("Votre choix : ");
            // return int.Parse(Console.ReadLine());
            // double.Parse(Console.ReadLine());
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int MenuDette()
        {
            Console.WriteLine("1. Faire une dette");
            Console.WriteLine("2. Afficher les dette solde");
            Console.WriteLine("0. Quitter");
            Console.Write("Votre choix : ");
            // return int.Parse(Console.ReadLine());
            // double.Parse(Console.ReadLine());
            return Convert.ToInt32(Console.ReadLine());
        }
         public static int MenuPaiement()
        {
            Console.WriteLine("1. Faire un paiement");
            Console.WriteLine("2. Afficher les dette nonsolde");
            Console.WriteLine("0. Quitter");
            Console.Write("Votre choix : ");
            // return int.Parse(Console.ReadLine());
            // double.Parse(Console.ReadLine());
            return Convert.ToInt32(Console.ReadLine());
        }
    }

}