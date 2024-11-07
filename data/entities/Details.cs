using GestionBoutiqueC.data.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GestionBoutiqueC.data.entities
{
    public class Details
    {
        private int id;
        private double qteDette;
        private Dette dette;
        private Article article;
        private static int nbr;
        public Details()
        {
            nbr++;
            id = nbr;
        }
        public int Id { get => id; set => id = value; }
        public double QteDette { get => qteDette; set => qteDette = value; }
        public Dette Dette { get => dette; set => dette = value; }
        public Article Article { get => article; set => article = value; }
        public static int Nbr { get => nbr; set => nbr = value; }




        public override String ToString()
        {
            return "Details{" +
                    "id=" + id + // Ajoute l'ID depuis AbstractEntity
                    ", qteDette=" + qteDette +
                    ", detteId=" + (dette != null ? dette.Id : "null") + // Affiche l'ID de la dette si elle n'est pas null
                    ", article=" + (article != null ? article.Libelle : "null") + // Affiche l'ID de l'article si elle n'est pas null
                    '}';
        }

        public override bool Equals(object? obj)
        {
            return obj is Details details &&
                   id == details.id &&
                   qteDette == details.qteDette &&
                   Id == details.Id &&
                   QteDette == details.QteDette;
        }
    }
}
