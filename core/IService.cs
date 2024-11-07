using GestionBoutiqueC.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.core
{
    public interface IService<T>
    {
        List<T> FindAll();
        T FindById(int id);
        void Save(T data);
        void Delete(int id);
        void Update(T data);
    }
}
