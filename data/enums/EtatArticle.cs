using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.data.enums
{
    public enum EtatArticle
    {
        Disponible,Indisponible
    }
    public static class EtatArticleExtensions
    {
        // Méthode pour obtenir EtatArticle depuis un string
        public static EtatArticle? GetEtatArticle(string value)
        {
            foreach (EtatArticle etat in Enum.GetValues(typeof(EtatArticle)))
            {
                if (string.Equals(etat.ToString(), value, StringComparison.OrdinalIgnoreCase))
                {
                    return etat;
                }
            }
            return null;
        }

        // Méthode pour obtenir EtatArticle depuis un int
        public static EtatArticle? GetEtatArticleById(int id)
        {
            foreach (EtatArticle etat in Enum.GetValues(typeof(EtatArticle)))
            {
                if ((int)etat == id)
                {
                    return etat;
                }
            }
            return null;
        }

        // Méthode pour obtenir l'ID (int) depuis EtatArticle
        public static int GetEtatArticleId(EtatArticle etat)
        {
            return (int)etat;
        }
    }
}
