using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.data.enums
{
    public enum TypeDette
    {
        Solde,nonSolde
    }
   public static class TypeDetteExtensions
    {
        // Méthode pour obtenir TypeDette depuis un string
        public static TypeDette? GetTypeDette(string value)
        {
            foreach (TypeDette type in Enum.GetValues(typeof(TypeDette)))
            {
                if (string.Equals(type.ToString(), value, StringComparison.OrdinalIgnoreCase))
                {
                    return type;
                }
            }
            return null;
        }

        // Méthode pour obtenir TypeDette depuis un int
        public static TypeDette? GetTypeDetteById(int id)
        {
            foreach (TypeDette type in Enum.GetValues(typeof(TypeDette)))
            {
                if ((int)type == id)
                {
                    return type;
                }
            }
            return null;
        }

        // Méthode pour obtenir l'ID (int) depuis TypeDette
        public static int GetTypeDetteId(TypeDette type)
        {
            return (int)type;
        }
    }
}
