using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.data.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.views
{
    public abstract class ArticleView
    {

        public static void ListArticles(List<Article> articles)
        {
            foreach (var article in articles)
            {
                Console.WriteLine(article);
            }
        }

        public static Article CreateArticle()
        {
            Console.Write("Libelle : ");
            string libelle = Console.ReadLine();
            Console.Write("Prix : ");
            int prix;
            do
            {
                prix = int.Parse(Console.ReadLine());
            }
            while (prix<=0);
            Console.Write("Quantite : ");
            double qteStock;
            do
            {
                qteStock = double.Parse(Console.ReadLine());
            }
            while (qteStock < 0);
            if (qteStock==0)
            {
                EtatArticle etatArticle = EtatArticle.Indisponible;
            }
            else
            {
                EtatArticle etatArticle = EtatArticle.Disponible;
            }

            return new Article { Libelle = libelle, Prix = prix, QteStock = qteStock };

        }

        private int ChoiceWhatToUpdate()
        {
            Console.WriteLine("1. le libelle");
            Console.WriteLine("2. le prix");
            Console.WriteLine("3. la quantite");
            Console.WriteLine("0. Quitter");
            Console.Write("Votre choix : ");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static void UpdateArticle(Article article)
        {
            Console.Write("Que voulez vous modifier : ");
            Console.WriteLine("1. le libelle");
            Console.WriteLine("2. le prix");
            Console.WriteLine("3. la quantite");
            Console.WriteLine("0. Quitter");
            Console.Write("Votre choix : ");

            int choix = Convert.ToInt32(Console.ReadLine());
            if (choix == 1)
            {
                Console.Write("Nouveau libelle : ");
                string newLibelle = Console.ReadLine();
                article.Libelle = newLibelle;

            }
            else if (choix == 2)
            {

                Console.Write("Nouveau prix : ");
                int newPrice = int.Parse(Console.ReadLine());
                article.Prix = newPrice;

            }
            else if (choix == 3)
            {
                Console.Write("Nouvelle quantite : ");
                double newQteStock = double.Parse(Console.ReadLine());
                article.QteStock = newQteStock;


            }
            else
            {
                Console.WriteLine("Au revoir!");
            }
            Console.WriteLine("article modifié!");
        }

        public static int DeleteArticle()
        {
            Console.Write("Voulez-vous supprimer un article ? (o/n) ");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "o")
            {
                Console.Write("Id du article à supprimer : ");
                return Convert.ToInt32(Console.ReadLine());
            }
            return 0;

        }

        public static int SaisirId()
        {
            Console.WriteLine("Id du article ?");
            return Convert.ToInt32(Console.ReadLine());
        }

    }
}
