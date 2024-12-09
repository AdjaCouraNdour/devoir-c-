using GestionBoutiqueC.data.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace GestionBoutiqueC.data.entities
{
    public class Professeur : IIdentifiable
    {
    private string nom;
    private string prenom;
    private string specialite;
    private string grade;
    private static int nbr;
    private int id;
    public Professeur()
        {
            nbr++;
            id = nbr;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
    public int Id { get => id; set => id = value; }
    public static int Nbr { get; set; }
    public string Nom { get => nom; set => nom = value; }
    public string Prenom { get => prenom; set => prenom = value; }
    public string Specialite { get => specialite; set => specialite = value; }
    public string Grade { get => grade; set => grade = value; }

    // Relation avec les cours enseignés par le professeur
    public List<Cours> Cours { get; set; } = new List<Cours>();

    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    }

}
