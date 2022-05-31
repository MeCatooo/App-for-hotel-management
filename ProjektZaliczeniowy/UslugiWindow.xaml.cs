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
    /// Logika interakcji dla klasy UslugiWindow.xaml
    /// </summary>
    public partial class UslugiWindow : Window
    {
        HotelEntities context = new HotelEntities();
        CollectionViewSource oplaty = new CollectionViewSource();
        public UslugiWindow()
        {
            InitializeComponent();
            oplaty = ((CollectionViewSource)(FindResource("dodatkowe_OplatyViewSource")));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AdonisUI.ResourceLocator.SetColorScheme(Application.Current.Resources, ResourceLocator.DarkColorScheme);
            context.Dodatkowe_Oplaty.Load();
            System.Windows.Data.CollectionViewSource dodatkowe_OplatyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("dodatkowe_OplatyViewSource")));
            dodatkowe_OplatyViewSource.Source = context.Dodatkowe_Oplaty.Local;
            data_WykonaniaDatePicker.SelectedDate = DateTime.Now;
            var tmp = context.Dodatkowe_Uslugi.ToArray();
            List<string> list = new List<string>();
            foreach (var item in tmp)
            {
                list.Add(item.Nazwa_Uslugi);
            }
            nazwa_UslugiComboBox.ItemsSource = list;
            nazwa_UslugiComboBox.SelectedIndex = 0;
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // dodatkowe_OplatyViewSource.Źródło = [ogólne źródło danych]
        }
        private void DeleteButton1_Click(object sender, RoutedEventArgs e)
        {
            var lista = (Dodatkowe_Oplaty)dodatkowe_OplatyDataGrid.SelectedItem;
            context.Pracownicy.Remove(context.Pracownicy.Find(lista.ID_Uslugi));
            context.SaveChanges();
            MessageBox.Show("Usunieto");
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int? idPokoju = context.Pokoje.FirstOrDefault(element => element.Nr_Pokoju.ToString() == numer_PokojuTextBox.Text).ID_Pokoju;
            if (idPokoju == null)
                throw new ArgumentException();
            int? idGoscia = context.Historia_Rezerwacji.OrderByDescending(a => a.ID_Rezerwacja).FirstOrDefault(element => element.ID_Pokoju == idPokoju).ID_Goscia;
            if (idGoscia == null)
                throw new ArgumentException();
            Dodatkowe_Uslugi dodatkowe = context.Dodatkowe_Uslugi.FirstOrDefault(element => element.Nazwa_Uslugi == nazwa_UslugiComboBox.SelectedItem.ToString());
            if (dodatkowe == null)
                throw new ArgumentException();
            Dodatkowe_Oplaty dodatkowe_Oplaty = new Dodatkowe_Oplaty() { Data_Wykonania = data_WykonaniaDatePicker.SelectedDate.Value, Dodatkowe_Uslugi = dodatkowe, ID_Goscia = (int)idGoscia };
            context.Dodatkowe_Oplaty.Add(dodatkowe_Oplaty);
            context.SaveChanges();
        }
    }
}
