using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using GestionBoutiqueC.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<User> FindAll()
        {
            return userRepository.SelectAll();
        }

        public User FindById(int id)
        {
            return userRepository.SelectById(id);
        }

        public void Save(User user)
        {
            userRepository.Insert(user);
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
        }

        public void Update(User user)
        {
            userRepository.Update(user);
        }

    }
}
