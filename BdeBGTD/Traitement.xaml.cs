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
        private ElementGTD element;
        public Traitement(ElementGTD element)
        {
            InitializeComponent();
            this.element = element;

            Nom.Text = element.Nom;
            Description.Text = element.Description;
            
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
        private void Incuber_Click(object sender, RoutedEventArgs e)
        {
            
            dateSuivi dateIncubation = new dateSuivi();
            dateIncubation.Show();
        }
    }
}
