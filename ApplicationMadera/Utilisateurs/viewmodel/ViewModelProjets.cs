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
    public class ViewModelProjets : ViewModelBase
    {
        public ObservableCollection<ViewModelProjet> ListProjets { get; set; }
        private ICollectionView observer;

        public ViewModelProjet ProjetSelected
        {
            get
            {
                return (ViewModelProjet)observer.CurrentItem;
            }
            set
            {

            }
        }

        public ViewModelProjets()
        {
            addProjetToList(GestionnaireCommunicationServeur.Instance.ChargerProjets());
        }

        public ViewModelProjets(int id)
        {
            addProjetToList(GestionnaireCommunicationServeur.Instance.ChargerProjetsParClient(id));
        }

        private void Observer_CurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("ProjetSelected");
        }

        private void deleteProjet(object sender, EventArgs e)
        {
            this.ListProjets.Remove(ProjetSelected);
            observer.MoveCurrentToFirst();
        }

        public void addProjetToList(List<Projet> listProjets)
        {
            ListProjets = new ObservableCollection<ViewModelProjet>();
            foreach (Projet p in listProjets)
            {
                ViewModelProjet projet = new ViewModelProjet(p);
                projet.DelProjet += deleteProjet;
                ListProjets.Add(projet);
            }

            observer = CollectionViewSource.GetDefaultView(ListProjets);
            observer.MoveCurrentToFirst();
            observer.CurrentChanged += Observer_CurrentChanged;
        }


    }
}
