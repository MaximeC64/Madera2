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

namespace ApplicationMadera.Modules.ModuleCreationDevis.viewmodel
{
    class ViewModelGammes : ViewModelBase
    {
        public ObservableCollection<ViewModelGamme> ListeGammes { get; set; }
        private ICollectionView observer;

        public ViewModelGamme GammeSelected
        {
            get
            {
                return (ViewModelGamme)observer.CurrentItem;
            }
            set
            {

            }
        }

        public ViewModelGammes()
        {
            addGammeToList(GestionnaireCommunicationServeur.Instance.ChargerGammes());
        }

        private void Observer_CurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("GammeSelected");
        }

        public void addGammeToList(List<Gamme> listGammes)
        {
            ListeGammes = new ObservableCollection<ViewModelGamme>();
            foreach (Gamme g in listGammes)
            {
                ViewModelGamme gamme = new ViewModelGamme(g);
                ListeGammes.Add(gamme);
            }

            observer = CollectionViewSource.GetDefaultView(ListeGammes);
            observer.MoveCurrentToFirst();
            observer.CurrentChanged += Observer_CurrentChanged;
        }
    }
}
