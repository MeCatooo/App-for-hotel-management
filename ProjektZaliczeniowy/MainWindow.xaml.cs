using System;
using System.Data.Entity;
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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProjektZaliczeniowy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HotelEntities context = new HotelEntities();
        //CollectionViewSource collectionRezerwacje;
        //CollectionViewSource collectionPokoje;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WszystkiePokojeGrid();
            StatusBox.Content = "Wszystkie pokoje";
            //context.Historia_Rezerwacji.Load();
            //collectionRezerwacje.Source = context.Historia_Rezerwacji.Local;
            //System.Windows.Data.CollectionViewSource typ_PokojuViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("typ_PokojuViewSource")));
        }
        private void WolnePokojeGrid()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            grdEmployee.ItemsSource = null;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select Nr_Pokoju from Pokoje except select p.Nr_Pokoju from Historia_Rezerwacji h right join Pokoje p on h.Id_Pokoju=p.Id_Pokoju where Rezerwacja_Do>GETDATE() ;";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Pokoje");
                sda.Fill(dt);
                grdEmployee.ItemsSource = dt.DefaultView;
            }
        }
        private void ZajetePokojeGrid()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select p.Nr_Pokoju, t.Opis from Historia_Rezerwacji h inner join Pokoje p on h.ID_Pokoju = p.ID_Pokoju inner join Typ_Pokoju t on p.Typ_Pokoju=t.ID_Typu_Pokoju where h.Rezerwacja_Od<GETDATE() and h.Rezerwacja_Do >GETDATE()";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Pokoje");
                sda.Fill(dt);
                grdEmployee.ItemsSource = dt.DefaultView;
            }
        }
        private void WszystkiePokojeGrid()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            grdEmployee.ItemsSource = null;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select Nr_Pokoju, t.Opis from Pokoje inner join Typ_Pokoju t on Typ_Pokoju=t.ID_Typu_Pokoju";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Pokoje");
                sda.Fill(dt);
                grdEmployee.ItemsSource = dt.DefaultView;
            }
        }
        private void ZajeteButton_Click(object sender, RoutedEventArgs e)
        {
            ZajetePokojeGrid();
            StatusBox.Content = "Zajęte pokoje";
        }

        private void WolneButton_Click(object sender, RoutedEventArgs e)
        {
            WolnePokojeGrid();
            StatusBox.Content = "Wolne pokoje";
        }
        private void WszystkieButton_Click(object sender, RoutedEventArgs e)
        {
            WszystkiePokojeGrid();
            StatusBox.Content = "Wszystkie pokoje";
        }

        private void PracownicyButton_Click(object sender, RoutedEventArgs e)
        {
            PracownicyWindow pracownicyWindow = new PracownicyWindow();
            pracownicyWindow.ShowDialog();
        }

        private void RezerwacjeButton_Click(object sender, RoutedEventArgs e)
        {
            RezerwacjeWindow rezerwacjeWindow = new RezerwacjeWindow();
            rezerwacjeWindow.ShowDialog();
        }

    }
}
