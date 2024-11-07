using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.views
{
    public abstract class DetailsView
    {
        public static void ListDetails(List<Details> details)
        {
            foreach (var detail in details)
            {
                Console.WriteLine(detail);
            }
        }

        }
    }
