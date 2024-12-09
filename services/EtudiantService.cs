using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using GestionBoutiqueC.services.interfaces;
using System;
using System.Collections.Generic;

namespace GestionBoutiqueC.services
{
    public class EtudiantService : IEtudiantService
    {
        private readonly IEtudiantRepository etudiantRepository;

        public EtudiantService(IEtudiantRepository etudiantRepository)
        {
            this.etudiantRepository = etudiantRepository;
        }

        public List<Etudiant> FindAll()
        {
            return etudiantRepository.SelectAll();
        }

        public Etudiant FindById(int id)
        {
            return etudiantRepository.SelectById(id);
        }

        public void Save(Etudiant etudiant)
        {
            etudiantRepository.Insert(etudiant);
        }

        public void Delete(int id)
        {
            etudiantRepository.Delete(id);
        }

        public void Update(Etudiant etudiant)
        {
            etudiantRepository.Update(etudiant);
        }

      

       
    }
}
