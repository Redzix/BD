using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BD.Controller;

namespace BD.View
{
    public partial class PojazdView : Form
    {
        /// <summary>
        /// Obiekt przechowujący kontroler.
        /// </summary>
        private PojazdController controller; 

        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public PojazdView()
        {
            InitializeComponent();
            controller = new PojazdController(this);
        }

        /// <summary>
        /// Metoda obsługująca zdarzenie wyłączenia okna po wciśnięciu przycisku "Anuluj".
        /// Usuwa utworzone dotąd w ramach swojego działania niezapisane obiekty.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_anuluj_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Metoda obsługująca zdarzenie wyłączenia okna poprzez wciśnięcie "X", program wraca do głównego panelu danego użytkownika.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
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

        /// <summary>
        /// Metoda obsługująca kliknięcie przycisku b_zapisz, odpowiada za wywołanie funkcji
        /// dodającej pojazd do bazy i obsługe jej komunikatów.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_zapisz_Click(object sender, EventArgs e)
        {
            int zapisz = controller.DodajPojazd();

            switch (zapisz)
            {
                case 1:
                    MessageBox.Show("Pojazd dodano pomyślnie", "Dodanie pojazdu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    break;
                case 0:
                    MessageBox.Show("Bład podczas dodawania pojazdu. Sprwdź, czy wporwadzono poprawną pojemność", "Błąd dodawania pojazdu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -1:
                    MessageBox.Show("Bład podczas dodawania pojazdu. Problem z zapisem do bazy.", "Błąd dodawania pojazdu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -2:
                    MessageBox.Show("Bład podczas dodawania pojazdu. Pojazd o podanym numerze rejestracyjnym już istenieje.", "Błąd dodawania pojazdu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }          
        }
    }
}
