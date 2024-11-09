using GestionBoutiqueC.core;
using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.repository
{
    public class ClientRepository : RepositoryImpl<Client>, IClientRepository
    {
        public Client SelectByTelephone(string telephone)
        {
            foreach (var client in list)
            {
                if (client.Telephone== telephone)
                    return client;
            }
            return null;
        }

    }
}
