using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BD.View
{
    public partial class ReklamacjaView : Form
    {
        List<Wycieczka_model>  _listaWycieczek= new List<Wycieczka_model>();
        List<Reklamacja_model> _listaReklamacji = new List<Reklamacja_model>();
        Polacz_z_baza _polacz = new Polacz_z_baza();
        SqlConnection _polaczenie = new SqlConnection();

        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public ReklamacjaView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Zdarzenie obsługujące wyłączenie okna po wciśnięciu przycisku "Anuluj".
        /// Usuwa utworzone dotąd w ramach swojego działania niezapisane obiekty.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_anuluj_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Zdarzenie obsługujące wyłączenie okna poprzez wciśnięcie "X", program wraca do głównego panelu danego użytkownika.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void Reklamacja_FormClosing(object sender, FormClosingEventArgs e)
        {
            //najpierw sprawdza, czy user kliknał "X" czy po prostu kliknał sobie jakis przycisk wyłączający okno typu "anuluj"
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult czyZakonczyc = MessageBox.Show("Czy na pewno chcesz zamknąć to okno?", "Zamknięcie okna", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (czyZakonczyc == DialogResult.Yes)
                {
                    this.Dispose();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void b_zapisz_Click(object sender, EventArgs e)
        {
            bazaEntities db = new bazaEntities();

            try
            { 
                int numer = int.Parse(tb_numerRezerwacji.Text);
                var uczestnictwo = (from uc in db.Uczestnictwo
                                    where uc.numer_rezerwacji == numer
                                    select uc).FirstOrDefault();

                var reklamacja = new Reklamacja
                {
                    opis = tb_opis_reklamacji.Text,
                    stan = false,
                    Kierownik_pesel = "brak",
                    id_uczestnictwo = uczestnictwo.id_uczestnictwo
                };
                db.Reklamacja.Add(reklamacja);

                db.SaveChanges();
                MessageBox.Show("Prawidłowo dodano reklamację.", "Dodano reklamację.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_nazwaWycieczki.Text = "";
                tb_opis_reklamacji.Text = "";
                tb_numerRezerwacji.Text = "";
            }
            catch (FormatException exception)
            {
                MessageBox.Show("wprowadzono nieprawidłowy numer rezerwacji. Błąd:\n" + exception.Message, "Błąd podczas dodawania reklamacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił problem podczas dodawania reklamacji. Błąd:\n" + exception.Message, "Błąd podczas dodawania reklamacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }             
        }

        private void tc_reklamacje_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tc_reklamacje.SelectedIndex == 1)
            {
                bazaEntities db = new bazaEntities();

                var pobierz = from reklamacja in db.Reklamacja
                              orderby reklamacja.numer_reklamacji
                              select reklamacja.numer_reklamacji;

                if (pobierz == null)
                {
                    MessageBox.Show("Wystąpił bład podczas pobierania danych.","Błąd pobierania danych",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    lv_reklamacje.Items.Add("Brak reklamacji");
                }else
                {
                    foreach (var rek in pobierz)
                    {
                        ListViewItem reklamacja = new ListViewItem(rek.ToString());
                        reklamacja.Tag = rek.ToString();
                        lv_reklamacje.Items.Add(reklamacja);
                    }
                }
            }
        }

        private void lv_reklamacje_ItemActivate(object sender, EventArgs e)
        {
            int numer = int.Parse(((ListView)sender).SelectedItems[0].Tag.ToString());

            bazaEntities db = new bazaEntities();

            var query = (from reklamacja in db.Reklamacja
                         where reklamacja.numer_reklamacji == numer
                         select new
                         {
                             numer = reklamacja.numer_reklamacji,
                             nazwa = reklamacja.Uczestnictwo.Rezerwacja.Wycieczka.nazwa,
                             stan = reklamacja.stan,
                             dataOdjazdu = reklamacja.Uczestnictwo.Rezerwacja.Wycieczka.data_wyjazdu,
                             dataPowrotu = reklamacja.Uczestnictwo.Rezerwacja.Wycieczka.data_powrotu,
                             opis = reklamacja.opis
                         }).FirstOrDefault();

            // Dodanie wartości parametrów do opisu znajdującego się w texboxie
            rtb_reklamacja.Text =
                "Numer reklamacji: " + query.numer +
                "\nStan: " + ((bool.Parse(query.stan.ToString())) ? "Rozpatrzona" : "Nierpozatrzona") +
                "\nNazwa wycieczki: " + query.nazwa +
                "\nData wycieczki: " + query.dataOdjazdu + "--" + query.dataPowrotu +
                "\nOpis: " + query.opis;

        }

        private void b_sprawdzPoprawnosc_Click(object sender, EventArgs e)
        {         
            bazaEntities db = new bazaEntities();

            try
            {
                int numer = int.Parse(tb_numerRezerwacji.Text);

                var query = (from uczestnictwo in db.Uczestnictwo
                             where uczestnictwo.numer_rezerwacji == numer
                             select uczestnictwo.Rezerwacja.Wycieczka.nazwa).FirstOrDefault();

                if (query == null)
                {
                    tb_nazwaWycieczki.Text = "Błędna rezerwacja";
                    this.b_zapisz.Enabled = false;
                }
                else
                {
                    tb_nazwaWycieczki.Text = query;
                    this.b_zapisz.Enabled = true;
                }
            }
            catch(FormatException exception)
            {
                MessageBox.Show("Wprowadź prawidłowy numer rezerwacji.","Błąd podczas pobierania danych",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
