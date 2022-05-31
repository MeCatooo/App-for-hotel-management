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

namespace ProjektZaliczeniowy
{
    /// <summary>
    /// Logika interakcji dla klasy UslugiWindow.xaml
    /// </summary>
    public partial class UslugiWindow : Window
    {
        public UslugiWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource dodatkowe_OplatyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("dodatkowe_OplatyViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // dodatkowe_OplatyViewSource.Źródło = [ogólne źródło danych]
        }
    }
}
