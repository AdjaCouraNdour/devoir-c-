using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using GestionBoutiqueC.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public List<Client> FindAll()
        {
            return clientRepository.SelectAll();
        }

        public Client FindById(int id)
        {
            return clientRepository.SelectById(id);
        }

        public void Save(Client client)
        {
            clientRepository.Insert(client);
        }

        public void Delete(int id)
        {
            clientRepository.Delete(id);
        }

        public void Update(Client client)
        {
            clientRepository.Update(client);
        }

    }
}
