using GestionBoutiqueC.core;
using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.repository.List
{
    public class DetteRepository : RepositoryImpl<Dette>, IDetteRepository
    {
       public List<Dette> SelectDettesByClient(Client client)
        {
            List<Dette> dettes = new List<Dette>();
            
            foreach (var dette in list)  
                if (dette.Client == client)  
                {
                    dettes.Add(dette); 
                }
            return dettes; 
        }

        public List<Dette> SelectDettesByClientId(int clientId)
        {
            throw new NotImplementedException();
        }
    }
}
