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
    public partial class WycieczkaView : Form
    {
        private List<Miejsce_model> _listaMiejsc = new List<Miejsce_model>();
        private List<Pilot_model> _listaPilotow = new List<Pilot_model>();
        private List<Kierowca_model> _listaKierowcow = new List<Kierowca_model>();
        private List<Pojazd_model> _listaPojazdow = new List<Pojazd_model>();
        private int _idWycieczki;

        private int _opcja = 1;
        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public WycieczkaView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Konstruktor, który tworzy formę wyciećzki dostosowaną do wybranej opcji edycji bądź dodawania wycieczki
        /// </summary>
        /// <param name="opcja">Kiedy jeden dodaje wycieczke, kiedy zero usuwa.</param>
        public WycieczkaView(int opcja, int idWycieczki)
        {
            InitializeComponent();
            this.Wycieczka_Load();
            //Data odjazdu nie moze byc taka sama jak data przyjazdu
            tb_data_wyjazdu.Value = DateTime.Now;
            tb_data_powrotu.Value = tb_data_powrotu.Value.AddDays(1);
            if (opcja == 0)
            {
                tb_nazwa.Enabled = false;
                tb_data_powrotu.Enabled = false;
                tb_data_wyjazdu.Enabled = false;
                cb_docelowa.Enabled = false;
                _opcja = 0;
                this.wypelnijDoEdycji(idWycieczki);
            }
            else
            {
                tb_nazwa.Enabled = true;
                tb_data_powrotu.Enabled = true;
                tb_data_wyjazdu.Enabled = true;
                cb_docelowa.Enabled = true;
                _opcja = 1;
            }
        }

        private void wypelnijDoEdycji(int id)
        {
            bazaEntities db = new bazaEntities();
            var query = (from katalog in db.Katalog
                        where katalog.id_wycieczki == id
                        select new
                        {
                            katalog,
                            wycieczka = katalog.Wycieczka,
                            cennik = katalog.Cennik,
                            miejsce_z = katalog.Miejsce,
                            miejsce_do = katalog.Miejsce1
                        }).FirstOrDefault();
            Console.WriteLine(query.katalog.id_miejsca_odjazdu + " " + query.katalog.id_miejsca_przyjazdu);
            var docelowa = (from x in this.cb_odjazd.Items.OfType<KeyValuePair<string, string>>()
                               where x.Key.Equals(query.katalog.id_miejsca_odjazdu.ToString())
                               select x).FirstOrDefault();
            var odjazd = (from x in this.cb_docelowa.Items.OfType<KeyValuePair<string, string>>()
                          where x.Key.Equals(query.katalog.id_miejsca_przyjazdu.ToString())
                          select x).FirstOrDefault();
            var kierowca = (from x in this.cb_kierowca.Items.OfType<KeyValuePair<string, string>>()
                            where x.Key.Equals(query.wycieczka.Kierowca_pesel)
                            select x).FirstOrDefault();
            var pilot = (from x in this.cb_pilot.Items.OfType<KeyValuePair<string, string>>()
                            where x.Key.Equals(query.wycieczka.Pilot_pesel)
                            select x).FirstOrDefault();
            var pojazd = (from x in this.cb_pojazd.Items.OfType<KeyValuePair<string, string>>()
                            where x.Key.Equals(query.wycieczka.Pojazd_numer_rejestracyjny)
                            select x).FirstOrDefault();
            try
            {
                cb_odjazd.SelectedItem = odjazd;
                cb_docelowa.SelectedItem = docelowa;
                cb_kierowca.SelectedItem = kierowca;
                cb_pilot.SelectedItem = pilot;
                cb_pojazd.SelectedItem = pojazd;
                tb_data_powrotu.Value = (DateTime)query.wycieczka.data_powrotu.Value;
                tb_data_wyjazdu.Value = (DateTime)query.wycieczka.data_wyjazdu.Value;
                tb_nazwa.Text = query.wycieczka.nazwa;
                tb_opis.Text = query.wycieczka.opis;
                tb_cena.Text = query.cennik.cena.Value.ToString();
            } catch
            {
                Console.WriteLine("error");
            }
        }

        private void b_anuluj_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Zdarzenie obsługujące wyłączenie okna poprzez wciśnięcie "X", program wraca do głównego panelu danego użytkownika.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void Wycieczka_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Wycieczka_Load()
        {
            bazaEntities db = new bazaEntities();
            var miejscowosci = from m in db.Miejsce orderby m.miejscowosc select m;
            var piloci = from m in db.Pilot orderby m.nazwisko select m;
            var kierowcy = from m in db.Kierowca orderby m.nazwisko select m;
            var pojazdy = from m in db.Pojazd orderby m.pojemnosc where m.stan == true select m;
            Dictionary<string, string> values = new Dictionary<string, string>();
            foreach (var row in miejscowosci)
            {
                values.Add(row.id_miejsca.ToString(), row.miejscowosc + ", " + row.adres);
            }
            cb_docelowa.DataSource = new BindingSource(values, null);
            cb_docelowa.DisplayMember = "Value";
            cb_docelowa.ValueMember = "Key";

            cb_odjazd.DataSource = new BindingSource(values, null);
            cb_odjazd.DisplayMember = "Value";
            cb_odjazd.ValueMember = "Key";

            values.Clear();
            foreach (var row in piloci)
            {
                values.Add(row.pesel, row.nazwisko + " " + row.imie);
            }

            cb_pilot.DataSource = new BindingSource(values, null);
            cb_pilot.DisplayMember = "Value";
            cb_pilot.ValueMember = "Key";
            values.Clear();

            foreach (var row in kierowcy)
            {
                values.Add(row.pesel, row.nazwisko + " " + row.imie);
            }

            cb_kierowca.DataSource = new BindingSource(values, null);
            cb_kierowca.DisplayMember = "Value";
            cb_kierowca.ValueMember = "Key";
            values.Clear();

            foreach (var row in pojazdy)
            {
                values.Add(row.numer_rejestracyjny, row.numer_rejestracyjny + " [poj: " + row.pojemnosc + "]");
            }

            cb_pojazd.DataSource = new BindingSource(values, null);
            cb_pojazd.DisplayMember = "Value";
            cb_pojazd.ValueMember = "Key";
            values.Clear();

            //Do odczytu primary key trzeba użyć czegoś takiego:
            //string value = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Value;
        }

        private void b_zapisz_Click(object sender, EventArgs e)
        {
            if (_opcja == 1)
            {
                if (tb_data_wyjazdu.Value > tb_data_powrotu.Value)
                {
                    MessageBox.Show("Wybrano błędne daty. Data powrotu nie może być późniejsza niż data odjazdu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    try
                    {
                        bazaEntities db = new bazaEntities();
                        string pilotPesel = ((KeyValuePair<string, string>)cb_pilot.SelectedItem).Key;
                        string kierowcaPesel = ((KeyValuePair<string, string>)cb_kierowca.SelectedItem).Key;
                        string pojazdRejestracja = ((KeyValuePair<string, string>)cb_pojazd.SelectedItem).Key;
                        int miejsceOdjazdu = int.Parse(((KeyValuePair<string, string>)cb_odjazd.SelectedItem).Key);
                        int miejscePrzyjazdu = int.Parse(((KeyValuePair<string, string>)cb_docelowa.SelectedItem).Key);
                        var nowaWycieczka = new Wycieczka
                        {
                            nazwa = tb_nazwa.Text,
                            data_powrotu = tb_data_powrotu.Value,
                            data_wyjazdu = tb_data_wyjazdu.Value,
                            opis = tb_opis.Text,
                            Pilot_pesel = pilotPesel,
                            Kierowca_pesel = kierowcaPesel,
                            Pojazd_numer_rejestracyjny = pojazdRejestracja,
                        };
                        var nowyCennik = new Cennik
                        {
                            cena = decimal.Parse(tb_cena.Text),
                            okres_od = tb_data_powrotu.Value,
                            okres_do = tb_data_wyjazdu.Value

                        };
                        var nowyKatalog = new Katalog
                        {
                            id_miejsca_odjazdu = miejsceOdjazdu,
                            id_miejsca_przyjazdu = miejscePrzyjazdu,
                        };
                        nowyKatalog.Cennik = nowyCennik;
                        nowyKatalog.Wycieczka = nowaWycieczka;
                        db.Katalog.Add(nowyKatalog);
                        db.Wycieczka.Add(nowaWycieczka);
                        db.Cennik.Add(nowyCennik);
                        db.SaveChanges();
                        MessageBox.Show("Wycieczka została dodana pomyślnie.", "Dodano wycieczkę", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                    catch
                    {
                        if (MessageBox.Show("Napotkano problem podczas dodawania wycieczki.", "Błąd dodawania wycieczki", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                        {
                            this.Dispose();
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            else
            {
                bazaEntities db = new bazaEntities();
                try
                {
                    string pilotPesel = ((KeyValuePair<string, string>)cb_pilot.SelectedItem).Key;
                    string kierowcaPesel = ((KeyValuePair<string, string>)cb_kierowca.SelectedItem).Key;
                    string pojazdRejestracja = ((KeyValuePair<string, string>)cb_pojazd.SelectedItem).Key;
                    int miejsceOdjazdu = int.Parse(((KeyValuePair<string, string>)cb_odjazd.SelectedItem).Key);
                    int miejscePrzyjazdu = int.Parse(((KeyValuePair<string, string>)cb_docelowa.SelectedItem).Key);

                    var edit = db.Katalog.Find(_idWycieczki);

                    edit.Wycieczka.Pilot_pesel = pilotPesel;
                    edit.Wycieczka.Kierowca_pesel = kierowcaPesel;
                    edit.Wycieczka.Pojazd_numer_rejestracyjny = pojazdRejestracja;

                    edit.id_miejsca_odjazdu = miejsceOdjazdu;
                    edit.id_miejsca_przyjazdu = miejscePrzyjazdu;
                    edit.Cennik.cena = decimal.Parse(tb_cena.Text);

                    edit.Wycieczka.opis = tb_opis.Text;
                    var liczba = db.SaveChanges();
                    if (liczba>0)
                    {
                        MessageBox.Show("Wycieczke edytowano pomyślnie.", "Edytowano wycieczkę", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                }
                catch
                {
                    if (MessageBox.Show("Napotkano problem podczas edycji wycieczki.", "Błąd edycji wycieczki", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        this.Dispose();
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        //Za każdym razem jeśli zmieni się data w polu odjazdu, data w polu odjazdu zinkrementuje się o jeden
        private void tb_data_wyjazdu_ValueChanged(object sender, EventArgs e)
        {
            if (_opcja != 0)
                tb_data_powrotu.Value = ((DateTimePicker)sender).Value.AddDays(1);
        }
    }
}