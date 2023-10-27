using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace BdeBGTD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DateTime dt;
        public static RoutedCommand AProprosCmd = new RoutedCommand();
        public MainWindow()
        {
            InitializeComponent();
            dt = DateTime.Now;
            AfficherDate(dt);
            
        }
        private void AfficherDate(DateTime dt)
        {
            DateText.Text = dt.ToString("yyyy-MM-dd");
        }
        private void BoutonPlus(object sender, ExecutedRoutedEventArgs e)
        {
            dt = dt.AddDays(1);
            AfficherDate(dt);
        }

        private void APropos_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("BdeB GTD\nVersion 1.0\nAuteur : Nicolas Werbrouck");
        }

        private void APropos_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
