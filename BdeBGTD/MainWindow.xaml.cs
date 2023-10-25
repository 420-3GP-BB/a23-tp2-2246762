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

namespace BdeBGTD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RoutedCommand AProprosCmd = new RoutedCommand();
        public MainWindow()
        {
            InitializeComponent();
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
