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
        public static RoutedCommand AddEntry = new RoutedCommand();
        public static RoutedCommand Triage = new RoutedCommand();
        public MainWindow()
        {
            InitializeComponent();
            dt = DateTime.Now;
            AfficherDate(dt);
            AddEntryMenu.Click += AddEntryMenu_Click;
            TraiterMenu.Click += TraiterMenu_Click;

        }

        private void TraiterMenu_Click(object sender, RoutedEventArgs e)
        {
            Traitement traiter = new Traitement();
            traiter.ShowDialog();
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
            AjoutIn addEntrer = new AjoutIn();
            addEntrer.ShowDialog();

        }

        private void Triage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Triage_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Traitement traiter = new Traitement();
            traiter.ShowDialog();
        }
    }
}
