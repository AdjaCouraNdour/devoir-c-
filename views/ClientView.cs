using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.views
{
    public abstract class ClientView
    {
        private ClientService clientService;

        public ClientView(ClientService clientService)
        {
            this.clientService = clientService;
        }
        public static void ListClients(List<Client> clients)
        {
            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }
        }

        public static Client CreateClient()
        {
            Console.Write("Surnom : ");
            string surnom = Console.ReadLine();
            Console.Write("Téléphone : ");
            string telephone = Console.ReadLine();
            Console.Write("Adresse : ");
            string adresse = Console.ReadLine();
            return new Client { Surnom = surnom, Telephone = telephone, Adresse = adresse };
        }

        public static void UpdateClient(Client client)
        {

            Console.Write("Nouveau surnom : ");
            string newSurnom = Console.ReadLine();
            Console.Write("Nouveau téléphone : ");
            string newTelephone = Console.ReadLine();
            Console.Write("Nouvelle adresse : ");
            string newAdresse = Console.ReadLine();
            client.Surnom = newSurnom;
            client.Telephone = newTelephone;
            client.Adresse = newAdresse;
            Console.WriteLine("Client modifié!");
        }

        public static int DeleteClient()
        {
            Console.Write("Voulez-vous supprimer un client ? (o/n) ");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "o")
            {
                Console.Write("Id du client à supprimer : ");
                return Convert.ToInt32(Console.ReadLine());
            }
            return 0;

        }

        public static int SaisirId()
        {
            Console.WriteLine("Id du client ?");
            return Convert.ToInt32(Console.ReadLine());
        }

        public Client AskClient()
        {
            List<Client>  clients = clientService.FindAll();
            if (clients.Count == 0)
            {
                Console.WriteLine("Il n'y a pas encore de client. Veuillez en créer un d'abord.");
                return null;
            }
            else
            {
                Client client = null;
                do
                {
                    foreach (var cl in clients)
                    {
                        Console.WriteLine(cl); // Assurez-vous que la classe Client a une méthode ToString() pour un affichage clair.
                    }
                    Console.WriteLine("Veuillez choisir le client en entrant son ID (ou entrez 0 pour revenir à la liste) :");

                    if (int.TryParse(Console.ReadLine(), out int clientId))
                    {
                        if (clientId == 0)
                        {
                            Console.WriteLine("Demande annulée");
                            return null;
                        }

                        client = clientService.FindById(clientId);

                        if (client == null)
                        {
                            Console.WriteLine("Ce client n'existe pas. Veuillez entrer un ID valide.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Veuillez entrer un ID valide.");
                    }

                } while (client == null);

                return client;
            }
        }

    }
}
