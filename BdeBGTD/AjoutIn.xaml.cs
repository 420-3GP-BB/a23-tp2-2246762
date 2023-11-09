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
    
    
    public partial class AjoutIn : Window
    {
        private GestionnaireGTD gestionnaire;
        public AjoutIn(GestionnaireGTD gestionnaire)
        {
            InitializeComponent();
            this.gestionnaire = gestionnaire;
        }

        private void ConfirmerButton_Click(object sender, RoutedEventArgs e)
        {

            // Récupérez le nom et la description
            string nom = Nom.Text;
            string description = Description.Text;


            // Vérifiez si le champ Nom est vide
            if (string.IsNullOrEmpty(nom))
            {
                // Affiche un message d'erreur indicant qu'il est obligatoire d'avoir un nom pour avoir un element et quitte la methode 
                MessageBox.Show("Le champ Nom est obligatoire.");
                return;
            }

            // Créez un nouvel élément ElementGTD
            ElementGTD nouvelElement = new ElementGTD
            {
                Nom = nom,
                Description = description,
                Statut = "Entree"
            };

            // Ajoutez l'élément à la collection ListeEntrees
            gestionnaire.ListeEntrees.Add(nouvelElement);

            // Fait en sorte que si la case n'est pas cocher fermer la page
            if (!KeepOpen.IsChecked.Value)
            {
                this.Close();
            }
            else
            {
                // Effacez les champs textes 
                Nom.Text = "";
                Description.Text = "";
            }
            
        }

        //  Ferme la page peut importe que la case sois cocher ou non
        private void AnnulerButton_Click(object sender, RoutedEventArgs e)
        {
                this.Close();
        }
    }
}
