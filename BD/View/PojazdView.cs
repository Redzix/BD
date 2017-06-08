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
                DialogResult czyZakonczyc = MessageBox.Show("Czy na pewno chcesz wyjść?", "Zamknij", MessageBoxButtons.YesNo,
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
                int pojemnosc = int.Parse(tb_pojemnosc.Text);

                var pojazd = new Pojazd
                {
                    numer_rejestracyjny = tb_numer_rejestracyjny.Text,
                    dostepny = true,
                    marka = tb_marka.Text,
                    stan = true,
                    pojemnosc = pojemnosc
                };

                db.Pojazd.Add(pojazd);
                db.SaveChanges();
                this.Dispose();
            }catch(FormatException exception)
            {
                MessageBox.Show("Bład podczas dodawania pojazdu. Sprwdź, czy wporwadzono poprawną pojemność","Błąd dodawania pojazdu",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }catch (Exception exception)
            {
                MessageBox.Show("Bład podczas dodawania pojazdu. Możliwy problem z połączeniem.", "Błąd dodawania pojazdu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
    }
}
