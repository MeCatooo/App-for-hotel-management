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
            context.Pracownicy.Load();
            System.Windows.Data.CollectionViewSource pracownicyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pracownicyViewSource")));
            pracownicyViewSource.Source = context.Pracownicy.Local;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pracownicy pracownicy = new Pracownicy() { ID_Pracownika = int.Parse(iD_PracownikaTextBox.Text), Email = emailTextBox.Text, Imie = imieTextBox.Text, Nazwisko = nazwiskoTextBox.Text, Nr_Telefonu = nr_TelefonuTextBox.Text, Zatrudniny_Od = (DateTime)zatrudniny_OdDatePicker.SelectedDate };
            try
            {
                if ((DateTime)zatrudniny_OdDatePicker.SelectedDate > DateTime.Now)
                    throw new ArgumentException();
                int tmpId = int.Parse(iD_PracownikaTextBox.Text);
            if (context.Pracownicy.Any(element => element.ID_Pracownika == tmpId))
            {
                var toEdit = context.Pracownicy.Find(int.Parse(iD_PracownikaTextBox.Text));
                context.Entry(toEdit).CurrentValues.SetValues(pracownicy);
                context.SaveChanges();
            }
            else
            {
                context.Pracownicy.Add(pracownicy);
                context.SaveChanges();
            }
            }
            catch (Exception)
            {
                MessageBox.Show("Niepoprawne dane");
            }
            finally
            {
                context.Pracownicy.Load();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            context.Pracownicy.Remove(context.Pracownicy.Find(int.Parse(iD_PracownikaTextBox.Text)));
            context.SaveChanges();
            MessageBox.Show("Usunieto");
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    IList<ItemCollection> lista = pracownicyDataGrid.ItemsSource;
        //}
    }
}
