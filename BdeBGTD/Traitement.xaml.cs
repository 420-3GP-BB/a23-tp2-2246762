using GTD;
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
using System.Windows.Shapes;

namespace BdeBGTD
{

    public partial class Traitement : Window
    {
        public static MainWindow MainWindowReference {  get; set; }
        private ElementGTD element;
        public Traitement(ElementGTD element)
        {
            InitializeComponent();
            this.element = element;

            // Affiche les elements fournis dans les endroits appropriez
            Nom.Text = element.Nom;
            Description.Text = element.Description;
            
            MainWindowReference = (MainWindow)Application.Current.MainWindow;
        }

        // Ferme la page
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ActionRapide_Click(object sender, RoutedEventArgs e)
        {
            
        }

        // Ouvre la page permettant de choisir une date pour faire un suivi
        private void Incuber_Click(object sender, RoutedEventArgs e, ElementGTD element)
        {
            
            dateSuivi dateIncubation = new dateSuivi();
            if(dateIncubation.ShowDialog()==true)
            {
                element.Date = dateIncubation.selectionDate.SelectedDate ?? DateTime.Now;

                MainWindowReference.Suivi.Items.Add(element);
                MainWindowReference.Suivi.Items.Refresh();
            }
        }
    }
}
