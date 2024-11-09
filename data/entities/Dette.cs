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
    public class Dette : IIdentifiable
    {
        // private int id;

        private DateTime date;

        private double montant;

        private double montantVerse;

        private double montantRestant;

        private TypeDette typeDette;

        private EtatDette etatDette;


        private bool archiver;

        private Client client;

        private List<Details> listeDetails = new List<Details>();

        private List<Paiement> listePaiements = new List<Paiement>();
       
        private static int nbr;
        public Dette()
        {
            nbr++;
            Id = nbr;
            date = DateTime.Now;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int Id { get; set; }
        // public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }

        public double Montant { get => montant; set => montant = value; }
        public double MontantVerse { get => montantVerse; set => montantVerse = value; }
        public double MontantRestant { get => montantRestant; set => montantRestant = value; }
        public TypeDette TypeDette { get => typeDette; set => typeDette = value; }
        public EtatDette EtatDette { get => etatDette; set => etatDette = value; }

        public Client Client { get ; set; }
        public static int Nbr { get => nbr; set => nbr = value; }
        public IEnumerable<Details> Details { get ; } = new List<Details>() ;
        public IEnumerable<Paiement> Paiements { get ; } = new List<Paiement>() ;

        public void AddDetails(Details details)
        {
            details.Dette=this; // Associer le détail à cette dette
            Details.Append<Details>(details);
        }

        public void ListePaiement(Paiement paiement)
        {
            this.montantRestant = this.montantRestant - this.montantVerse;
            if (this.montantVerse == this.montant)
            {
                this.montantRestant = 0;
                this.typeDette = TypeDette.Solde;
            }
            else
            {
                this.typeDette = TypeDette.nonSolde;
            }
            Paiements.Append<Paiement>(paiement);
        }

        public override bool Equals(object? obj)
        {
            return obj is Dette dette &&
                   Id == dette.Id &&
                   date == dette.date &&
                   montant == dette.montant &&
                   montantVerse == dette.montantVerse &&
                   montantRestant == dette.montantRestant &&
                   typeDette == dette.typeDette &&
                   archiver == dette.archiver &&
                   EqualityComparer<Client>.Default.Equals(client, dette.client) &&
                   Id == dette.Id &&
                   Montant == dette.Montant &&
                   MontantVerse == dette.MontantVerse &&
                   MontantRestant == dette.MontantRestant &&
                   TypeDette == dette.TypeDette &&
                   EqualityComparer<Client>.Default.Equals(Client, dette.Client);
        }
    }
}
