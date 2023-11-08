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

            // Récupérez le nom et la description depuis les contrôles de la fenêtre
            string nom = Nom.Text;
            string description = Description.Text;


            // Vérifiez si le champ Nom est vide
            if (string.IsNullOrEmpty(nom))
            {
                // Affichez un message d'erreur à l'utilisateur ou effectuez une autre action appropriée
                MessageBox.Show("Le champ Nom est obligatoire.");
                return; // Sortez de la méthode sans ajouter l'élément
            }

            // Créez un nouvel élément ElementGTD
            ElementGTD nouvelElement = new ElementGTD
            {
                Nom = nom,
                Description = description,
                Statut = "Entree" // Vous pouvez définir le statut comme requis
            };

            // Ajoutez l'élément à la collection ListeEntrees de votre gestionnaire
            gestionnaire.ListeEntrees.Add(nouvelElement);

            // Si la case à cocher "Rester ouvert" n'est pas cochée, fermez la fenêtre
            if (!KeepOpen.IsChecked.Value)
            {
                this.Close();
            }
            else
            {
                // Effacez les champs textes pour permettre d'entrer de nouvelles valeurs
                Nom.Text = "";
                Description.Text = "";
            }
            
        }

        private void AnnulerButton_Click(object sender, RoutedEventArgs e)
        {
                this.Close();
        }
    }
}
