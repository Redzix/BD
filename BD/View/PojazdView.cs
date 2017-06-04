using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD.View
{
    public partial class PojazdView : Form
    {
        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public PojazdView()
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
        private void Pojazd_FormClosing(object sender, FormClosingEventArgs e)
        {
            //najpierw sprawdza, czy user kliknał "X" czy po prostu kliknał sobie jakis przycisk wyłączający okno typu "anuluj"
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult czyZakonczyc = MessageBox.Show("Czy na pewno chcesz się wylogować?", "Wyloguj", MessageBoxButtons.YesNo,
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
            Pojazd_model pojazd = new Pojazd_model();

            pojazd.NumerRejestracyjny = tb_numer_rejestracyjny.Text;
            pojazd.Dostepnosc = 1;
            pojazd.Marka = tb_marka.Text;
            pojazd.Stan = 1;
            pojazd.Pojemnosc = Convert.ToInt32(tb_pojemnosc.Text);

            if (pojazd.DodajPojazd(pojazd))
            {
                MessageBox.Show("Pojazd dodano pomyślnie.", "Dodano pojazd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                if(MessageBox.Show("Napotkano problem podczas doawania pojazdu. Sprawdź poprawność numeru rejestracyjnego", "Błąd dodawania pojazdu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
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
