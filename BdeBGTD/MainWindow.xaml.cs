using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Xml;
using System.IO;
using GTD;

namespace BdeBGTD
{
    public partial class MainWindow : Window
    {
        /// Variable permettant de voir la date ainsi que de rajouter une journee
        private DateTime dt;

        private GestionnaireGTD gestionnaire;
        char DIR_SEPARATOR = Path.DirectorySeparatorChar;   // Permet d'avoir un séparateur portable
        string nomFichier = "bdeb_gtd.xml";



        /// Commande afin de changer de page
        public static RoutedCommand AProprosCmd = new RoutedCommand();
        public static RoutedCommand AddEntry = new RoutedCommand();
        public static RoutedCommand Triage = new RoutedCommand();
        public static RoutedCommand Leave = new RoutedCommand();



        public MainWindow()
        {

            InitializeComponent();

            //
            gestionnaire = new GestionnaireGTD();

            // Prends la date d'aujord'hui et l'affiche dans le programmes
            dt = DateTime.Now;
            AfficherDate(dt);


            //Charge le fichier xml
            ChargerFichierXml();


            Entrer.ItemsSource = gestionnaire.ListeEntrees;
            Entrer.MouseDoubleClick += Entrer_MouseDoubleClick;

            //Fait en sorte de verifier que s'il n'y a rien dams la liste entrees l'option traiter sera fermer.
            TraiterMenu.IsEnabled = gestionnaire.ListeEntrees.Count > 0;

            // Affiche les pages lorsqu'on click sur le menu
            AddEntryMenu.Click += AddEntryMenu_Click;
            TraiterMenu.Click += TraiterMenu_Click;



        }

        private void Entrer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Triage_Executed(sender, null);
        }


        //Methode qui charge le fichier Xml
        private void ChargerFichierXml()
        {
            string pathMesDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pathDossier = $"{pathMesDocuments}{DIR_SEPARATOR}Fichiers-3GP";
            string pathFichier = $"{pathDossier}{DIR_SEPARATOR}{nomFichier}";

            XmlDocument document = new XmlDocument();
                document.Load(pathFichier);
            XmlElement racine = document.DocumentElement;

            XmlNodeList elementGTD = racine.GetElementsByTagName("element_gtd");

            foreach (XmlElement unElement in elementGTD)
            {
                ElementGTD nouvelElement = new ElementGTD
                {
                    Nom = unElement.GetAttribute("nom"),
                    Statut = unElement.GetAttribute("statut"),
                    Description = unElement.InnerText
                };

                gestionnaire.ListeEntrees.Add(nouvelElement);
            }
        }

        private void AfficherDate(DateTime dt)
        {
            DateText.Text = dt.ToString("yyyy-MM-dd");
        }
        private void APropos_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("BdeB GTD\nVersion 1.0\nAuteur : Nicolas Werbrouck");
        }

        private void APropos_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dt = dt.AddDays(1);
            AfficherDate(dt);
        }
        private void AddEntry_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AjoutIn addEntrer = new AjoutIn(gestionnaire);
            addEntrer.Show();
            
        }

        private void AddEntry_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void AddEntryMenu_Click(object sender, RoutedEventArgs e)
        {
            AddEntry_Executed(sender, null);

        }

        private void Triage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute= true;
        }

        private void Triage_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (Entrer.SelectedItem is ElementGTD element)
            {
                Traitement pageTraitement = new Traitement(element);
                if (pageTraitement.ShowDialog() == true) 
                {
                    Entrer.Items.Refresh();
                }
            }
        }

        private void TraiterMenu_Click(object sender, RoutedEventArgs e)
        {
            Triage_Executed(sender, null);
        }

        private void Leave_Click(object sender, RoutedEventArgs e)
        {
            Leave_Executed(sender,null);
        }

        private void Leave_Executed(object sender, ExecutedRoutedEventArgs e)
        {
                XmlDocument document = new XmlDocument();

                // Créez un élément racine pour le document
                XmlElement racine = document.CreateElement("gtd");
                document.AppendChild(racine);

                // Parcourez les éléments de la liste ListeEntrees de votre gestionnaire
                foreach (ElementGTD element in gestionnaire.ListeEntrees)
                {
                    // Créez un élément "element_gtd" pour chaque élément de la liste
                    XmlElement elementXml = document.CreateElement("element_gtd");
                    elementXml.SetAttribute("nom", element.Nom);
                    elementXml.SetAttribute("statut", element.Statut);
                    elementXml.InnerText = element.Description;

                    // Ajoutez l'élément "element_gtd" à l'élément racine
                    racine.AppendChild(elementXml);
                }

                // Sauvegardez le document dans le fichier
                string pathMesDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string pathDossier = $"{pathMesDocuments}{DIR_SEPARATOR}Fichiers-3GP";
                string pathFichier = $"{pathDossier}{DIR_SEPARATOR}{nomFichier}";
                document.Save(pathFichier);
                this.Close();
            
        }

        private void Leave_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        
    }
}
