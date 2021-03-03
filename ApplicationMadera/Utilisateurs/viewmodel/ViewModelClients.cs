using ApplicationMadera.Modules.ModuleCreationDevis.viewmodel;
using ModelApplicationMadera.CommunicationServeur;
using ModelApplicationMadera.DonneesLocales.Entites;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ApplicationMadera.Utilisateurs.viewmodel
{
    class ViewModelClients : ViewModelBase
    {
        public ObservableCollection<ViewModelClient> ListClients { get; set; }
        private ICollectionView observer;

        public ViewModelClient ClientSelected
        {
            get
            {
                return (ViewModelClient)observer.CurrentItem;
            }
            set
            {

            }
        }

        public ViewModelClients()
        {
            addClientToList(GestionnaireCommunicationServeur.Instance.ChargerClients());
        }

        private void Observer_CurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("ClientSelected");
        }

        private void deleteClient(object sender, EventArgs e)
        {
            this.ListClients.Remove(ClientSelected);
            observer.MoveCurrentToFirst();
        }

        public void addClientToList(List<Client> listClients)
        {
            ListClients = new ObservableCollection<ViewModelClient>();
            foreach (Client c in listClients)
            {
                ViewModelClient client = new ViewModelClient(c);
                client.DelClient += deleteClient;
                ListClients.Add(client);
            }

            observer = CollectionViewSource.GetDefaultView(ListClients);
            observer.MoveCurrentToFirst();
            observer.CurrentChanged += Observer_CurrentChanged;
        }
    }
}
