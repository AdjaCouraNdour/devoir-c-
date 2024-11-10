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
    public class PaiementService : IPaiementService
    {
        private readonly IPaiementRepository paiementRepository;

        public PaiementService(IPaiementRepository paiementRepository)
        {
            this.paiementRepository = paiementRepository;
        }

        public List<Paiement> FindAll()
        {
            return paiementRepository.SelectAll();
        }

        public Paiement FindById(int id)
        {
            return paiementRepository.SelectById(id);
        }

        public void Save(Paiement paiement)
        {
            paiementRepository.Insert(paiement);
        }

        public void Delete(int id)
        {
            paiementRepository.Delete(id);
        }

        public void Update(Paiement paiement)
        {
            paiementRepository.Update(paiement);
        }

    }
}
