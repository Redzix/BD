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

        Polacz_z_baza _polacz = new Polacz_z_baza();
        SqlConnection _polaczenie = new SqlConnection();
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
        public WycieczkaView(int opcja,int idWycieczki)
        {
            InitializeComponent();
            _idWycieczki = idWycieczki;

            //Data odjazdu nie moze byc taka sama jak data przyjazdu
            tb_data_odjazdu.Value = tb_data_odjazdu.Value.AddDays(1);
            if (opcja == 0)
            {
                tb_nazwa.Enabled = false;
                tb_data_odjazdu.Enabled = false;
                tb_data_przyjazdu.Enabled = false;
                cb_docelowa.Enabled = false;
                _opcja = 0;
            }
            else
            {
                tb_nazwa.Enabled = true;
                tb_data_odjazdu.Enabled = true;
                tb_data_przyjazdu.Enabled = true;
                cb_docelowa.Enabled = true;
                _opcja = 1;
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

        private void Wycieczka_Load(object sender, EventArgs e)
        {
            _listaMiejsc = (new Miejsce_model()).PobierzMiejsaca();
            _listaPilotow = (new Pilot_model()).pobierzPilotow();
            _listaKierowcow = (new Kierowca_model()).pobierzKierowcow();
            _listaPojazdow = (new Pojazd_model()).PobierzPojazdy();
            
            for (int i = 0; i < _listaMiejsc.Count; i++)
            {
                cb_docelowa.Items.Add(_listaMiejsc[i].Adres + " " + _listaMiejsc[i].Miejscowosc);
                cb_odjazd.Items.Add(_listaMiejsc[i].Adres + " " + _listaMiejsc[i].Miejscowosc);
                cb_pilot.Items.Add(_listaPilotow[i].Imie + " " + _listaPilotow[i].Nazwisko);
                cb_kierowca.Items.Add(_listaKierowcow[i].Imie + " " + _listaKierowcow[i].Nazwisko);
                cb_pojazd.Items.Add(_listaPojazdow[i].NumerRejestracyjny);
            }
        }

        private void b_zapisz_Click(object sender, EventArgs e)
        {
            Wycieczka_model wycieczka = new Wycieczka_model();

            string miejsceWyjazdu;
            string miejsceDocelowe;
            decimal cena;

            _polaczenie = _polacz.PolaczZBaza();
            if (_opcja == 1)
            {
                if (tb_data_przyjazdu.Value > tb_data_odjazdu.Value)
                {
                    MessageBox.Show("Wybrano błędne daty. Data powrotu nie może być późniejsza niż data odjazdu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    wycieczka.IdWycieczki = (new Wycieczka_model()).PobierzWycieczki().Count + 1;
                    wycieczka.Nazwa = tb_nazwa.Text;
                    wycieczka.DataWyjazdu = tb_data_odjazdu.Value; //Obiekt, po Value mozesz wybrać co konkretnie
                    wycieczka.DataPowrotu = tb_data_przyjazdu.Value;
                    wycieczka.Opis = tb_opis.Text;

                    wycieczka.Pilot = cb_pilot.SelectedItem.ToString();
                    wycieczka.Kierowca = cb_kierowca.SelectedItem.ToString();
                    wycieczka.Pojazd = cb_pojazd.SelectedItem.ToString();

                    miejsceWyjazdu = cb_odjazd.SelectedItem.ToString();
                    miejsceDocelowe = cb_docelowa.SelectedItem.ToString();

                    cena = Convert.ToDecimal(tb_cena.Text);


                    if (wycieczka.DodajWycieczke(wycieczka, miejsceWyjazdu, miejsceDocelowe, cena))
                    {
                        MessageBox.Show("Wycieczke dodano pomyślnie.", "Dodano wycieczkę", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                    else
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
                wycieczka.IdWycieczki = _idWycieczki;
                wycieczka.Opis = tb_opis.Text;

                wycieczka.Pilot = cb_pilot.SelectedItem.ToString();
                wycieczka.Kierowca = cb_kierowca.SelectedItem.ToString();
                wycieczka.Pojazd = cb_pojazd.SelectedItem.ToString();

                miejsceWyjazdu = cb_odjazd.SelectedItem.ToString();

                cena = Convert.ToDecimal(tb_cena.Text);


                if (wycieczka.EdytujWycieczke(wycieczka, miejsceWyjazdu, cena))
                {
                    MessageBox.Show("Wycieczke edytowano pomyślnie.", "Edytowano wycieczkę", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
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
        private void tb_data_przyjazdu_ValueChanged(object sender, EventArgs e)
        {
            tb_data_odjazdu.Value = ((DateTimePicker)sender).Value.AddDays(1);
        }
    }
}