using GestionBoutiqueC.data.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.data.entities
{
    public class User
    {
        private int id;
        private String login;
        private String email;
        private String password;
        private UserRole userRole;
        private bool actif = true;
        private static int nbr;
        public User()
        {
            nbr++;
            id = nbr;
        }

        private Client client;

        public int Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public UserRole UserRole { get => userRole; set => userRole = value; }
        public bool Actif { get => actif; set => actif = value; }
        public Client Client { get => client; set => client = value; }
        public static int Nbr { get => nbr; set => nbr = value; }

        public override string ToString()
        {
            return "User[" +
           "id=" + id +
           ", email='" + email + '\'' +
           ", login='" + login + '\'' +
           ", actif='" + actif + '\'' +
           ", role='" + userRole + '\'' +
           ", password='" + password + '\'' +
           ", Client='" + (client != null ? client.Surnom : "Aucun client associé") + '\'' +
           ']';

        }

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   id == user.id &&
                   login == user.login &&
                   email == user.email &&
                   password == user.password &&
                   userRole == user.userRole &&
                   actif == user.actif &&
                   EqualityComparer<Client>.Default.Equals(client, user.client) &&
                   Id == user.Id &&
                   Login == user.Login &&
                   Email == user.Email &&
                   Password == user.Password &&
                   UserRole == user.UserRole &&
                   Actif == user.Actif &&
                   EqualityComparer<Client>.Default.Equals(Client, user.Client);
        }
    }
}
