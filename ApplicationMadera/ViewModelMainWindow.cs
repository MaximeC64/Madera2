using ApplicationMadera.MaderaMain.viewmodel;
using ApplicationMadera.Modules.ModuleCreationDevis.viewmodel;
using ApplicationMadera.Utilisateurs.viewmodel;
using ModelApplicationMadera.DonneesLocales.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApplicationMadera
{
    public class ViewModelMainWindow : ViewModelBase
    {
        // GESTION UTILISATEUR
        public UserMadera UserMadera { get; set; }
        public string NomUtilisateur
        {
            get
            {
                if (Application.Current.Properties["UserConnected"] != null)
                    return UserMadera.prenom + " " + UserMadera.nom;
                else
                    return null;
            }
            set
            {

            }
        }
        public string Nom
        {
            get
            {
                return UserMadera.nom;
            }

            set
            {
                UserMadera.nom = value;
                OnPropertyChanged();
                OnPropertyChanged("NomUtilisateur");
            }
        }
        public string Prenom
        {
            get
            {
                return UserMadera.prenom;
            }

            set
            {
                UserMadera.prenom = value;
                OnPropertyChanged();
                OnPropertyChanged("NomUtilisateur");
            }
        }
        public string Email
        {
            get
            {
                return UserMadera.email;
            }

            set
            {
                UserMadera.email = value;
            }
        }
        // GESTION UTILISATEUR

        // POUR VERSION SANS FRAME
        public ICommand ChargerConnexion { get; set; }
        public ICommand ChargerListeClients { get; set; }
        public ICommand ChargerListeProjets { get; set; }
        public ICommand ChargerAjoutClient { get; set; }
        public ICommand ChargerAjoutProjet { get; set; }
        public ICommand ChargerConsultClient { get; set; }

        public ViewModelConnexion ViewModelConnexion = new ViewModelConnexion(); 

        private bool menuVisibility;
        public bool MenuVisibility
        {
            get
            {
                return menuVisibility;
            }
            set
            {
                menuVisibility = value; 
                OnPropertyChanged("MenuVisibility");
            }
        }

        private object selectedViewModel;

        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }

        public ViewModelMainWindow()
        {
            ChargerConnexion = new RelayCommand(OuvrirControlConnexion);
            ChargerListeClients = new RelayCommand(OuvrirControlClients);
            ChargerListeProjets = new RelayCommand(OuvrirControlProjets);
            ChargerAjoutClient = new RelayCommand(OuvrirControlFicheClient);
            ChargerAjoutProjet = new RelayCommand(OuvrirControlFicheProjet);
            ChargerConsultClient = new RelayCommand(OuvrirControlClient);
            MenuVisibility = false;
            SelectedViewModel = ViewModelConnexion;
        }

        private void OuvrirControlConnexion(object obj)
        {
            MenuVisibility = false;
            SelectedViewModel = new ViewModelConnexion();
        }

        private void OuvrirControlClients(object obj)
        {
            MenuVisibility = true;
            SelectedViewModel = new ViewModelClients();
        }
        private void OuvrirControlProjets(object obj)
        {
            MenuVisibility = true;
            SelectedViewModel = new ViewModelProjets();
        }
        private void OuvrirControlFicheClient(object obj)
        {
            MenuVisibility = true;
            SelectedViewModel = new ViewModelFicheClient(new Client());
        }
        private void OuvrirControlFicheProjet(object obj)
        {
            MenuVisibility = true;
            SelectedViewModel = new ViewModelFicheProjet(new Projet());
        }
        private void OuvrirControlClient(object obj)
        {
            MenuVisibility = true;
            int id = (int)obj;
            SelectedViewModel = new ViewModelClient(id);
        }
        // POUR VERSION SANS FRAME

        private ICommand commandConnect;
        public ICommand CommandConnect
        {
            get
            {
                if (commandConnect == null)
                {
                    commandConnect = new RelayCommand((object sender) =>
                    {
                        PasswordBox passwordBox = (PasswordBox)sender;
                        ViewModelConnexion.Password = passwordBox.Password;
                        bool isValidated = ViewModelConnexion.Validate();
                        if (isValidated)
                        {
                            Application.Current.Properties["UserConnected"] = ViewModelConnexion.User;
                            UserMadera = ViewModelConnexion.User;
                            Prenom = UserMadera.prenom;
                            Nom = UserMadera.nom;
                            Email = UserMadera.email;
                            MenuVisibility = true;
                            SelectedViewModel = new ViewModelProjets();
                        }
                        else
                        {
                            MessageBox.Show("Identifiant ou mot de passe erroné !", "Message d'erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }, (object sender) =>
                    {
                        if (string.IsNullOrWhiteSpace(ViewModelConnexion.Login))
                        {
                            return false;
                        }
                        return true;
                    });
                }
                return commandConnect;
            }
        }

        private ICommand commandDisconnect;
        public ICommand CommandDisconnect
        {
            get
            {
                if (commandDisconnect == null)
                {
                    commandDisconnect = new RelayCommand((object sender) =>
                    {
                        MenuVisibility = false;
                        ViewModelConnexion = new ViewModelConnexion();
                        SelectedViewModel = ViewModelConnexion;
                    });
                }

                return commandDisconnect;
            }
        }
    }
}
