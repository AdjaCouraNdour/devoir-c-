using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.services;


namespace GestionBoutiqueC.views
{
    public abstract class EtudiantView
    {
        private EtudiantService etudiantService;

        public EtudiantView(EtudiantService etudiantService)
        {
            this.etudiantService = etudiantService;
        }
        public static void ListEtudiant(List<Etudiant> etudiants)
        {
            foreach (var etudiant in etudiants)
            {
                Console.WriteLine(etudiant);
            }
        }

        public static int SaisirId()
        {
            Console.WriteLine("Id de letudiant ?");
            return Convert.ToInt32(Console.ReadLine());
        }
    
    }
}
