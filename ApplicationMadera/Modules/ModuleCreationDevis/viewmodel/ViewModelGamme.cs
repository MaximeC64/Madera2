using ModelApplicationMadera.DonneesLocales.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationMadera.Modules.ModuleCreationDevis.viewmodel
{
    class ViewModelGamme : ViewModelBase
    {
        public Gamme Gamme { get; }

        public ViewModelGamme(Gamme gamme)
        {
            Gamme = gamme;
        }

        public string Name
        {
            get
            {
                return Gamme.nom_gamme;
            }
        }
    }
}
