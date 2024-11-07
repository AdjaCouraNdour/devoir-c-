using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> users = new List<User>();

        public List<User> SelectAll()
        {
            return users;
        }
        public User SelectById(int id)
        {
            foreach (var user in users)
            {
                if (user.Id == id)
                    return user;
            }
            return null;
        }
        public void Insert(User user)
        {
            users.Add(user);
        }
        public void Update(User user)
        {
            int position = users.FindIndex(user => user.Id == user.Id);
            if (position != -1)
                users[position] = user;
        }
        public void Delete(int id)
        {
            User UserToRemove = users.Find(user => user.Id == id);
            if (UserToRemove != null)
                users.Remove(UserToRemove);
        }

    }
}
