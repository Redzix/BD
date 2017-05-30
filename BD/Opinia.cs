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

namespace BD
{
    public partial class Opinia : Form
    {
        List<Wycieczka_model> _listaWycieczek = new List<Wycieczka_model>();

        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public Opinia()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Zdarzenie obsługujące wyłączenie okna poprzez wciśnięcie "X", program wraca do głównego panelu danego użytkownika.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void Opinia_FormClosing(object sender, FormClosingEventArgs e)
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

        /// <summary>
        /// Zdarzenie obsługujące wyłączenie okna po wciśnięciu przycisku "Anuluj".
        /// Usuwa utworzone dotąd w ramach swojego działania niezapisane obiekty.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_anuluj_Click(object sender, EventArgs e)
        {
            this.Dispose();
            //dodac wycofanie wprowadzonych danych , czyli wyjebanie w kosmos obiektu
        }

        private void Opinia_Load(object sender, EventArgs e)
        {
            _listaWycieczek = (new Wycieczka_model()).PobierzWycieczki();

            for (int i = 0; i < _listaWycieczek.Count; i++)
            {
                cb_nazwa_wycieczki.Items.Add(_listaWycieczek[i].Nazwa.ToString());
            }
            cb_nazwa_wycieczki.SelectedIndex = 0;
        }

        private void b_zapisz_Click(object sender, EventArgs e)
        {
            Polacz_z_baza polacz = new Polacz_z_baza();
            SqlConnection polaczenie = polacz.PolaczZBaza();

            Opinia_model opinia = new Opinia_model();

            opinia.IdOpini = polacz.PobierzDaneInt(polacz.UtworzZapytanie("SELECT MAX(id_opini) FROM Opinia")) + 1;
            opinia.Ocena = cb_ocena.SelectedIndex + 1;
            opinia.Opis = tb_opinia.Text;
            opinia.IdUczestnictwa = polacz.PobierzDaneInt(polacz.UtworzZapytanie("SELECT Uczestnictwo.id_uczestnictwo " +
                "FROM Uczestnictwo " +
                "INNER JOIN Rezerwacja ON Uczestnictwo.numer_rezerwacji = Rezerwacja.numer_rezerwacji " +
                "WHERE Rezerwacja.numer_rezerwacji = " + Convert.ToInt32(tb_numerRezerwacji.Text)));

            if (opinia.DodajOpinie(opinia))
            {
                MessageBox.Show("Opinie dodano poprawnie.", "Potwierdzenie dodania opini",MessageBoxButtons.OK);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Opinia już istnieje", "Błąd opini", MessageBoxButtons.OK);
            }
        }
    }
}
