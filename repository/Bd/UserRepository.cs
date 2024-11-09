using GestionBoutiqueC.core;
using GestionBoutiqueC.core.Database;
using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.data.enums;
using GestionBoutiqueC.repository.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GestionBoutiqueC.repository.Bd
{
    public class UserRepository : RepositoryBdImpl<User>, IUserRepository
    {
        public UserRepository(IDataBase dataBase) : base(dataBase)
        {
        }

            //MySqlConnection => Connection : Java
            // MySqlCommand => Statement : Java
            // MySqlDataReader => ResultSet : Java
            // using optimisation de memoire et les object ne vont exister que dans les blocks 

        public User? SelectByLogin(string login)
        {
            // Définir la requête SQL pour rechercher l'utilisateur par login
            string query = "SELECT * FROM users WHERE login = @login";
            
            // Utilisation de la connexion à la base de données
            using (var conn = dataBase.getConnection())
            {
                using (var cmd = new MySqlCommand(query, conn))
                {
                    // Ajouter le paramètre du login à la commande
                    cmd.Parameters.AddWithValue("@login", login);
                    
                    // Exécuter la commande et lire les résultats
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Si un utilisateur est trouvé, mapper les résultats
                            return MapEntity(reader);
                        }
                    }
                }
            }

            // Retourner null si aucun utilisateur n'est trouvé
            return null;
        }

        public User? SelectByEmail(string email)
        {
            // Définir la requête SQL pour rechercher l'utilisateur par email
            string query = "SELECT * FROM users WHERE email = @email";
            
            // Utilisation de la connexion à la base de données
            using (var conn = dataBase.getConnection())
            {
                using (var cmd = new MySqlCommand(query, conn))
                {
                    // Ajouter le paramètre de l'email à la commande
                    cmd.Parameters.AddWithValue("@email", email);
                    
                    // Exécuter la commande et lire les résultats
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Si un utilisateur est trouvé, mapper les résultats
                            return MapEntity(reader);
                        }
                    }
                }
            }

            // Retourner null si aucun utilisateur n'est trouvé
            return null;
        }


        protected override string GetColumnNames()
        {
            return "login, email, password, user_role, actif, client_id, createAt, updateAt";
        }

        protected override string GetParameterNames()
        {
            return "@login, @email, @password, @userRole, @actif, @clientId, @createAt, @updateAt";
        }

        protected override User MapEntity(MySqlDataReader reader)
        {
            return new User
            {
                Id = reader.GetInt32("id"),
                Login = reader.GetString("login"),
                Email = reader.GetString("email"),
                Password = reader.GetString("password"),
                UserRole = UserRoleExtensions.GetUserRoleById(reader.GetInt32("user_role")).GetValueOrDefault(),
                // UserRole = Enum.Parse<UserRole>(reader.GetString("user_role")),
                Actif = reader.GetBoolean("actif"),
                Client = new Client { Id = reader.GetInt32("client_id") } // si vous avez besoin de l'objet Client complet, faites une jointure
            };
        }

        protected override void SetInsertParameters(MySqlCommand cmd, User entity)
        {
            cmd.Parameters.AddWithValue("@login", entity.Login);
            cmd.Parameters.AddWithValue("@email", entity.Email);
            cmd.Parameters.AddWithValue("@password", entity.Password);
            cmd.Parameters.AddWithValue("@userRole", entity.UserRole.ToString());
            cmd.Parameters.AddWithValue("@actif", entity.Actif);
            cmd.Parameters.AddWithValue("@clientId", entity.Client?.Id);
        }

        protected override void SetUpdateParameters(MySqlCommand cmd, User entity)
        {
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@login", entity.Login);
            cmd.Parameters.AddWithValue("@email", entity.Email);
            cmd.Parameters.AddWithValue("@password", entity.Password);
            cmd.Parameters.AddWithValue("@userRole", entity.UserRole.ToString());
            cmd.Parameters.AddWithValue("@actif", entity.Actif);
            cmd.Parameters.AddWithValue("@clientId", entity.Client?.Id);
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now);

        }

        protected override string GetUpdateColumns()
        {
            return "login = @login, email = @email, password = @password, user_role = @userRole, actif = @actif, client_id = @clientId, updateAt = @updateAt";
        }
    }
}
