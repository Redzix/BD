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
    public partial class RezygnacjaView : Form
    {

        /// <summary>
        /// Obiekt przechowujący kontroler.
        /// </summary>
        private RezygnacjaController controller;

        /// <summary>
        /// Zmienna przechowująca pesel aktualnie zalogowanego użytkownika
        /// </summary>
        private string _uzytkownik;

        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public RezygnacjaView()
        {
            InitializeComponent();
            tb_cenaPoRezygnacji.Enabled = false;
            tb_liczbaOsob.Enabled = false;
            tb_nazwaWycieczki.Enabled = false;
            controller = new RezygnacjaController(this);
        }

        /// <summary>
        /// Dodaje rezygnację dla zdefiniowanego wcześniej użytkownika
        /// </summary>
        /// <param name="uzytkownik">Aktualny użytkownik</param>
        public RezygnacjaView(string uzytkownik)
        {
            InitializeComponent();
            tb_cenaPoRezygnacji.Enabled = false;
            tb_liczbaOsob.Enabled = false;
            tb_nazwaWycieczki.Enabled = false;
            _uzytkownik = uzytkownik;
            controller = new RezygnacjaController(this);
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
        private void Rezygnacja_FormClosing(object sender, FormClosingEventArgs e)
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
        /// Metoda obsługująca zdarzenie kliknięcia przycisku b_oblicz, odpowiada za wywołanie funkcji 
        /// sprawdzającej poprawnoość numeru rezerwacji oraz obliczajacej sugerowane koszty i obsługuje jej komunikat
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_oblicz_Click(object sender, EventArgs e)
         {
            int oblicz = controller.Oblicz(tb_numerRezerwacji.Text,_uzytkownik);

            switch (oblicz)
            {
                case -3:
                    MessageBox.Show("Rezerwacja nie isnieje.", "Błąd podczas pobierania danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -2:
                    MessageBox.Show("Wprowadź prawidłowy numer rezerwacji oraz liczbę rezygnujących osób..", "Błąd podczas pobierania danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -1:
                    if (MessageBox.Show("Rezerwacja zostanie usunięta, czy na pewno chcesz to zrobić?", "Usuwanie rezerwacji", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.b_zapisz.Enabled = true;
                    }
                    else
                    {
                        this.b_zapisz.Enabled = false;
                    }
                    break;
                case 0:
                    MessageBox.Show("Podano zbyt dużą ilość rezygnujących osób.", "Bład wprowadzaznia danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.b_zapisz.Enabled = false;
                    break;
                case 1:
                    this.b_zapisz.Enabled = true;
                    break;
                default:
                    break;
            }          
        }

        /// <summary>
        /// Metoda obsługująca zdarzenie kliknięcia przycisku b_zapisz, odpowiada za wywołanie funkcji 
        /// zapisującej obliczone informacje do bazy i obsługe jej komunikatów
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_zapisz_Click(object sender, EventArgs e)
        {
            int zapisz = controller.Zapisz(tb_numerRezerwacji.Text, _uzytkownik);

            switch (zapisz)
            {
                case 1:
                    MessageBox.Show("Zmiany wprowadzono poprawnie", "Zmieniono rezerwację.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    break;
                case -1:
                    MessageBox.Show("Wystąpił błąd podczas wprowadzania zmian. Problem z połączeniem." , "Błąd podczas zmiany rezerwacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 0:
                    MessageBox.Show("Wprowadź prawidłowy numer rezerwacji.", "Błąd podczas pobierania danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }           
        }

        /// <summary>
        /// Metoda zabezpieczająca przed wprowadzeniem znaków innych niż cyfry do tb_numerRezerwacji
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void tb_numerRezerwacji_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Metoda zabezpieczająca przed wprowadzeniem znaków innych niż cyfry do tb_liczbaRezygnujacychOsob
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void tb_liczbaRezygnujacychOsob_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
