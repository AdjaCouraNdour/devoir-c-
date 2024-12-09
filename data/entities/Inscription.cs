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
    public class Inscription : IIdentifiable
    {
  public DateTime DateInscription { get; set; }

    // Relation avec l'étudiant
    public Etudiant Etudiant { get; set; }

    // Relation avec la classe
    public Classe Classe { get; set; }

    // Relation avec l'année académique
    public string AnneeAcademique { get; set; }
 private static int nbr;
    private int id;
    public Inscription()
        {
            nbr++;
            id = nbr;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
    public int Id { get => id; set => id = value; }
    public static int Nbr { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    }

}
