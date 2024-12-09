using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using GestionBoutiqueC.services.interfaces;
using System;
using System.Collections.Generic;

namespace GestionBoutiqueC.services
{
    public class AbsenceService : IAbsenceService
    {
        private readonly IAbsenceRepository absenceRepository;

        public AbsenceService(IAbsenceRepository absenceRepository)
        {
            this.absenceRepository = absenceRepository;
        }

        public List<Absence> FindAll()
        {
            return absenceRepository.SelectAll();
        }

        public Absence FindById(int id)
        {
            return absenceRepository.SelectById(id);
        }

        public void Save(Absence absence)
        {
            absenceRepository.Insert(absence);
        }

        public void Delete(int id)
        {
            absenceRepository.Delete(id);
        }

        public void Update(Absence absence)
        {
            absenceRepository.Update(absence);
        }

        public List<Absence>? FindByEtudiantId(int etudiantId)
        {
           return absenceRepository.SelectByEtudiantId(etudiantId);

        }
    }
}
