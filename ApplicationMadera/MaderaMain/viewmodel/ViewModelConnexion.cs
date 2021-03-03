using ModelApplicationMadera.CommunicationServeur;
using ModelApplicationMadera.DonneesLocales.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApplicationMadera.MaderaMain.viewmodel
{
    public class ViewModelConnexion : ViewModelBase
    {
        public UserMadera User { get; set; }

        private string login;
        private string password;

        public ViewModelConnexion()
        {
        }

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                if (login != value)
                {
                    login = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool Validate()
        {
            User = GestionnaireCommunicationServeur.Instance.CheckConnect(login, password);
            if (User != null)
                return true;
            else
                return false;
        }
    }
}
