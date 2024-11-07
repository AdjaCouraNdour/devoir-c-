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
    public class DetailsService : IDetailsService
    {
        private readonly IDetailsRepository detailsRepository;

        public DetailsService(IDetailsRepository detailsRepository)
        {
            this.detailsRepository = detailsRepository;
        }

        public List<Details> FindAll()
        {
            return detailsRepository.SelectAll();
        }

        public Details FindById(int id)
        {
            return detailsRepository.SelectById(id);
        }

        public void Save(Details details)
        {
            detailsRepository.Insert(details);
        }

        public void Delete(int id)
        {
            detailsRepository.Delete(id);
        }

        public void Update(Details details)
        {
            detailsRepository.Update(details);
        }

    }
}
