using GestionBoutiqueC.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.views
{
    public abstract class DetteView
    {
        public static void ListDettes(List<Dette> dettes)
        {
            foreach (var dette in dettes)
            {
                Console.WriteLine(dette);
            }
        }
    }
}
