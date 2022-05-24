using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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
    public partial class RezerwacjeWindow : Window
    {
        HotelEntities context = new HotelEntities();
        public RezerwacjeWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //context.Historia_Rezerwacji.Load();
            //System.Windows.Data.CollectionViewSource historia_RezerwacjiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("historia_RezerwacjiViewSource")));
            //historia_RezerwacjiViewSource.Source = context.Historia_Rezerwacji.Local;
            WsystkieGrid();
            //OstatnieGrid();
            
        }
        private void OstatnieGrid()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            historia_RezerwacjiDataGrid.ItemsSource = null;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select g.Imie, g.Nazwisko, (COALESCE (sum(case when o.Data_Wykonania between h.Rezerwacja_oD and h.Rezerwacja_Do then u.cena end),0)+t.cena_doba* (DATEDIFF(day, h.Rezerwacja_oD, h.Rezerwacja_Do)))  as 'cena za calosc', p.Nr_Pokoju as 'Numer Pokoju' from Historia_rezerwacji h inner join Pokoje p on h.Id_pokoju=p.ID_pokoju inner join Goscie g on h.ID_goscia=g.ID_Goscia inner join Typ_Pokoju t on p.Typ_Pokoju=t.ID_typu_pokoju inner join Dodatkowe_Oplaty o on h.Id_goscia=o.Id_goscia inner join Dodatkowe_Uslugi u on o.ID_Uslugi=u.Id_Uslugi where(h.Rezerwacja_Od between (GETDATE()-7) and GETDATE()) or (h.Rezerwacja_Do between (GETDATE() - 7) and GETDATE()) or (GETDATE() between h.Rezerwacja_Od and Rezerwacja_Do) group by g.Imie, g.Nazwisko, t.cena_doba, h.Rezerwacja_Do , Rezerwacja_Od, p.Nr_Pokoju, h.ID_Rezerwacja";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Pokoje");
                sda.Fill(dt);
                historia_RezerwacjiDataGrid.ItemsSource = dt.DefaultView;
            }
        }
        private void WsystkieGrid()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            historia_RezerwacjiDataGrid.ItemsSource = null;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select g.Imie, g.Nazwisko, (COALESCE (sum(case when o.Data_Wykonania between h.Rezerwacja_oD and h.Rezerwacja_Do then u.cena end),0)+t.cena_doba* (DATEDIFF(day, h.Rezerwacja_oD, h.Rezerwacja_Do)))  as 'cena za calosc', p.Nr_Pokoju as 'Numer Pokoju' from Historia_rezerwacji h inner join Pokoje p on h.Id_pokoju=p.ID_pokoju inner join Goscie g on h.ID_goscia=g.ID_Goscia inner join Typ_Pokoju t on p.Typ_Pokoju=t.ID_typu_pokoju inner join Dodatkowe_Oplaty o on h.Id_goscia=o.Id_goscia inner join Dodatkowe_Uslugi u on o.ID_Uslugi=u.Id_Uslugi group by g.Imie, g.Nazwisko, t.cena_doba, h.Rezerwacja_Do , Rezerwacja_Od, p.Nr_Pokoju, h.ID_Rezerwacja";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Pokoje");
                sda.Fill(dt);
                historia_RezerwacjiDataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void WszystkieButton_Click(object sender, RoutedEventArgs e)
        {
            WsystkieGrid();
        }

        private void OstatnieDniButton_Click(object sender, RoutedEventArgs e)
        {
            OstatnieGrid();
        }

        //string sel = "select g.Imie, (sum(case when o.Data_Wykonania between h.Rezerwacja_oD and h.Rezerwacja_Do then u.cena end) +t.cena_doba* (DATEDIFF(day, h.Rezerwacja_oD, h.Rezerwacja_Do)))  as 'cena za calosc', p.Nr_Pokoju as 'Numer Pokoju' from Historia_rezerwacji h inner join Pokoje p on h.Id_pokoju=p.ID_pokoju inner join Goscie g on h.ID_goscia=g.ID_Goscia inner join Typ_Pokoju t on p.Typ_Pokoju=t.ID_typu_pokoju inner join Dodatkowe_Oplaty o on h.Id_goscia=o.Id_goscia inner join Dodatkowe_Uslugi u on o.ID_Uslugi=u.Id_Uslugi where(h.Rezerwacja_Od between (GETDATE()-7) and GETDATE()) or (h.Rezerwacja_Do between (GETDATE() - 7) and GETDATE()) or (GETDATE() between h.Rezerwacja_Od and Rezerwacja_Do) group by g.Imie, t.cena_doba, h.Rezerwacja_Do , Rezerwacja_Od, p.Nr_Pokoju, h.ID_Rezerwacja";
    }
}
