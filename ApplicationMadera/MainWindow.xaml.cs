using ApplicationMadera.MaderaMain.view;
using ApplicationMadera.Modules.ModuleCreationDevis.view;
using ApplicationMadera.Pages;
using ApplicationMadera.Utilisateurs.view;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApplicationMadera
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //chargerPageConnexion();
            //chargerPageProjets();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbShowLeftMenu", spLeft);
        }

        private void ShowHideMenu(string storyboardhide, StackPanel pnl)
        {
            Storyboard sb = Resources[storyboardhide] as Storyboard;
            sb.Begin(pnl);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbHideLeftMenu", spLeft);
        }

        private void chargerPageConnexion() {
            cacherMenuHaut();
           // MainFrame.NavigationService.Navigate(new ControlConnexion());

        }

        private void chargerPageClients()
        {
            montrerMenuHaut();
            //MainFrame.NavigationService.Navigate(new ControlClients());
        }

        private void chargerPageProjets()
        {
            montrerMenuHaut();
            //MainFrame.NavigationService.Navigate(new ControlProjets());

        }

        private void chargerPageGammes()
        {
            montrerMenuHaut();
            //MainFrame.NavigationService.Navigate(new ControlGammes());
        }

        private void chargerPageUtilisateur()
        {
            montrerMenuHaut();
            //MainFrame.NavigationService.Navigate(new ControlClients());
        }
        private void cacherMenuHaut() {
            //MainMenu.Visibility = Visibility.Collapsed;
        }

        private void montrerMenuHaut()
        {
            MainMenu.Visibility = Visibility.Visible;
        }

        private void clients_Click(object sender, RoutedEventArgs e)
        {
            //chargerPageClients();
        }

        private void projets_Click(object sender, RoutedEventArgs e)
        {
            //chargerPageProjets();
        }

        private void gammes_Click(object sender, RoutedEventArgs e)
        {
            //chargerPageGammes();
        }

        private void compteUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            //chargerPageUtilisateur();
        }
    }
}
