using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using GestionBoutiqueC.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionBoutiqueC.services
{
    public class DetteService : IDetteService
    {
        private readonly IDetteRepository detteRepository;

        public DetteService(IDetteRepository detteRepository)
        {
            this.detteRepository = detteRepository;
        }

        public List<Dette> FindAll()
        {
            return detteRepository.SelectAll();
        }

        public Dette FindById(int id)
        {
            return detteRepository.SelectById(id);
        }

        public void Save(Dette dette)
        {
            detteRepository.Insert(dette);
        }

        public void Delete(int id)
        {
            detteRepository.Delete(id);
        }

        public void Update(Dette dette)
        {
            detteRepository.Update(dette);
        }
        // public List<Dette> GetDettesByClientId(int clientId)
        // {
        //     return detteRepository.SelectDettesByClientId(clientId);
        // }

        public List<Dette> GetDettesByClient(Client client)
        {
            return detteRepository.SelectDettesByClient(client);
        }

    
    }
}
