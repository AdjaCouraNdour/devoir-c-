using GestionBoutiqueC.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.services.interfaces
{
    public interface IUserService
    {
        List<User> FindAll();
        User FindById(int id);
        void Save(User user);
        void Delete(int id);
        void Update(User user);

    }
}
