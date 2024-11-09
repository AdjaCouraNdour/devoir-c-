using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.data.enums
{
    public enum UserRole
    {
        Boutiquier,Client,Admin
    }
     public static class UserRoleExtensions
    {
        // Méthode pour obtenir UserRole depuis un string
        public static UserRole? GetUserRole(string value)
        {
            foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
            {
                if (string.Equals(role.ToString(), value, StringComparison.OrdinalIgnoreCase))
                {
                    return role;
                }
            }
            return null;
        }

        // Méthode pour obtenir UserRole depuis un int
        public static UserRole? GetUserRoleById(int id)
        {
            foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
            {
                if ((int)role == id)
                {
                    return role;
                }
            }
            return null;
        }

        // Méthode pour obtenir l'ID (int) depuis UserRole
        public static int GetUserRoleId(UserRole role)
        {
            return (int)role;
        }
    }
}
