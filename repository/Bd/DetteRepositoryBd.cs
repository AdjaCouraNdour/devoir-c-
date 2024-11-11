using GestionBoutiqueC.core;
using GestionBoutiqueC.core.Database;
using GestionBoutiqueC.data.entities;
using GestionBoutiqueC.data.enums;
using GestionBoutiqueC.repository.interfaces;
using MySql.Data.MySqlClient;
using System;

namespace GestionBoutiqueC.repository.Bd
{
    public class DetteRepositoryBd : RepositoryBdImpl<Dette>, IDetteRepository
    {
        private IClientRepository clientRepository;
        private IArticleRepository articleRepository;
        public DetteRepositoryBd(IDataBase dataBase, IClientRepository clientRepository ,IArticleRepository articleRepository) : base(dataBase)
        {
            this.clientRepository = clientRepository;
            this.articleRepository=articleRepository;
        }

        public void Insert(Dette dette)
        {
            base.Insert(dette); // Appel à la méthode Insert du parent
                try{
                    using (var conn = dataBase.getConnection()) // Connexion à la base de données
                    {
                        InsertDetails(conn, dette);
                        InsertPaiements(conn, dette);
                                          
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine($"Erreur lors de l'insertion des paiements ou des détails pour la dette ID: {dette.Id} - {e.Message}");
                }
        }

        public List<Dette> SelectDettesByClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "Client cannot be null");
            }

            return SelectDettesByClientId(client.Id);
        }


        public List<Dette> SelectDettesByClientId(int clientId)
        {
            List<Dette>? dettes = new List<Dette>();
            using (var conn = dataBase.getConnection())
            {
                
                string query = $"SELECT * FROM dette WHERE client_id = @clientId"; // Correction ici
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@clientId", clientId); // Correction ici
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dettes.Add(MapEntity(reader));
                        }
                    }
                }
            }
            return dettes;      
        }


        protected override string GetColumnNames()
        {
            return "date, montant, montant_verse, montant_restant, type_dette, etat_dette, client_id, createAt, updateAt";
        }

        protected override string GetParameterNames()
        {
            return "@date, @montant, @montant_verse, @montant_restant, @type_dette, @etat_dette, @client_id, @createAt, @updateAt";
        }

        protected override string GetUpdateColumns()
        {
            return "date = @date, montant = @montant, montant_verse = @montant_verse, montant_restant = @montant_restant, type_dette = @type_dette, etat_dette = @etat_dette, client_id = @client_id, updateAt = @updateAt";
        }

        protected override Dette MapEntity(MySqlDataReader reader)
        {
            Dette dette = new Dette
            {
                Id = reader.GetInt32("id"),
                Date = reader.GetDateTime("date"),
                Montant = reader.GetDouble("montant"),
                MontantVerse = reader.GetDouble("montant_verse"),
                MontantRestant = reader.GetDouble("montant_restant"),
                TypeDette = TypeDetteExtensions.GetTypeDetteById(reader.GetInt32("type_dette")).GetValueOrDefault(),
                // TypeDette = (TypeDette)Enum.Parse(typeof(TypeDette), reader.GetString("type_dette")),
                EtatDette = EtatDetteExtensions.GetEtatDetteById(reader.GetInt32("etat_dette")).GetValueOrDefault(),
                // EtatDette = (EtatDette)Enum.Parse(typeof(EtatDette), reader.GetString("etat_dette")),                Archiver = reader.GetBoolean("archiver"),
            };

            int clientId = reader.GetInt32("client_id");
            if (clientId > 0)
            {
                dette.Client = clientRepository.SelectById(clientId);
            }

            List<Details> detailsList = GetDetailsByDetteId(dette.Id);

            // Ajouter chaque détail un par un à la dette
            foreach (var details in detailsList)
            {
                dette.AddDetails(details);  // Ajoute chaque détail à ListeDetails de Dette
            }            
            foreach (var paiement in GetPaiementsByDetteId(dette.Id))
            {
                dette.AddPaiement(paiement);
            }
            return dette;
        }
        

        protected override void SetInsertParameters(MySqlCommand cmd, Dette entity)
        {
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
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
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        }

        private void InsertDetails(MySqlConnection conn, Dette dette)
        {
            string queryDetails = "INSERT INTO details (qte_dette, dette_id, article_id) VALUES (@qte_dette, @dette_id, @article_id)";
            using (MySqlCommand cmd = new MySqlCommand(queryDetails, conn))
            {
                foreach (Details detail in dette.ListeDetails)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@qte_dette", detail.QteDette);
                    cmd.Parameters.AddWithValue("@dette_id", dette.Id);
                    cmd.Parameters.AddWithValue("@article_id", detail.Article.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void InsertPaiements(MySqlConnection conn, Dette dette)
        {
            string queryPaiements = "INSERT INTO paiement (montant, date, dette_id) VALUES (@montant, @date, @dette_id)";
            using (MySqlCommand cmd = new MySqlCommand(queryPaiements, conn))
            {
                foreach (Paiement paiement in dette.ListePaiements)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@montant", paiement.Montant);
                    cmd.Parameters.AddWithValue("@date", paiement.Date);
                    cmd.Parameters.AddWithValue("@dette_id", dette.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private List<Details> GetDetailsByDetteId(int detteId)
        {
            List<Details> detailsList = new List<Details>();
            string query = "SELECT * FROM details WHERE dette_id = @dette_id";
            
            using (var conn = dataBase.getConnection()) 
            {                
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dette_id", detteId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Details detail = new Details
                            {
                                QteDette = reader.GetDouble("qte_dette"),
                                Article = articleRepository.SelectById(reader.GetInt32("article_id"))
                            };
                            detailsList.Add(detail);
                        }
                    }
                }
                return detailsList;
            }
        }

        private List<Paiement> GetPaiementsByDetteId(int detteId)
        {
            List<Paiement> paiementsList = new List<Paiement>();
            using (var conn = dataBase.getConnection())
            {
                string query = "SELECT * FROM paiement WHERE dette_id = @dette_id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dette_id", detteId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Paiement paiement = new Paiement
                            {
                                Montant = reader.GetDouble("montant"),
                                Date = reader.GetDateTime("date").ToLocalTime().Date
                            };
                            paiementsList.Add(paiement);
                        }
                    }
                }
            return paiementsList;
            }
        }
    }
}
