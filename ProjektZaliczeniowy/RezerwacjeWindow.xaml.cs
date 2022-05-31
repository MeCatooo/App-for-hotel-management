using AdonisUI;
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
        private Action storedFunction;
        public RezerwacjeWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AdonisUI.ResourceLocator.SetColorScheme(Application.Current.Resources, ResourceLocator.DarkColorScheme);
            //context.Historia_Rezerwacji.Load();
            //System.Windows.Data.CollectionViewSource historia_RezerwacjiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("historia_RezerwacjiViewSource")));
            //historia_RezerwacjiViewSource.Source = context.Historia_Rezerwacji.Local;
            rezerwacja_DoDatePicker.SelectedDate = DateTime.Now;
            rezerwacja_OdDatePicker.SelectedDate = DateTime.Now;
            WsystkieGrid();
            //OstatnieGrid();
            var tmp = context.Typ_Pokoju.ToArray();
            List<string> list = new List<string>();
            foreach (var item in tmp)
            {
                list.Add(item.Opis);
            }
            typ_PokojuComboBox.ItemsSource = list;
            typ_PokojuComboBox.SelectedIndex = 0;
            typ_PokojuComboBox_SelectionChanged(null,null);

        }
        private void OstatnieGrid()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            historia_RezerwacjiDataGrid.ItemsSource = null;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select h.ID_Rezerwacja,g.Imie, g.Nazwisko, (COALESCE (sum(case when o.Data_Wykonania between h.Rezerwacja_oD and h.Rezerwacja_Do then u.cena end),0)+t.cena_doba* (DATEDIFF(day, h.Rezerwacja_oD, h.Rezerwacja_Do)))  as 'cena za calosc', p.Nr_Pokoju as 'Numer Pokoju' from Historia_rezerwacji h inner join Pokoje p on h.Id_pokoju=p.ID_pokoju inner join Goscie g on h.ID_goscia=g.ID_Goscia inner join Typ_Pokoju t on p.Typ_Pokoju=t.ID_typu_pokoju left join Dodatkowe_Oplaty o on h.Id_goscia=o.Id_goscia left join Dodatkowe_Uslugi u on o.ID_Uslugi=u.Id_Uslugi where(h.Rezerwacja_Od between (GETDATE()-7) and GETDATE()) or (h.Rezerwacja_Do between (GETDATE() - 7) and GETDATE()) or (GETDATE() between h.Rezerwacja_Od and Rezerwacja_Do) group by g.Imie, g.Nazwisko, t.cena_doba, h.Rezerwacja_Do , Rezerwacja_Od, p.Nr_Pokoju, h.ID_Rezerwacja";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Pokoje");
                sda.Fill(dt);
                historia_RezerwacjiDataGrid.ItemsSource = dt.DefaultView;
            }
            storedFunction = OstatnieGrid;
        }
        private void WsystkieGrid()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            historia_RezerwacjiDataGrid.ItemsSource = null;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select h.ID_Rezerwacja,g.Imie, g.Nazwisko, (COALESCE (sum(case when o.Data_Wykonania between h.Rezerwacja_oD and h.Rezerwacja_Do then u.cena end),0)+t.cena_doba* (DATEDIFF(day, h.Rezerwacja_oD, h.Rezerwacja_Do)))  as 'cena za calosc', p.Nr_Pokoju as 'Numer Pokoju' from Historia_rezerwacji h inner join Pokoje p on h.Id_pokoju=p.ID_pokoju inner join Goscie g on h.ID_goscia=g.ID_Goscia inner join Typ_Pokoju t on p.Typ_Pokoju=t.ID_typu_pokoju left join Dodatkowe_Oplaty o on h.Id_goscia=o.Id_goscia left join Dodatkowe_Uslugi u on o.ID_Uslugi=u.Id_Uslugi group by h.ID_Rezerwacja, g.Imie, g.Nazwisko, t.cena_doba, h.Rezerwacja_Do , Rezerwacja_Od, p.Nr_Pokoju, h.ID_Rezerwacja";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Pokoje");
                sda.Fill(dt);
                historia_RezerwacjiDataGrid.ItemsSource = dt.DefaultView;
            }
            storedFunction = WsystkieGrid;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try{
                Goscie goscie = new Goscie()
                {
                    Imie = imieTextBox.Text,
                    Nazwisko = nazwiskoTextBox.Text,
                    Pesel = peselTextBox.Text,
                    Nr_Telefonu = nr_TelefonuTextBox.Text
                };
                Goscie found = context.Goscie.Where(element => element.Pesel == goscie.Pesel).FirstOrDefault();
                if (found != null)
                {
                    Historia_Rezerwacji rezerwacja = new Historia_Rezerwacji() { ID_Goscia = found.ID_Goscia, Obslugiwany_przez = int.Parse(obslugiwany_przezTextBox.Text), Rezerwacja_Do = rezerwacja_DoDatePicker.SelectedDate.Value, Rezerwacja_Od = rezerwacja_OdDatePicker.SelectedDate.Value, ID_Pokoju = context.Pokoje.Where(pokoj => pokoj.Nr_Pokoju.ToString() == nr_PokojuComboBox.SelectedValue.ToString()).FirstOrDefault().ID_Pokoju };
                    context.Historia_Rezerwacji.Add(rezerwacja);
                    context.SaveChanges();
                }
                else
                {
                    Goscie based = context.Goscie.Add(goscie);
                    context.SaveChanges();
                    Historia_Rezerwacji rezerwacja = new Historia_Rezerwacji() { ID_Goscia = context.Goscie.Where(element => element.Pesel == based.Pesel).FirstOrDefault().ID_Goscia, Obslugiwany_przez = int.Parse(obslugiwany_przezTextBox.Text), Rezerwacja_Do = rezerwacja_DoDatePicker.SelectedDate.Value, Rezerwacja_Od = rezerwacja_OdDatePicker.SelectedDate.Value, ID_Pokoju = context.Pokoje.Where(pokoj => pokoj.Nr_Pokoju.ToString() == nr_PokojuComboBox.SelectedValue.ToString()).FirstOrDefault().ID_Pokoju };
                    context.Historia_Rezerwacji.Add(rezerwacja);
                    context.SaveChanges();
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                storedFunction.Invoke();
            }
        }

        private void WszystkieButton_Click(object sender, RoutedEventArgs e)
        {
            WsystkieGrid();
        }

        private void OstatnieDniButton_Click(object sender, RoutedEventArgs e)
        {
            OstatnieGrid();
        }

        private void nr_PokojuComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void DeleteButton1_Click(object sender, RoutedEventArgs e)
        {
            DataRowView lista = (DataRowView)historia_RezerwacjiDataGrid.SelectedItem;
            int row = (int)lista.Row.ItemArray[0];
            //var obj = from i in context.Historia_Rezerwacji where i.ID_Rezerwacja == row select i;
            //context.Pracownicy.Remove(obj.FirstOrDefault());
            context.Historia_Rezerwacji.Remove(context.Historia_Rezerwacji.Find(row));
            context.SaveChanges();
            MessageBox.Show("Usunieto");
            storedFunction.Invoke();
        }

        private void typ_PokojuComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //select Nr_Pokoju from Pokoje except select h.ID_Pokoju from Historia_rezerwacji h where (h.Rezerwacja_Od between (GETDATE()-7) and GETDATE()) or (h.Rezerwacja_Do between (GETDATE() - 7) and GETDATE()) or (GETDATE() between h.Rezerwacja_Od and Rezerwacja_Do)
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            historia_RezerwacjiDataGrid.ItemsSource = null;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                //var tmp = from obj in context.Typ_Pokoju where obj.Opis == typ_PokojuComboBox.Text select obj;
                CmdString = $"select Nr_Pokoju from Pokoje p inner join Typ_Pokoju t on p.Typ_Pokoju=t.ID_Typu_Pokoju where Opis like '{typ_PokojuComboBox.Text}' except select h.ID_Pokoju from Historia_rezerwacji h where (h.Rezerwacja_Od between '{rezerwacja_OdDatePicker.SelectedDate.Value.ToString("yyyy/MM/dd").Replace('.', '-')}' and '{rezerwacja_DoDatePicker.SelectedDate.Value.ToString("yyyy/MM/dd").Replace('.','-')}' or (h.Rezerwacja_Do between '{rezerwacja_OdDatePicker.SelectedDate.Value.ToString("yyyy/MM/dd").Replace('.', '-')}' and '{rezerwacja_DoDatePicker.SelectedDate.Value.ToString("yyyy/MM/dd").Replace('.', '-')}') or ('{rezerwacja_DoDatePicker.SelectedDate.Value.ToString("yyyy/MM/dd").Replace('.', '-')}' between h.Rezerwacja_Od and Rezerwacja_Do))";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Pokoje1");
                sda.Fill(dt);
                List<string> list;
                list = (from DataRow row in dt.Rows select row["Nr_Pokoju"].ToString()).ToList();
                nr_PokojuComboBox.ItemsSource = list;
                storedFunction.Invoke();
            }

        }

        //string sel = "select g.Imie, (sum(case when o.Data_Wykonania between h.Rezerwacja_oD and h.Rezerwacja_Do then u.cena end) +t.cena_doba* (DATEDIFF(day, h.Rezerwacja_oD, h.Rezerwacja_Do)))  as 'cena za calosc', p.Nr_Pokoju as 'Numer Pokoju' from Historia_rezerwacji h inner join Pokoje p on h.Id_pokoju=p.ID_pokoju inner join Goscie g on h.ID_goscia=g.ID_Goscia inner join Typ_Pokoju t on p.Typ_Pokoju=t.ID_typu_pokoju inner join Dodatkowe_Oplaty o on h.Id_goscia=o.Id_goscia inner join Dodatkowe_Uslugi u on o.ID_Uslugi=u.Id_Uslugi where(h.Rezerwacja_Od between (GETDATE()-7) and GETDATE()) or (h.Rezerwacja_Do between (GETDATE() - 7) and GETDATE()) or (GETDATE() between h.Rezerwacja_Od and Rezerwacja_Do) group by g.Imie, t.cena_doba, h.Rezerwacja_Do , Rezerwacja_Od, p.Nr_Pokoju, h.ID_Rezerwacja";
    }
}
