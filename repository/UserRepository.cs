using GestionBoutiqueC.core;
using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.repository
{
    public class UserRepository : RepositoryImpl<User>, IUserRepository
    {

        public User SelectByLogin(string login)
        {
            if (list == null || !list.Any())
            {
                Console.WriteLine("La liste des utilisateurs est vide ou null.");
                return null;
            }

            foreach (var user in list)
            {
                if (user.Login == login)
                    return user;
            }
            return null;
        }

    public User SelectByEmail(string email)
    {
        if (list == null || !list.Any())
        {
            Console.WriteLine("La liste des utilisateurs est vide ou null.");
            return null;
        }

        foreach (var user in list)
        {
            if (user.Email == email)
                return user;
        }
        return null;
    }

    }
}
