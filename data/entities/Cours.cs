using GestionBoutiqueC.data.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.data.entities
{
    public class Cours :IIdentifiable
    {
        private string libelle;
    private DateTime date;
    private TimeSpan heureDebut;
    private TimeSpan heureFin;
    private int nbHeures;
    private string semestre;

    private static int nbr;
    private int id;
    public Cours ()
        {
            nbr++;
            id = nbr;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
    public int Id { get => id; set => id = value; }
    public static int Nbr { get; set; }
    public string Libelle { get => libelle; set => libelle = value; }
    public DateTime Date { get => date; set => date = value; }
    public TimeSpan HeureDebut { get => heureDebut; set => heureDebut = value; }
    public TimeSpan HeureFin { get => heureFin; set => heureFin = value; }
    public int NbHeures { get => nbHeures; set => nbHeures = value; }
    public string Semestre { get => semestre; set => semestre = value; }

    // Relation avec le professeur
    public Professeur Professeur { get; set; }

    // Relation avec les classes (un cours peut être enseigné à plusieurs classes)
    public List<Classe> Classes { get; set; } = new List<Classe>();

    // Relation avec le module
    public Module Module { get; set; }

    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    }
}
