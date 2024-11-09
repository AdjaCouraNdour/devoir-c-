using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GestionBoutiqueC.data.entities
{
    public class Paiement:IIdentifiable
    {
        // public int id;
        private DateTime date;
        private double montant;
        private Dette dette;
        private static int nbr;

        public int Id { get; set; }

        // public int Id { get => Id; set => Id = value; }
        public DateTime DateTime { get => date; set => date = value; }
        public Dette Dette { get => dette; set => dette = value; }
        public double Montant { get => montant; set => montant = value; }
        public static int Nbr { get => nbr; set => nbr = value; }


        public Paiement()
        {
            nbr++;
            Id = nbr;
            date = DateTime.Now;
        }

        public override String ToString()
        {
            return "Paiement [id=" + Id + ", " +
                "date=" + date + ", " +
                "montant=" + montant + ", " +
                "dette=" + dette.Id + "]";
        }

        public override bool Equals(object? obj)
        {
            return obj is Paiement paiement &&
                   Id == paiement.Id &&
                   date == paiement.date &&
                   montant == paiement.montant &&
                   EqualityComparer<Dette>.Default.Equals(dette, paiement.dette) &&
                   Id == paiement.Id &&
                   DateTime == paiement.DateTime &&
                   EqualityComparer<Dette>.Default.Equals(Dette, paiement.Dette) &&
                   Montant == paiement.Montant;
        }
    }
}
