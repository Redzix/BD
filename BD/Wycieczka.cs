using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD
{
    public partial class Wycieczka : Form
    {
        private List<Miejsce_model> _listaMiejsc = new List<Miejsce_model>();

        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public Wycieczka()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Konstruktor, który tworzy formę wyciećzki dostosowaną do wybranej opcji edycji bądź dodawania wycieczki
        /// </summary>
        /// <param name="opcja">Kiedy jeden dodaje wycieczke, kiedy zero usuwa.</param>
        public Wycieczka(int opcja)
        {
            InitializeComponent();
            if (opcja == 0)
            {
                tb_nazwa.Enabled = false;
                tb_data_odjazdu.Enabled = false;
                tb_data_przyjazdu.Enabled = false;
                cb_docelowa.Enabled = false;
            }
            else
            {
                tb_nazwa.Enabled = true;
                tb_data_odjazdu.Enabled = true;
                tb_data_przyjazdu.Enabled = true;
                cb_docelowa.Enabled = true;
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

            for(int i=0;i < _listaMiejsc.Count; i++)
            {
                cb_docelowa.Items.Add(_listaMiejsc[i].Adres + " " + _listaMiejsc[i].Miejscowosc);
                cb_odjazd.Items.Add(_listaMiejsc[i].Adres + " " + _listaMiejsc[i].Miejscowosc);
            }
        }

        private void b_zapisz_Click(object sender, EventArgs e)
        {
            Wycieczka_model wycieczka = new Wycieczka_model();
            decimal cena = 0;

            wycieczka.Nazwa = tb_nazwa.Text;
            try
            {
                //wycieczka.DataWyjazdu = Convert.ToDateTime(tb_data_odjazdu.ToString());
                DateTime myDate = DateTime.ParseExact(tb_data_odjazdu.ToString(), "yyyy-MM-dd HH:mm:ss,fff",null);

                return;
            }
             catch (FormatException exc)
            {
                MessageBox.Show("Podaj prawidłową datę wyjazdu.", "Błąd", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }



            if (wycieczka.DodajWycieczke(wycieczka,cena))
            {
                MessageBox.Show("Pojazd dodano pomyślnie.", "Dodano pojazd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                if (MessageBox.Show("Napotkano problem podczas doawania pojazdu. Sprawdź poprawność numeru rejestracyjnego", "Błąd dodawania pojazdu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
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
}
