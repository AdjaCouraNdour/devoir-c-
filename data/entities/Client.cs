using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.data.entities
{
    public class Client
    {
        private int id;
        private String surnom;
        private String telephone;
        private String adresse;

        private User user;
        private List<Dette> listeDette = new List<Dette>();

        private static int nbr;

        public Client()
        {
            nbr++;
            id = nbr;
        }


        public int Id { get => id; set => id = value; }
        public string Surnom { get => surnom; set => surnom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public User User { get => user; set => user = value; }

        public static int Nbr { get => nbr; set => nbr = value; }

        public void ListeDette(Dette dette)
        {
            dette.Client=this;
            listeDette.Add(dette);
        }

        public IReadOnlyList<Dette> GetListeDette()
        {
            return listeDette.AsReadOnly();
        }

        public override string ToString()
        {
            return "Client[" +
                    "id=" + id +
                    ", surnom='" + surnom + '\'' +
                    ", telephone='" + telephone + '\'' +
                    ", adresse='" + adresse + ']';

        }

        public bool equals(Client other)
        {
            if (this == other) return true;
            if (other == null) return false;
            Client client = (Client)other;
            return id == client.id &&
                    Object.Equals(surnom, client.surnom) &&
                    Object.Equals(telephone, client.telephone) &&
                    Object.Equals(adresse, client.adresse);

        }
    }
}
