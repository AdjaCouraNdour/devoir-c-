using GestionBoutiqueC.data.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.data.entities
{
    public class Article
    {
        private int id;
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
            id = nbr;
        }

        public int Id { get => id; set => id = value; }
        public string Libelle { get => libelle; set => libelle = value; }
        public string Reference { get => reference; set => reference = value; }
        public int Prix { get => prix; set => prix = value; }
        //public double QteStock { get => qteStock; set => qteStock = value; }
        public EtatArticle EtatArticle { get => etatArticle; set => etatArticle = value; }
        public static int Nbr { get => nbr; set => nbr = value; }

        public void ListeDetails(Details details)
        {
            etatArticle = qteStock == 0 ? EtatArticle.Indisponible : EtatArticle.Disponible;
            listeDetails.Add(details);
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
                    "id=" + id +
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
                   id == article.id &&
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
