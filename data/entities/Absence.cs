using GestionBoutiqueC.data.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GestionBoutiqueC.data.entities
{
    public class Absence:IIdentifiable
    {
    private int id ;
    private DateTime dateAbsence;
    public Etudiant etudiant ;
    public Cours cours ;
    private static int nbr;

     public Absence()
        {
            nbr++;
            id = nbr;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
        
    public DateTime DateAbsence { get => dateAbsence; set => dateAbsence = value; }

    public Etudiant Etudiant { get; set; }
    public Cours Cours { get; set; }
    public static int Nbr { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }        
    public int Id { get; set; }

       
    }
}
