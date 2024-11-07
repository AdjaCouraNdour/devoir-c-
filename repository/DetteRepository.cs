using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.repository
{
    public class DetteRepository : IDetteRepository
    {
        private readonly List<Dette> dettes = new List<Dette>();

        public List<Dette> SelectAll()
        {
            return dettes;
        }
        public Dette SelectById(int id)
        {
            foreach (var dette in dettes)
            {
                if (dette.Id == id)
                    return dette;
            }
            return null;
        }
        public void Insert(Dette dette)
        {
            dettes.Add(dette);
        }
        public void Update(Dette dette)
        {
            int position = dettes.FindIndex(dette => dette.Id == dette.Id);
            if (position != -1)
                dettes[position] = dette;
        }
        public void Delete(int id)
        {
            Dette detteToRemove = dettes.Find(cl => cl.Id == id);
            if (detteToRemove != null)
                dettes.Remove(detteToRemove);
        }

    }
}
