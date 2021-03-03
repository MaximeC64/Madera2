using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ApplicationMadera.Utilisateurs.viewmodel;

namespace ApplicationMadera.Utilisateurs.view
{
    /// <summary>
    /// Logique d'interaction pour ControlClients.xaml
    /// </summary>
    public partial class ControlClients : UserControl
    {
        public ControlClients()
        {
            InitializeComponent();
            this.DataContext = new ViewModelClients();
        }
    }
}
