using GestionBoutiqueC.core;
using GestionBoutiqueC.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.services.interfaces
{
    public interface IDetteService : IService<Dette>
    {
        // List<Dette> GetDettesByClientId(int clientId) ;
        List<Dette> GetDettesByClient(Client client);
    }
}
