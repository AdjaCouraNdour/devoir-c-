using GestionBoutiqueC.data.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.data.entities
{
    public class Article :IIdentifiable
    {
        // private int id;
        private String reference;
        private String libelle;
        private int prix ;
        private Double qteStock;
        private EtatArticle etatArticle;
        private static int nbr;
        private List<Details> listeDetails = new List<Details>();


        public Article()
        {
            nbr++;
            Id = nbr;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
            Reference = $"A{Id:D5}";
        }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int Id { get; set; }

        // public int Id { get => Id; set => Id = value; }
        public string Libelle { get => libelle; set => libelle = value; }
        public string Reference { get => reference; set => reference = value; }
        public int Prix { get => prix; set => prix = value; }
        //public double QteStock { get => qteStock; set => qteStock = value; }
        public EtatArticle EtatArticle { get => etatArticle; set => etatArticle = value; }
        public static int Nbr { get => nbr; set => nbr = value; }
        public IEnumerable<Details>? Details { get ; } = new List<Details>() ;
        public void AddDetails(Details details)
        {
            etatArticle = qteStock == 0 ? EtatArticle.Indisponible : EtatArticle.Disponible;
            details.Article=this; // Associer l'article à cette dette
            Details.Append<Details>(details);
        }
        public double QteStock
        {
            get => qteStock;
            set
            {
                qteStock = value;
                etatArticle = qteStock == 0 ? EtatArticle.Indisponible : EtatArticle.Disponible;
            }
        }


        //public void RemoveDetails(Details details)
        //{
        //    this.qteStock += details.QteDette;
        //    if (this.qteStock > 0)
        //    {
        //        this.etatArticle = EtatArticle.Disponible;
        //    }
        //    else
        //    {
        //        this.etatArticle = EtatArticle.Indisponible;
        //    }
        //    listeDetails.Remove(details);
        //}

        
        public override String ToString()
        {
            return "Article{" +
                    "id=" + Id +
                    ", reference='" + reference +
                    ", libelle='" + libelle +
                    ", prix=" + prix +
                    ", qteStock=" + qteStock +
                    ", etatArticle=" + etatArticle +
                    '}';
        }

        public override bool Equals(object? obj)
        {
            return obj is Article article &&
                   Id == article.Id &&
                   reference == article.reference &&
                   libelle == article.libelle &&
                   prix == article.prix &&
                   qteStock == article.qteStock &&
                   etatArticle == article.etatArticle &&
                   Id == article.Id &&
                   Libelle == article.Libelle &&
                   Reference == article.Reference &&
                   Prix == article.Prix &&
                   QteStock == article.QteStock &&
                   EtatArticle == article.EtatArticle;
        }
    }
}
