using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.data.enums;
using GestionBoutiqueC.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBoutiqueC.views
{
    public abstract class UserView
    {

        public static void ListUsers(List<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
        public static User CreateUserForClient()
        {
            User user = new User { Actif = true };
            Console.Write("Email : ");
            user.Email = Console.ReadLine();
            Console.Write("Login : ");
            user.Login = Console.ReadLine();
            Console.Write("Password : ");
            user.Password = Console.ReadLine();
            user.UserRole = UserRole.Client;
            return user;
        }

        public static User CreateUserWithChoice()
        {
            User user = new User { Actif = true };
            Console.Write("Email : ");
            user.Email = Console.ReadLine();
            Console.Write("Login : ");
            user.Login = Console.ReadLine();
            Console.Write("Password : ");
            user.Password = Console.ReadLine();

            Console.WriteLine("Voulez-vous lui ajouter un rôle ?");
            if (AskToContinue() == 1)
            {
                user.UserRole = SaisieRoleCompte();
            }
            return user;
        }
        public static void UpdateUser(User User)
        {

            Console.Write("Nouveau email : ");
            string newEmail = Console.ReadLine();
            Console.Write("Nouveau login : ");
            string newLogin = Console.ReadLine();
            Console.Write("Nouvelle password : ");
            string newPassword = Console.ReadLine();
            User.Email = newEmail;
            User.Login = newLogin;
            User.Password = newPassword;
            Console.WriteLine("User modifié!");
        }

        public static int DeleteUser()
        {
            Console.Write("Voulez-vous supprimer un User ? (o/n) ");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "o")
            {
                Console.Write("Id du User à supprimer : ");
                return Convert.ToInt32(Console.ReadLine());
            }
            return 0;

        }

        public static int SaisirId()
        {
            Console.WriteLine("Id du User ?");
            return Convert.ToInt32(Console.ReadLine());
        }
        private static UserRole SaisieRoleCompte()
        {
            int choix;
            do
            {
                Console.WriteLine("Veuillez sélectionner le type du user :");
                var roles = Enum.GetValues(typeof(UserRole)).Cast<UserRole>().ToArray();
                for (int i = 0; i < roles.Length; i++)
                {
                    Console.WriteLine($"{i + 1} - {roles[i]}");
                }
                // Vérifie que l'utilisateur entre un entier valide
                while (!int.TryParse(Console.ReadLine(), out choix) || choix <= 0 || choix > roles.Length)
                {
                    Console.WriteLine("Choix invalide, veuillez réessayer.");
                }

            } while (choix <= 0 || choix > Enum.GetValues(typeof(UserRole)).Length);

            return (UserRole)(choix - 1);
        }

        public static int ChoiceToContinue()
        {
            int choice;
            Console.WriteLine("Entrez votre choix:");
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Choix invalide. Veuillez entrer un nombre.");
            }
            return choice;
        }

        public static int AskToContinue()
        {
            Console.WriteLine("1- Oui\n2- Non");
            return ChoiceToContinue();
        }
    }
}
