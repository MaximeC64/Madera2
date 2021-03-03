using ApplicationMadera.Utilisateurs.viewmodel;
using ModelApplicationMadera.CommunicationServeur;
using ModelApplicationMadera.DonneesLocales.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApplicationMadera.Modules.ModuleCreationDevis.viewmodel
{
    public class ViewModelClient
    {
        public Client Client { get; }
        public ViewModelProjets ViewModelProjets { get; set; }
        public ViewModelDevis ViewModelDevis { get; set; }

        public ViewModelClient(Client client)
        {
            Client = client;
        }
        public ViewModelClient(int id)
        {
            Client = GestionnaireCommunicationServeur.Instance.ChargerClientParId(id);
            ViewModelProjets = new ViewModelProjets(Client.id);
        }

        public string Name
        {
            get
            {
                return "pour " + Client.nom + " " + Client.prenom;
            }
        }

        public string Name2
        {
            get
            {
                return Client.prenom + " " + Client.nom;
            }
        }

        public event EventHandler DelClient;
        private ICommand commandDel;
        public ICommand CommandDel
        {
            get
            {
                if (commandDel == null)
                {
                    commandDel = new RelayCommand((object sender) =>
                    {
                        DelClient?.Invoke(this, EventArgs.Empty);
                    });
                }
                return commandDel;
            }
        }
    }
}
