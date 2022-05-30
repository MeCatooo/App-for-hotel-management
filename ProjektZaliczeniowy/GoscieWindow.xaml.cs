using AdonisUI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Logika interakcji dla klasy GoscieWindow.xaml
    /// </summary>
    public partial class GoscieWindow : Window
    {
        HotelEntities context = new HotelEntities();
        CollectionViewSource goscie = new CollectionViewSource();
        public GoscieWindow()
        {
            InitializeComponent();
            goscie = ((CollectionViewSource)(FindResource("goscieViewSource")));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AdonisUI.ResourceLocator.SetColorScheme(Application.Current.Resources, ResourceLocator.DarkColorScheme);
            context.Goscie.Load();
            System.Windows.Data.CollectionViewSource goscieViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("goscieViewSource")));
            goscieViewSource.Source = context.Goscie.Local;
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // goscieViewSource.Źródło = [ogólne źródło danych]
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var lista = (Goscie)goscieDataGrid.SelectedItem;
            context.Goscie.Remove(context.Goscie.Find(lista.ID_Goscia));
            context.SaveChanges();
            MessageBox.Show("Usunieto");
        }
        private void myDG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            context.SaveChanges();
        }
    }
}
