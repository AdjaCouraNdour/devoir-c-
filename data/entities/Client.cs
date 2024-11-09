using System;
using System.Collections.Generic;

namespace GestionBoutiqueC.data.entities
{
    public class Client : IIdentifiable
    {
        private string surnom;
        private string telephone;
        private string address;
        private User? user;
        private List<Dette> listeDette = new List<Dette>();

        private static int nbr;

        public Client()
        {
            nbr++;
            Id = nbr;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }

        public int Id { get; set; }

        public string Surnom { get => surnom; set => surnom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Address { get => address; set => address = value; }
        public User? User { get => user; set => user = value; }
        public static int Nbr { get => nbr; set => nbr = value; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public IEnumerable<Dette> Dettes { get; } = new List<Dette>();

        public void AddDette(Dette dette)
        {
            dette.Client = this;
            listeDette.Add(dette);
        }

        public IReadOnlyList<Dette> ListeDette()
        {
            return listeDette.AsReadOnly();
        }

        public override string ToString()
        {
            return "Client[" +
                   "id=" + Id +
                   ", surnom='" + surnom + '\'' +
                   ", telephone='" + telephone + '\'' +
                   ", adresse='" + address + '\'' +
                   ", createdAt='" + CreateAt + '\'' +
                   ", updatedAt='" + UpdateAt + '\'' +
                   ']';
        }

        public bool Equals(Client other)
        {
            if (this == other) return true;
            if (other == null) return false;
            return Id == other.Id &&
                   string.Equals(surnom, other.surnom) &&
                   string.Equals(telephone, other.telephone) &&
                   string.Equals(address, other.address);
        }
    }
}
