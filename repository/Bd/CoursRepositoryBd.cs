using GestionBoutiqueC.core;
using GestionBoutiqueC.core.Database;
using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GestionBoutiqueC.repository.Bd
{
    public class CoursRepositoryBd : RepositoryBdImpl<Cours>, ICoursRepository
    {
        public CoursRepositoryBd(IDataBase dataBase) : base(dataBase)
        {
        }      

        protected override Cours MapEntity(MySqlDataReader reader)
        {
            return new Cours
            {
                Id = reader.GetInt32("id"),
                Libelle = reader.GetString("libelle"),
                Date = reader.GetDateTime("date"),
                HeureDebut = reader.GetTimeSpan("heureDebut"),
                HeureFin = reader.GetTimeSpan("heureFin"),
                NbHeures = reader.GetInt32("nbHeures"),
                Semestre = reader.GetString("semestre"),
                CreateAt = reader.GetDateTime("createAt"),
                UpdateAt = reader.GetDateTime("updateAt"),
                // Vous pouvez ajouter ici la récupération des relations comme Professeur, Classes, ou Module
            };
        }

        // Paramétrer les valeurs pour l'insertion d'un cours
        protected override void SetInsertParameters(MySqlCommand cmd, Cours entity)
        {
            cmd.Parameters.AddWithValue("@libelle", entity.Libelle);
            cmd.Parameters.AddWithValue("@date", entity.Date);
            cmd.Parameters.AddWithValue("@heureDebut", entity.HeureDebut);
            cmd.Parameters.AddWithValue("@heureFin", entity.HeureFin);
            cmd.Parameters.AddWithValue("@nbHeures", entity.NbHeures);
            cmd.Parameters.AddWithValue("@semestre", entity.Semestre);
            cmd.Parameters.AddWithValue("@createAt", entity.CreateAt);
            cmd.Parameters.AddWithValue("@updateAt", entity.UpdateAt);
        }

        // Paramétrer les valeurs pour la mise à jour d'un cours
        protected override void SetUpdateParameters(MySqlCommand cmd, Cours entity)
        {
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@libelle", entity.Libelle);
            cmd.Parameters.AddWithValue("@date", entity.Date);
            cmd.Parameters.AddWithValue("@heureDebut", entity.HeureDebut);
            cmd.Parameters.AddWithValue("@heureFin", entity.HeureFin);
            cmd.Parameters.AddWithValue("@nbHeures", entity.NbHeures);
            cmd.Parameters.AddWithValue("@semestre", entity.Semestre);
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now); // Met à jour le champ UpdateAt
        }

        // Requête de mise à jour
        protected override string GetUpdateColumns()
        {
            return "libelle = @libelle, date = @date, heureDebut = @heureDebut, heureFin = @heureFin, nbHeures = @nbHeures, semestre = @semestre, updateAt = @updateAt";
        }

        // Requête pour obtenir les noms des colonnes pour les inserts
        protected override string GetColumnNames()
        {
            return "libelle, date, heureDebut, heureFin, nbHeures, semestre, createAt, updateAt";
        }

        // Requête pour obtenir les noms des paramètres pour les inserts
        protected override string GetParameterNames()
        {
            return "@libelle, @date, @heureDebut, @heureFin, @nbHeures, @semestre, @createAt, @updateAt";
        }
    }
}
