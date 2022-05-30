using System;
using AdonisUI;
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
using System.Data.Entity;
using System.Data;


namespace ProjektZaliczeniowy
{
    /// <summary>
    /// Interaction logic for PracownicyWindow.xaml
    /// </summary>
    public partial class PracownicyWindow : Window
    {
        HotelEntities context = new HotelEntities();
        CollectionViewSource pracownicy = new CollectionViewSource();
        public PracownicyWindow()
        {
            InitializeComponent();
            pracownicy = ((CollectionViewSource)(FindResource("pracownicyViewSource")));
            //DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AdonisUI.ResourceLocator.SetColorScheme(Application.Current.Resources, ResourceLocator.DarkColorScheme);
            context.Pracownicy.Load();
            System.Windows.Data.CollectionViewSource pracownicyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pracownicyViewSource")));
            pracownicyViewSource.Source = context.Pracownicy.Local;
            zatrudniny_OdDatePicker.SelectedDate = DateTime.Now;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pracownicy pracownicy = new Pracownicy() {Email = emailTextBox.Text, Imie = imieTextBox.Text, Nazwisko = nazwiskoTextBox.Text, Nr_Telefonu = nr_TelefonuTextBox.Text, Zatrudniny_Od = (DateTime)zatrudniny_OdDatePicker.SelectedDate };
                if ((DateTime)zatrudniny_OdDatePicker.SelectedDate > DateTime.Now)
                    throw new ArgumentException();
                context.Pracownicy.Add(pracownicy);
                context.SaveChanges();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                context.Pracownicy.Load();
            }
        }

        private void DeleteButton1_Click(object sender, RoutedEventArgs e)
        {
            var lista = (Pracownicy)pracownicyDataGrid.SelectedItem;
            context.Pracownicy.Remove(context.Pracownicy.Find(lista.ID_Pracownika));
            context.SaveChanges();
            MessageBox.Show("Usunieto");
        }
        private void myDG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            context.SaveChanges();
        }


        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    IList<ItemCollection> lista = pracownicyDataGrid.ItemsSource;
        //}
    }
}
