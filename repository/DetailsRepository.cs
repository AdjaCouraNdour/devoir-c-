using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.repository
{
    public class DetailsRepository : IDetailsRepository
    {
        private readonly List<Details> details = new List<Details>();

        public List<Details> SelectAll()
        {
            return details;
        }
        public Details SelectById(int id)
        {
            foreach (var detail in details)
            {
                if (detail.Id == id)
                    return detail;
            }
            return null;
        }
        public void Insert(Details detail)
        {
            details.Add(detail);
        }
        public void Update(Details detail)
        {
            int position = details.FindIndex(detail => detail.Id == detail.Id);
            if (position != -1)
                details[position] = detail;
        }
        public void Delete(int id)
        {
            Details detailsToRemove = details.Find(detail => detail.Id == id);
            if (detailsToRemove != null)
                details.Remove(detailsToRemove);
        }

    }
}
