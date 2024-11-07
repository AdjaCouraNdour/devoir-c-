using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly List<Client> clients = new List<Client>();

        public List<Client> SelectAll()
        {
            return clients;
        }
        public Client SelectById(int id)
        {
            foreach (var client in clients)
            {
                if (client.Id == id)
                    return client;
            }
            return null;
        }
        public void Insert(Client client)
        {
            clients.Add(client);
        }
        public void Update(Client client)
        {
            int position = clients.FindIndex(cl => cl.Id == client.Id);
            if (position != -1)
                clients[position] = client;
        }
        public void Delete(int id)
        {
            Client clientToRemove = clients.Find(cl => cl.Id == id);
            if (clientToRemove != null)
                clients.Remove(clientToRemove);
        }

    }
}
