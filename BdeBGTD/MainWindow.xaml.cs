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


        public MainWindow()
        {

            InitializeComponent();

            //
           gestionnaire = new GestionnaireGTD();

            // Prends la date d'aujord'hui et l'affiche dans le programmes
            dt = DateTime.Now;
            AfficherDate(dt);

//            pathFichier = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "CopierFichier", "bdeb_gtd.xml");
            //"C:\Users\Lekid\Documents\GitHub\a23-tp2-2246762\CopierFichier\assets\bdeb_gtd.xml"

            ChargerFichierXml();

            Entrer.ItemsSource = gestionnaire.ListeEntrees;


            // Affiche les pages lorsqu'on click sur le menu
            AddEntryMenu.Click += AddEntryMenu_Click;
            TraiterMenu.Click += TraiterMenu_Click;



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
            AjoutIn addEntrer = new AjoutIn();
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
            Traitement traiter = new Traitement();
            traiter.ShowDialog();
        }

        private void TraiterMenu_Click(object sender, RoutedEventArgs e)
        {
            Traitement traiter = new Traitement();
            traiter.ShowDialog();
        }
    }
}
