using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GestionBoutiqueC.core;
using GestionBoutiqueC.data.entities;


namespace GestionBoutiqueC.repository.interfaces
{
    public interface IDetteRepository : IRepository<Dette>
    {
        List<Dette> SelectDettesByClientId(int clientId);
        List<Dette> SelectDettesByClient(Client client);

    }
}
