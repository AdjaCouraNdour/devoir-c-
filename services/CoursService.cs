using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using GestionBoutiqueC.services.interfaces;
using System;
using System.Collections.Generic;

namespace GestionBoutiqueC.services
{
    public class CoursService : ICoursService
    {
        private readonly ICoursRepository coursRepository;

        public CoursService(ICoursRepository coursRepository)
        {
            this.coursRepository = coursRepository;
        }

        public List<Cours> FindAll()
        {
            return coursRepository.SelectAll();
        }

        public Cours FindById(int id)
        {
            return coursRepository.SelectById(id);
        }

        public void Save(Cours cours)
        {
            coursRepository.Insert(cours);
        }

        public void Delete(int id)
        {
            coursRepository.Delete(id);
        }

        public void Update(Cours cours)
        {
            coursRepository.Update(cours);
        }

      
    }
}
