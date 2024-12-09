using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.services;

namespace GestionBoutiqueC.views
{
    public abstract class CoursView
    {
        private CoursService coursService;

        public CoursView(CoursService coursService)
        {
            this.coursService = coursService;
        }

        // Méthode pour afficher la liste des cours
        public static void ListCours(List<Cours> cours)
        {
            foreach (var c in cours)
            {
                Console.WriteLine(cours);
            }
        }
    }
}
