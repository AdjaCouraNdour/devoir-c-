using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionBoutiqueC.data.entities;

namespace GestionBoutiqueC.core
{
    public class RepositoryImpl<T> : IRepository<T> where T : IIdentifiable
    {
        public readonly List<T> list = new List<T>();

        public void Insert(T entity)
        {
            list.Add(entity);
        }

        public List<T> SelectAll()
        {
            return list ;
        }

        public T? SelectById(int id)
        {
            return list.FirstOrDefault(entity => entity.Id == id);
           
        }

        public void Update(T entity)
        {
           int position = list.FindIndex(e => e.Id == entity.Id);
            if (position != -1)
                list[position] = entity;
        }
        public void Delete(int id)
        {
            T TToRemove = list.Find(e => e.Id == id);
            if (TToRemove != null)
                list.Remove(TToRemove);
        }
    }

}