using System;
using System.Collections.Generic;

namespace GestionBoutiqueC.data.entities
{
    public class Etudiant : IIdentifiable
    {
    private int id;
    private string matricule;
    private string nomComplet;
    private string adresse;
    private static int nbr;

    public int Id { get => id; set => id = value; }
    public static int Nbr { get; set; }

    public string Matricule { get => matricule; set => matricule = value; }
    public string NomComplet { get => nomComplet; set => nomComplet = value; }
    public string Adresse { get => adresse; set => adresse = value; }

    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }

    private List<Absence> listeAbsence = new List<Absence>();

        public Etudiant()
        {
            nbr++;
            id = nbr;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }


        public IEnumerable<Absence> Absences { get; } = new List<Absence>();

        public void AddDette(Absence absence)
        {
            absence.Etudiant = this;
            listeAbsence.Add(absence);
        }

        public IReadOnlyList<Absence> ListeDette()
        {
            return listeAbsence.AsReadOnly();
        }

       
    }
}
