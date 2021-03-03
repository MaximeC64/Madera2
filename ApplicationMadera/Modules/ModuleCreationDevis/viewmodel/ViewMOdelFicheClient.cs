using ModelApplicationMadera.DonneesLocales.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModelApplicationMadera.CommunicationServeur;
using System.Windows;

namespace ApplicationMadera.Modules.ModuleCreationDevis.viewmodel
{
    public class ViewModelFicheClient : ViewModelBase
    {
        public Client Client { get; set; }
        public bool RadioHomme { get; set; }
        public bool RadioFemme { get; set; }

        public ViewModelFicheClient(Client client)
        {
            Client = client;
        }

        private ICommand commandSave;
        public ICommand CommandSave
        {
            get
            {
                if (commandSave == null)
                {
                    commandSave = new RelayCommand((object sender) =>
                    {
                        Client.created_at = DateTime.Today;
                        Client.updated_at = DateTime.Today;
                        if (RadioFemme == true) 
                            Client.intitule = "Femme"; 
                        else if (RadioHomme == true) 
                            Client.intitule = "Homme";

                        GestionnaireCommunicationServeur.Instance.SaveClient(Client);
                        MessageBox.Show("Le lient a bien été ajouté !", "Message d'information", MessageBoxButton.OK, MessageBoxImage.Information);

                        ClearFields();
                    },
                    (object sender) =>
                    {
                        if (string.IsNullOrWhiteSpace(Client.nom) || string.IsNullOrWhiteSpace(Client.prenom) || string.IsNullOrWhiteSpace(Client.adresse1) || string.IsNullOrWhiteSpace(Client.telephone) || string.IsNullOrWhiteSpace(Client.protable) || string.IsNullOrWhiteSpace(Client.email) || string.IsNullOrWhiteSpace(Client.type) || (RadioHomme == false && RadioFemme == false))
                        {
                            return false;
                        }
                        return true;
                    });
                }
                return commandSave;
            }
        }

        private void ClearFields()
        {
            Client = new Client();
        }
    }
}
