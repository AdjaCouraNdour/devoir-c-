using GestionBoutiqueC.core;
using GestionBoutiqueC.core.Database;
using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.repository.interfaces;
using MySql.Data.MySqlClient;
using System;

namespace GestionBoutiqueC.repository.Bd
{
    public class PaiementRepositoryBd : RepositoryBdImpl<Paiement>, IPaiementRepository
    {
        private IDetteRepository detteRepository;
        public PaiementRepositoryBd(IDataBase dataBase ,IDetteRepository detteRepository) : base(dataBase)
        {
            this.detteRepository =detteRepository;
        }

        protected override string GetColumnNames()
        {
            return "date, montant, dette_id, createAt, updateAt";
        }

        protected override string GetParameterNames()
        {
            return "@date, @montant, @dette_id, @createAt, @updateAt";
        }

        protected override string GetUpdateColumns()
        {
            return "date = @date, montant = @montant, dette_id = @dette_id, updateAt = @updateAt";
        }

        protected override Paiement MapEntity(MySqlDataReader reader)
        {
            Paiement paiement=new Paiement();
                paiement.Id = reader.GetInt32("id");
                paiement.Date = reader.GetDateTime("date");
                paiement.Montant = reader.GetDouble("montant");
                // Dette = new Dette { Id = reader.GetInt32("dette_id") } 
                int detteId = reader.GetInt32("dette_id");
                if (detteId > 0)
                {
                    Dette dette = detteRepository.SelectById(detteId);
                    paiement.Dette = dette;
                }
            return paiement;
        }

        protected override void SetInsertParameters(MySqlCommand cmd, Paiement entity)
        {
            cmd.Parameters.AddWithValue("@date", entity.Date);
            cmd.Parameters.AddWithValue("@montant", entity.Montant);
            cmd.Parameters.AddWithValue("@dette_id", entity.Dette?.Id);
            cmd.Parameters.AddWithValue("@createAt", DateTime.Now);
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now);
        }

        protected override void SetUpdateParameters(MySqlCommand cmd, Paiement entity)
        {
            cmd.Parameters.AddWithValue("@date", entity.Date);
            cmd.Parameters.AddWithValue("@montant", entity.Montant);
            cmd.Parameters.AddWithValue("@dette_id", entity.Dette?.Id);
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        }
    }
}
