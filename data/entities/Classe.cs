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
    public class Classe : IIdentifiable
    {
        private string libelle;
    private string filiere;

    private static int nbr;
    private int id;
    public Classe()
        {
            nbr++;
            id = nbr;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
    public int Id { get => id; set => id = value; }
    public static int Nbr { get; set; }
    public string Libelle { get => libelle; set => libelle = value; }
    public string Filiere { get => filiere; set => filiere = value; }

    // Liste des étudiants inscrits dans la classe
    public List<Inscription> Inscriptions { get; set; } = new List<Inscription>();

    // Liste des cours associés à la classe
    public List<Cours> Cours { get; set; } = new List<Cours>();

    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    }

}
