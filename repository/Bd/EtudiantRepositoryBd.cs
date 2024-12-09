using GestionBoutiqueC.core;
using GestionBoutiqueC.core.Database;
using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GestionBoutiqueC.repository.Bd
{
    public class EtudiantRepositoryBd : RepositoryBdImpl<Etudiant>, IEtudiantRepository
    {
        public EtudiantRepositoryBd(IDataBase dataBase) : base(dataBase)
        {
        }

        protected override Etudiant MapEntity(MySqlDataReader reader)
        {
            return new Etudiant
            {
                Id = reader.GetInt32("id"),
                Matricule = reader.GetString("matricule"),
                NomComplet = reader.GetString("nom_complet"),
                Adresse = reader.GetString("adresse"),
                CreateAt = reader.GetDateTime("createAt"),
                UpdateAt = reader.GetDateTime("updateAt"),
            };
        }

        protected override void SetInsertParameters(MySqlCommand cmd, Etudiant entity)
        {
            cmd.Parameters.AddWithValue("@matricule", entity.Matricule);
            cmd.Parameters.AddWithValue("@nomComplet", entity.NomComplet);
            cmd.Parameters.AddWithValue("@adresse", entity.Adresse);
            cmd.Parameters.AddWithValue("@createAt", entity.CreateAt);
            cmd.Parameters.AddWithValue("@updateAt", entity.UpdateAt);
        }

        protected override void SetUpdateParameters(MySqlCommand cmd, Etudiant entity)
        {
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@matricule", entity.Matricule);
            cmd.Parameters.AddWithValue("@nomComplet", entity.NomComplet);
            cmd.Parameters.AddWithValue("@adresse", entity.Adresse);
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now); 
        }

        protected override string GetUpdateColumns()
        {
            return "matricule = @matricule, nom_complet = @nomComplet, adresse = @adresse, updateAt = @updateAt";
        }

        // Requête pour obtenir les noms des colonnes pour les inserts
        protected override string GetColumnNames()
        {
            return "matricule, nom_complet, adresse, createAt, updateAt";
        }

        // Requête pour obtenir les noms des paramètres pour les inserts
        protected override string GetParameterNames()
        {
            return "@matricule, @nomComplet, @adresse, @createAt, @updateAt";
        }
    }
}
