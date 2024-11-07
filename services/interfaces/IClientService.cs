using GestionBoutiqueC.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.services.interfaces
{
    public interface IClientService
    {
        List<Client> FindAll();
        Client FindById(int id);
        void Save(Client client);
        void Delete(int id);
        void Update(Client client);

    }
}
