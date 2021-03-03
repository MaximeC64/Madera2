using ApplicationMadera.Utilisateurs.viewmodel;
using ModelApplicationMadera.CommunicationServeur;
using ModelApplicationMadera.DonneesLocales.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ApplicationMadera.Modules.ModuleCreationDevis.viewmodel
{
    class ViewModelFicheProjet
    {
        public Projet Projet { get; set; }
        public ViewModelClients ViewModelClients { get; }
        public ViewModelGammes ViewModelGammes { get; }

        public ViewModelFicheProjet(Projet projet)
        {
            Projet = projet;
            ViewModelClients = new ViewModelClients();
            ViewModelGammes = new ViewModelGammes();
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
                        Projet.created_at = DateTime.Today;
                        Projet.updated_at = DateTime.Today;
                        Projet.Client = ViewModelClients.ClientSelected.Client;
                        UserMadera UserMadera = (UserMadera) Application.Current.Properties["UserConnected"];

                        GestionnaireCommunicationServeur.Instance.SaveProjet(Projet, UserMadera.id);
                        MessageBox.Show("Le projet a bien été ajouté !", "Message d'information", MessageBoxButton.OK, MessageBoxImage.Information);

                        ClearFields();
                    },
                    (object sender) =>
                    {
                        if (string.IsNullOrWhiteSpace(Projet.nom) || string.IsNullOrWhiteSpace(Projet.reference))
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
            Projet = new Projet();
        }
    }
}
