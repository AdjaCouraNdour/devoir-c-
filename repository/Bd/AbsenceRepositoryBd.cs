using GestionBoutiqueC.core;
using GestionBoutiqueC.core.Database;
using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GestionBoutiqueC.repository.Bd
{
    public class AbsenceRepositoryBd : RepositoryBdImpl<Absence>, IAbsenceRepository
    {
        public AbsenceRepositoryBd(IDataBase dataBase) : base(dataBase)
        {
        }

        public List<Absence>? SelectByEtudiantId(int etudiantId)
        {
            string query = "SELECT * FROM absences WHERE etudiant_id = @etudiantId";
            var absenceList = new List<Absence>();

            using (var conn = dataBase.getConnection())
            {
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@etudiantId", etudiantId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            absenceList.Add(MapEntity(reader));
                        }
                    }
                }
            }

            return absenceList;
        }

        // Requête pour récupérer toutes les absences d'un cours
        public List<Absence> SelectByCoursId(int coursId)
        {
            string query = "SELECT * FROM absences WHERE cours_id = @coursId";
            var absenceList = new List<Absence>();

            using (var conn = dataBase.getConnection())
            {
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@coursId", coursId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            absenceList.Add(MapEntity(reader));
                        }
                    }
                }
            }

            return absenceList;
        }

        // Mapper les résultats de la base de données vers l'entité Absence
        protected override Absence MapEntity(MySqlDataReader reader)
        {
            var absence = new Absence
            {
                Id = reader.GetInt32("id"),
                DateAbsence = reader.GetDateTime("date_absence"),
                CreateAt = reader.GetDateTime("createAt"),
                UpdateAt = reader.GetDateTime("updateAt"),
            };

            // Chargement des données liées : Etudiant et Cours
            absence.Etudiant = new Etudiant { Id = reader.GetInt32("etudiant_id") }; // ou récupérer l'entité complète si nécessaire
            absence.Cours = new Cours { Id = reader.GetInt32("cours_id") }; // ou récupérer l'entité complète si nécessaire

            return absence;
        }

        // Paramétrer les valeurs pour l'insertion d'une absence
        protected override void SetInsertParameters(MySqlCommand cmd, Absence entity)
        {
            cmd.Parameters.AddWithValue("@etudiantId", entity.Etudiant.Id);
            cmd.Parameters.AddWithValue("@coursId", entity.Cours.Id);
            cmd.Parameters.AddWithValue("@dateAbsence", entity.DateAbsence);
            cmd.Parameters.AddWithValue("@createAt", entity.CreateAt);
            cmd.Parameters.AddWithValue("@updateAt", entity.UpdateAt);
        }

        // Paramétrer les valeurs pour la mise à jour d'une absence
        protected override void SetUpdateParameters(MySqlCommand cmd, Absence entity)
        {
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@etudiantId", entity.Etudiant.Id);
            cmd.Parameters.AddWithValue("@coursId", entity.Cours.Id);
            cmd.Parameters.AddWithValue("@dateAbsence", entity.DateAbsence);
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now); // Met à jour le champ UpdateAt
        }

        // Requête de mise à jour
        protected override string GetUpdateColumns()
        {
            return "etudiant_id = @etudiantId, cours_id = @coursId, date_absence = @dateAbsence, updateAt = @updateAt";
        }

        // Requête pour obtenir les noms des colonnes pour les inserts
        protected override string GetColumnNames()
        {
            return "etudiant_id, cours_id, date_absence, createAt, updateAt";
        }

        // Requête pour obtenir les noms des paramètres pour les inserts
        protected override string GetParameterNames()
        {
            return "@etudiantId, @coursId, @dateAbsence, @createAt, @updateAt";
        }
    }
}
