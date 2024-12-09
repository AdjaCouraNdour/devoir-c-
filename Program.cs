using GestionBoutiqueC.repository;
using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.data.enums;
using GestionBoutiqueC.services.interfaces;
using GestionBoutiqueC.views;
using GestionBoutiqueC.core.Factory;
using GestionBoutiqueC.services;

namespace GestionBoutiqueC
{
    internal class Program
    {
        public static void Main(string[] args)
{
    // Initialisation des services
    IEtudiantService etudiantService = FactoryService.createEtudiantService()!; 
        IAbsenceService absenceService = FactoryService.createAbsenceService()!; 

    int choice;

                do
                {
                    choice = MenuAccueil();
                    switch (choice)
                    {
                        case 1:
                            EtudiantView.ListEtudiant(etudiantService.FindAll());
                            Etudiant etudiant = etudiantService.FindById(EtudiantView.SaisirId());
                            break;

                        case 2:
                            EtudiantView.ListEtudiant(etudiantService.FindAll());
                            Etudiant etudiant1 = etudiantService.FindById(EtudiantView.SaisirId());
                            List<Absence> ListAbsence = absenceService.FindByEtudiantId(etudiant1.Id);
                            if (ListAbsence.Any())
                            {
                                Console.WriteLine("Absences de l'étudiant :");
                                foreach (var absence in ListAbsence)
                                {
                                    Console.WriteLine(absence);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Aucune absence trouvée pour cet étudiant.");
                            }
                            break;
                        case 0:
                            Console.WriteLine("Au revoir!");
                            break;
                        default:
                            Console.WriteLine("Choix invalide!");
                            break;
                    }
                } while (choice != 0);
               
}

        public static int MenuAccueil()
        {
            Console.WriteLine("1. Lister les cours dun etudint");
            Console.WriteLine("2. lister les absences dun etudiant");
            Console.Write("Votre choix : ");
            // return int.Parse(Console.ReadLine());
            // double.Parse(Console.ReadLine());
            return Convert.ToInt32(Console.ReadLine());
        }

      
    }

}