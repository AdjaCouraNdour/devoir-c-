using GestionBoutiqueC.core;
using GestionBoutiqueC.core.Database;
using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.data.enums;
using GestionBoutiqueC.repository.interfaces;
using MySql.Data.MySqlClient;
using System;

namespace GestionBoutiqueC.repository.Bd
{
    public class DetteRepository : RepositoryBdImpl<Dette>, IDetteRepository
    {
        public DetteRepository(IDataBase dataBase) : base(dataBase)
        {
        }

        protected override string GetColumnNames()
        {
            return "date, montant, montant_verse, montant_restant, type_dette, etat_dette, client_id, createAt, updateAt";
        }

        protected override string GetParameterNames()
        {
            return "date = @date, @montant, @montant_verse, @montant_restant, @type_dette, @etat_dette, @client_id, @createAt, @updateAt";
        }

        protected override string GetUpdateColumns()
        {
            return "date = @date, montant = @montant, montant_verse = @montant_verse, montant_restant = @montant_restant, type_dette = @type_dette, etat_dette = @etat_dette, client_id = @client_id, , updateAt = @updateAt";
        }

        protected override Dette MapEntity(MySqlDataReader reader)
        {
            return new Dette
            {
                Id = reader.GetInt32("id"),
                Date = reader.GetDateTime("date"),
                Montant = reader.GetDouble("montant"),
                MontantVerse = reader.GetDouble("montant_verse"),
                MontantRestant = reader.GetDouble("montant_restant"),
                TypeDette = TypeDetteExtensions.GetTypeDetteById(reader.GetInt32("type_dette")).GetValueOrDefault(),
                // TypeDette = (TypeDette)Enum.Parse(typeof(TypeDette), reader.GetString("type_dette")),
                EtatDette = EtatDetteExtensions.GetEtatDetteById(reader.GetInt32("etat_dette")).GetValueOrDefault(),
                // EtatDette = (EtatDette)Enum.Parse(typeof(EtatDette), reader.GetString("etat_dette")),
                Client = new Client { Id = reader.GetInt32("client_id") } // Chargement léger de Client
            };
        }

        protected override void SetInsertParameters(MySqlCommand cmd, Dette entity)
        {
            cmd.Parameters.AddWithValue("@date", entity.Date);
            cmd.Parameters.AddWithValue("@montant", entity.Montant);
            cmd.Parameters.AddWithValue("@montant_verse", entity.MontantVerse);
            cmd.Parameters.AddWithValue("@montant_restant", entity.MontantRestant);
            cmd.Parameters.AddWithValue("@type_dette", entity.TypeDette.ToString());
            cmd.Parameters.AddWithValue("@etat_dette", entity.EtatDette.ToString());
            cmd.Parameters.AddWithValue("@client_id", entity.Client?.Id);
             cmd.Parameters.AddWithValue("@createAt", DateTime.Now);
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now);
        }

        protected override void SetUpdateParameters(MySqlCommand cmd, Dette entity)
        {
            cmd.Parameters.AddWithValue("@date", entity.Date);
            cmd.Parameters.AddWithValue("@montant", entity.Montant);
            cmd.Parameters.AddWithValue("@montant_verse", entity.MontantVerse);
            cmd.Parameters.AddWithValue("@montant_restant", entity.MontantRestant);
            cmd.Parameters.AddWithValue("@type_dette", entity.TypeDette.ToString());
            cmd.Parameters.AddWithValue("@etat_dette", entity.EtatDette.ToString());
            cmd.Parameters.AddWithValue("@client_id", entity.Client?.Id);
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now);

        }
    }
}
