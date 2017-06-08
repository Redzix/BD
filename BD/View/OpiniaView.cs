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
    public partial class OpiniaView : Form
    {
        List<Wycieczka_model> _listaWycieczek = new List<Wycieczka_model>();

        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public OpiniaView()
        {
            InitializeComponent();
            cb_ocena.SelectedIndex = 0;
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


        private void b_zapisz_Click(object sender, EventArgs e)
        {
            bazaEntities db = new bazaEntities();

            try
            {
                int numer = int.Parse(tb_numerRezerwacji.Text);

                var query = (from uczestnictwo in db.Uczestnictwo
                             where uczestnictwo.numer_rezerwacji == numer
                             select uczestnictwo.id_uczestnictwo).FirstOrDefault();

                var opinia = new Opinia
                {
                    opis = tb_opinia.Text,
                    ocena = cb_ocena.SelectedIndex + 1,
                    id_uczestnictwo = query
                };
                db.Opinia.Add(opinia);

                db.SaveChanges();
                MessageBox.Show("Opinia została dodana prawidłowo.", "Dodano opinię", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Wystąpił problem podczas dodawania opinii. Błąd:\n" + exception.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił problem podczas dodawania opinii. Błąd:\n" + exception.Message,"Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tb_numerRezerwacji_Leave(object sender, EventArgs e)
        {

            bazaEntities db = new bazaEntities();

            try
            {
                int numer = int.Parse(tb_numerRezerwacji.Text);
                var query = (from uczestnictwo in db.Uczestnictwo
                             where uczestnictwo.numer_rezerwacji == numer
                             select uczestnictwo.Rezerwacja.Wycieczka.nazwa).FirstOrDefault();

                if(query == null)
                {
                    MessageBox.Show("Podaj poprawny numer rezerwacji. Taka rezerwacja nie isntnieje.", "Błeny numer rezerwacji.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_nazwaWycieczki.Text = "Brak rezerwacji";
                    this.b_zapisz.Enabled = false;
                }
                else
                {
                    tb_nazwaWycieczki.Text = query;
                    this.b_zapisz.Enabled = true;
                }
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Podaj poprawny numer rezerwacji.","Błeny numer rezerwacji.",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
