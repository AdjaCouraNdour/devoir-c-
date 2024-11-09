using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.data.enums
{
    public enum EtatDette
    {
        EnCours,Annuler
    }
     public static class EtatDetteExtensions
    {
        // Méthode pour obtenir EtatDette depuis un string
        public static EtatDette? GetEtatDette(string value)
        {
            foreach (EtatDette etat in Enum.GetValues(typeof(EtatDette)))
            {
                if (string.Equals(etat.ToString(), value, StringComparison.OrdinalIgnoreCase))
                {
                    return etat;
                }
            }
            return null;
        }

        // Méthode pour obtenir EtatDette depuis un int
        public static EtatDette? GetEtatDetteById(int id)
        {
            foreach (EtatDette etat in Enum.GetValues(typeof(EtatDette)))
            {
                if ((int)etat == id)
                {
                    return etat;
                }
            }
            return null;
        }

        // Méthode pour obtenir l'ID (int) depuis EtatDette
        public static int GetEtatDetteId(EtatDette etat)
        {
            return (int)etat;
        }
    }
}
