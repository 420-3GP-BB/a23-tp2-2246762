using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class dateSuivi : Window
    {
        public dateSuivi()
        {
            InitializeComponent();
        }

        //Methode qui selection les dates et ferme la page
        private void selectionDate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (selectionDate.SelectedDate.HasValue)
            {
                DateTime selectedDate = selectionDate.SelectedDate.Value;
                this.Close();
            }
        }
    }
}
