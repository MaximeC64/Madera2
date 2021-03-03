using ModelApplicationMadera.DonneesLocales.Entites;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelApplicationMadera.CommunicationServeur
{
    public class GestionnaireCommunicationServeur
    {
        #region Singleton

        private static GestionnaireCommunicationServeur instance = null;
        public static GestionnaireCommunicationServeur Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GestionnaireCommunicationServeur();
                }
                return instance;
            }
        }

        // EMPECHE L'INSTANCIATION DE LA CLASSE
        private GestionnaireCommunicationServeur()
        {
        }

        #endregion

        private MySqlConnection mySqlConnection = null;

        private bool OpenConnection()
        {
            try
            {
                MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder();
                csb.Server = "localhost";
                csb.Database = "madera";
                csb.UserID = "root";
                csb.Password = "";

                mySqlConnection = new MySqlConnection(csb.ConnectionString);

                mySqlConnection.Open();
                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                mySqlConnection = null;
                return false;
            }
        }

        private void CloseConnection()
        {
            try
            {
                mySqlConnection.Close();
            }
            catch (Exception)
            {

                mySqlConnection = null;
            }
        }

        public UserMadera CheckConnect(string login, string password)
        {
            UserMadera user = null;

            if (OpenConnection() == false) return null;

            string req = "SELECT user.id, user.nom, user.prenom, user.email, user.mot_de_passe, user.service, user.tel, user.tel_portable, user.poste, user.date__heure_de_connexion, user.username, user.categorie, user.created_at, user.updated_at FROM user WHERE user.username = @login AND user.mot_de_passe = @password";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            mySqlCommand.Parameters.Add(new MySqlParameter("@login", login));
            mySqlCommand.Parameters.Add(new MySqlParameter("@password", password));
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                user = new UserMadera
                {
                    id = reader.GetInt32("id"),
                    nom = reader.GetString("nom"),
                    prenom = reader.GetString("prenom"),
                    email = reader.GetString("email"),
                    mot_de_passe = reader.GetString("mot_de_passe"),
                    service = reader.GetString("service"),
                    tel = reader.GetString("tel"),
                    tel_portable = reader.GetString("tel_portable"),
                    poste = reader.GetString("poste"),
                    date__heure_de_connexion = reader.GetDateTime("date__heure_de_connexion"),
                    userMaderaname = reader.GetString("username"),
                    categorie = reader.GetString("categorie"),
                    created_at = reader.GetDateTime("created_at"),
                    updated_at = reader.GetDateTime("updated_at")
                };
            }

            return user;
        }

        public List<Projet> ChargerProjets()
        {
            List<Projet> list = new List<Projet>();

            if (OpenConnection() == false)
            {
                return list;
            }
            string req = "SELECT projet.id as projetId, projet.reference as projetRef, projet.nom as projetNom, projet.created_at as projetCreated, projet.updated_at as projetUpdated, client.id as clientId, client.nom as clientNom, client.prenom as clientPrenom, client.adresse1 as clientAdresse, client.telephone as clientTel, client.portable as clientPort, client.email as clientMail, client.intitule as clientIntitule, client.type as clientType, client.created_at as clientCreated, client.updated_at as clientUpdated FROM projet JOIN client ON projet.id_client = client.id";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Projet projet = new Projet
                {
                    id = reader.GetInt32("projetId"),
                    reference = reader.GetString("projetRef"),
                    nom = reader.GetString("projetNom"),
                    created_at = reader.GetDateTime("projetCreated"),
                    updated_at = reader.GetDateTime("projetUpdated"),
                    id_client = reader.GetInt32("clientId"),
                    Client = new Client
                    {
                        id = reader.GetInt32("clientId"),
                        nom = reader.GetString("clientNom"),
                        prenom = reader.GetString("clientPrenom"),
                        adresse1 = reader.GetString("clientAdresse"),
                        telephone = reader.GetString("clientTel"),
                        protable = reader.GetString("clientPort"),
                        email = reader.GetString("clientMail"),
                        intitule = reader.GetString("clientIntitule"),
                        type = reader.GetString("clientType"),
                        created_at = reader.GetDateTime("clientCreated"),
                        updated_at = reader.GetDateTime("clientUpdated")
                    }
                };

                list.Add(projet);
            }

            CloseConnection();

            return list;
        }

        public List<Projet> ChargerProjetsParClient(int id)
        {
            List<Projet> list = new List<Projet>();

            if (OpenConnection() == false)
            {
                return list;
            }
            string req = "SELECT projet.id as projetId, projet.reference as projetRef, projet.nom as projetNom, projet.created_at as projetCreated, projet.updated_at as projetUpdated, client.id as clientId, client.nom as clientNom, client.prenom as clientPrenom, client.adresse1 as clientAdresse, client.telephone as clientTel, client.portable as clientPort, client.email as clientMail, client.intitule as clientIntitule, client.type as clientType, client.created_at as clientCreated, client.updated_at as clientUpdated FROM projet JOIN client ON projet.id_client = client.id WHERE client.id = @id";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            mySqlCommand.Parameters.Add(new MySqlParameter("@id", id));
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Projet projet = new Projet
                {
                    id = reader.GetInt32("projetId"),
                    reference = reader.GetString("projetRef"),
                    nom = reader.GetString("projetNom"),
                    created_at = reader.GetDateTime("projetCreated"),
                    updated_at = reader.GetDateTime("projetUpdated"),
                    id_client = reader.GetInt32("clientId"),
                    Client = new Client
                    {
                        id = reader.GetInt32("clientId"),
                        nom = reader.GetString("clientNom"),
                        prenom = reader.GetString("clientPrenom"),
                        adresse1 = reader.GetString("clientAdresse"),
                        telephone = reader.GetString("clientTel"),
                        protable = reader.GetString("clientPort"),
                        email = reader.GetString("clientMail"),
                        intitule = reader.GetString("clientIntitule"),
                        type = reader.GetString("clientType"),
                        created_at = reader.GetDateTime("clientCreated"),
                        updated_at = reader.GetDateTime("clientUpdated")
                    }
                };

                list.Add(projet);
            }

            CloseConnection();

            return list;
        }

        public List<Client> ChargerClients()
        {
            List<Client> list = new List<Client>();

            if (OpenConnection() == false)
            {
                return list;
            }
            string req = "SELECT client.id as clientId, client.nom as clientNom, client.prenom as clientPrenom, client.adresse1 as clientAdresse, client.telephone as clientTel, client.portable as clientPort, client.email as clientMail, client.intitule as clientIntitule, client.type as clientType, client.created_at as clientCreated, client.updated_at as clientUpdated FROM client";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Client client = new Client
                {
                    id = reader.GetInt32("clientId"),
                    nom = reader.GetString("clientNom"),
                    prenom = reader.GetString("clientPrenom"),
                    adresse1 = reader.GetString("clientAdresse"),
                    telephone = reader.GetString("clientTel"),
                    protable = reader.GetString("clientPort"),
                    email = reader.GetString("clientMail"),
                    intitule = reader.GetString("clientIntitule"),
                    type = reader.GetString("clientType"),
                    created_at = reader.GetDateTime("clientCreated"),
                    updated_at = reader.GetDateTime("clientUpdated")
                };

                list.Add(client);
            }

            CloseConnection();

            return list;
        }

        public Client ChargerClientParId(int id)
        {
            Client client = new Client();
            
            if (OpenConnection() == false)
            {
                return client;
            }
            string req = "SELECT client.id as clientId, client.nom as clientNom, client.prenom as clientPrenom, client.adresse1 as clientAdresse, client.telephone as clientTel, client.portable as clientPort, client.email as clientMail, client.intitule as clientIntitule, client.type as clientType, client.created_at as clientCreated, client.updated_at as clientUpdated FROM client WHERE client.id = @id";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            mySqlCommand.Parameters.Add(new MySqlParameter("@id", id));
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                client = new Client
                {
                    id = reader.GetInt32("clientId"),
                    nom = reader.GetString("clientNom"),
                    prenom = reader.GetString("clientPrenom"),
                    adresse1 = reader.GetString("clientAdresse"),
                    telephone = reader.GetString("clientTel"),
                    protable = reader.GetString("clientPort"),
                    email = reader.GetString("clientMail"),
                    intitule = reader.GetString("clientIntitule"),
                    type = reader.GetString("clientType"),
                    created_at = reader.GetDateTime("clientCreated"),
                    updated_at = reader.GetDateTime("clientUpdated")
                };
            }

            CloseConnection();

            return client;
        }

        public List<Gamme> ChargerGammes()
        {
            List<Gamme> list = new List<Gamme>();

            if (OpenConnection() == false)
            {
                return list;
            }
            string req = "SELECT gamme.id as gammeId, gamme.nom_gamme, gamme.famille_couverture, gamme.famille_isolant, gamme.famille_finition_exterieure, gamme.mode_conception_ossature, gamme.famille_gamme, unite_dusage.id as uniteUsageId, unite_dusage.description_unite_usage, unite_dusage.unite_unite_usage FROM gamme JOIN unite_dusage ON gamme.id_unite_dusage = unite_dusage.id";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Gamme gamme = new Gamme
                {
                    id = reader.GetInt32("gammeId"),
                    nom_gamme = reader.GetString("nom_gamme"),
                    famille_couverture = reader.GetString("famille_couverture"),
                    famille_isolant = reader.GetString("famille_isolant"),
                    famille_finition_exterieure = reader.GetString("famille_finition_exterieure"),
                    mode_conception_ossature = reader.GetString("mode_conception_ossature"),
                    famille_gamme = reader.GetString("famille_gamme"),
                    UniteDusage = new UniteDusage
                    {
                        id = reader.GetInt32("uniteUsageId"),
                        description_unite_usage = reader.GetString("description_unite_usage"),
                        unite_unite_usage = reader.GetString("unite_unite_usage"),
                    }
                };

                list.Add(gamme);
            }

            CloseConnection();

            return list;
        }

        public int SaveClient(Client client)
        {
            if (OpenConnection() == false) return 0;

            string req;
            if (client.id > 0)
            {
                req = "UPDATE client SET nom = @nom, prenom = @prenom, adresse1 = @adresse, telephone = @telephone, portable = @portable, email = @email, intitule = @intitule, type = @type, created_at = @created_at, updated_at = @updated_at WHERE id = @id";
            }
            else
            {
                req = "INSERT INTO client (id, nom, prenom, adresse1, telephone, portable, email, intitule, type, created_at, updated_at) VALUES (@id, @nom, @prenom, @adresse, @telephone, @portable, @email, @intitule, @type, @created_at, @updated_at)";
            }
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            if (client.id > 0)
            {
                mySqlCommand.Parameters.Add(new MySqlParameter("@id", client.id));
            }
            else
            {
                mySqlCommand.Parameters.Add(new MySqlParameter("@id", null));
            }
            mySqlCommand.Parameters.Add(new MySqlParameter("@nom", client.nom));
            mySqlCommand.Parameters.Add(new MySqlParameter("@prenom", client.prenom));
            mySqlCommand.Parameters.Add(new MySqlParameter("@adresse", client.adresse1));
            mySqlCommand.Parameters.Add(new MySqlParameter("@telephone", client.telephone));
            mySqlCommand.Parameters.Add(new MySqlParameter("@portable", client.protable));
            mySqlCommand.Parameters.Add(new MySqlParameter("@email", client.email));
            mySqlCommand.Parameters.Add(new MySqlParameter("@intitule", client.intitule));
            mySqlCommand.Parameters.Add(new MySqlParameter("@type", client.type));
            mySqlCommand.Parameters.Add(new MySqlParameter("@created_at", client.created_at));
            mySqlCommand.Parameters.Add(new MySqlParameter("@updated_at", client.updated_at));

            int res = mySqlCommand.ExecuteNonQuery();

            CloseConnection();

            return client.id;
        }

        public int SaveProjet(Projet projet, int idUser)
        {
            if (OpenConnection() == false) return 0;

            string req;
            if (projet.id > 0)
            {
                req = "UPDATE projet SET reference = @reference, nom = @nom, created_at = @created_at, updated_at = @updated_at, id_client = @idClient WHERE id = @id";
            }
            else
            {
                req = "INSERT INTO projet (id, reference, nom, created_at, updated_at, id_client) VALUES (@id, @reference, @nom, @created_at, @updated_at, @idClient)";
            }
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            if (projet.id > 0)
            {
                mySqlCommand.Parameters.Add(new MySqlParameter("@id", projet.id));
            }
            else
            {
                mySqlCommand.Parameters.Add(new MySqlParameter("@id", null));
            }
            mySqlCommand.Parameters.Add(new MySqlParameter("@reference", projet.reference));
            mySqlCommand.Parameters.Add(new MySqlParameter("@nom", projet.nom));
            mySqlCommand.Parameters.Add(new MySqlParameter("@created_at", projet.created_at));
            mySqlCommand.Parameters.Add(new MySqlParameter("@updated_at", projet.updated_at));
            mySqlCommand.Parameters.Add(new MySqlParameter("@idClient", projet.Client.id));

            int res = mySqlCommand.ExecuteNonQuery();

            int idProjet = (int)mySqlCommand.LastInsertedId;

            req = "INSERT INTO link_commercial_projet (id_projet, id_commercial) VALUES (@id_projet, @id_commercial)";
            MySqlCommand mySqlCommand2 = new MySqlCommand(req, mySqlConnection);
            mySqlCommand2.Parameters.Add(new MySqlParameter("@id_projet", idProjet));
            mySqlCommand2.Parameters.Add(new MySqlParameter("@id_commercial", idUser));

            mySqlCommand2.ExecuteNonQuery();

            CloseConnection();

            return projet.id;
        }

        public bool DelCustomer(Client client)
        {
            if (OpenConnection() == false) return false;

            string req = "DELETE FROM client WHERE id = @id";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            mySqlCommand.Parameters.Add(new MySqlParameter("@id", client.id));
            int res = mySqlCommand.ExecuteNonQuery();

            CloseConnection();

            return true;
        }
    }
}
