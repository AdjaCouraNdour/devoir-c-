using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.services;

namespace GestionBoutiqueC.views
{
    public abstract class AbsenceView
    {
        private AbsenceService absenceService;

        public AbsenceView(AbsenceService absenceService)
        {
            this.absenceService = absenceService;
        }

        // Méthode pour afficher la liste des absences
        public static void ListAbsences(List<Absence> absences)
        {
            foreach (var absence in absences)
            {
                Console.WriteLine(absence);
            }
        }
    }
}
