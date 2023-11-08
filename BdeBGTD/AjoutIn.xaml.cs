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
    /// <summary>
    /// Interaction logic for AjoutIn.xaml
    /// </summary>
    public partial class AjoutIn : Window
    {
        public AjoutIn()
        {
            InitializeComponent();
        }

        private void ConfirmerButton_Click(object sender, RoutedEventArgs e)
        {
            if (KeepOpen.IsChecked == true)
            {
                // If the CheckBox is checked, do nothing (keep the window open).
            }
            else
            {
                // If the CheckBox is not checked, close the window.
                this.Close();
            }
        }
    }
}
