using ModelApplicationMadera.DonneesLocales.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApplicationMadera.Modules.ModuleCreationDevis.viewmodel
{
    public class ViewModelProjet
    {
        public Projet Projet { get; }
        public ViewModelClient Client { get; }

        public ViewModelProjet(Projet projet)
        {
            Projet = projet;
            Client = new ViewModelClient(projet.Client);
        }

        public event EventHandler DelProjet;
        private ICommand commandDel;
        public ICommand CommandDel
        {
            get
            {
                if (commandDel == null)
                {
                    commandDel = new RelayCommand((object sender) =>
                    {
                        DelProjet?.Invoke(this, EventArgs.Empty);
                    });
                }
                return commandDel;
            }
        }

    }
}
