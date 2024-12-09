using System;
using System.Collections.Generic;

namespace GestionBoutiqueC.data.entities
{
    public class Module : IIdentifiable
    {
        // Propriétés du module
        public string Libelle { get; set; }
        public string Description { get; set; }

        // Relation avec les cours
        public List<Cours> Cours { get; set; } = new List<Cours>();

        // Identifiant du module
        private static int nbr;
        private int id;

        public Module()
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
