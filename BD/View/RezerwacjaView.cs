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
using BD.Controller;

namespace BD.View
{
    public partial class RezerwacjaView : Form
    {
        /// <summary>
        /// Zmienna przechowująca id aktualnie wybranej wycieczki
        /// </summary>
        private int _idWycieczki;

        /// <summary>
        /// Obiekt przechowujący kontroler.
        /// </summary>
        private RezerwacjaController controller;

        /// <summary>
        /// Zmienna przechowująca obiekt aktualnie zalogowanego użytkownika
        /// </summary>
        private Klient _uzytkownik;

        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public RezerwacjaView()
        {
            InitializeComponent();
            this.p_rezerwuj.Visible = false;
            this.p_zaplac.Visible = true;
            b_zapłaćRezerwacje.Enabled = false;
            controller = new RezerwacjaController(this);
        }

        /// <summary>
        /// Konstruktor z parametrem, otrzymuje jako parametr obiekt typu wyieczka, aby potem zapisac go do bazy
        /// </summary>
        /// <param name="wycieczka"></param>
        public RezerwacjaView(int idWycieczki,string uzytkownik)
        {
            _idWycieczki = idWycieczki;
            InitializeComponent();
            this.p_zaplac.Visible = false;
            this.p_rezerwuj.Visible = true;
            b_zapłaćRezerwacje.Enabled = false;
             

            controller = new RezerwacjaController(this);

            _uzytkownik = controller.PobierzDaneKlienta(uzytkownik);
        }

        /// <summary>
        /// Zdarzenie obsługujące wyłączenie okna po wciśnięciu przycisku "Anuluj".
        /// Usuwa utworzone dotąd w ramach swojego działania niezapisane obiekty.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_rezerwacja_anuluj_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Zdarzenie obsługujące wyłączenie okna poprzez wciśnięcie "X", program wraca do głównego panelu danego użytkownika.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void Rezerwacja_FormClosing(object sender, FormClosingEventArgs e)
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
        /// Metoda obsługująca zdarzenie kliknięcia przycisku b_zapisz, odpowiada za wywołanie funkcji 
        /// zapisującej nową rezerwację do bazy i obsługe jej komunikatów
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_rezerwacja_zapisz_Click(object sender, EventArgs e)
        {
            int zapisz = controller.DodajRezerwacje(_idWycieczki,_uzytkownik);

            

            switch (zapisz)
            {
                case -1:
                    MessageBox.Show("Napotkano problem podczas dodawania nowej rezerwacji. Błąd konwersji.Upewnij się, ze wprowadziłeś poprawne dane.", "Dodawanie rezerwacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 0:
                    MessageBox.Show("Napotkano problem podczas dodawania nowej rezerwacji. Błąd z zapisu do bazym danych.",  "Dodawanie rezerwacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    MessageBox.Show("Dodano nową rezerwację o numerze: " + zapisz.ToString() + ".", "Dodawanie rezerwacji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    break;
            }        
        }

        /// <summary>
        /// Zdarzenie obsługujące wyłączenie okna po wciśnięciu przycisku "Anuluj".
        /// Usuwa utworzone dotąd w ramach swojego działania niezapisane obiekty.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_anlujZaplate_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Metoda obsługująca zdarzenie kliknięcia przycisku b_zapłaćRezerwacje, odpowiada za wywołanie funkcji 
        /// zapisującej obliczone informacje do bazy i obsługe jej komunikatów
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_zapłaćRezerwacje_Click(object sender, EventArgs e)
        {
            int zaplac = controller.ZaplacRezerwacje(tb_numerRezerwacji.Text, _uzytkownik.pesel);

            switch(zaplac)
            {
                case 1:
                    MessageBox.Show("Wycieczka została w całości zapłacona.", "Zapłacono", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 0:
                    MessageBox.Show("Podano za wysoką kwotę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -1:
                    decimal zaplacono = decimal.Parse(tb_kwotaDoZaplaty.Text) + decimal.Parse(tb_kwotaZaplacona.Text);
                    decimal doZaplaty = decimal.Parse(tb_kwotaCalkowita.Text) - zaplacono;
                    MessageBox.Show("Zapłacono: " + zaplacono.ToString() + 
                      "\nDo zapłaty pozostało: " + doZaplaty.ToString(),
                     "Do zapłaty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    break;
                case -2:
                    MessageBox.Show("Zmieniono numer rezerwacji. Konieczne jest ponowne oblcizenie.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -3:
                    MessageBox.Show("Podano nieprawidłową kwotę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -4:
                    MessageBox.Show("Podano nieprawidłowy numer rezerwacji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }   
        }

        /// <summary>
        /// Metoda obsługująca zdarzenie kliknięcia przycisku b_zapisz, odpowiada za wywołanie funkcji 
        /// pobierającej i wyswiętlającej informacje o rezerwacji i obsługe jej komunikatów
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void tb_numerRezerwacji_Leave(object sender, EventArgs e)
        {
            int pobierz = controller.PobierzNazweWycieczki(tb_numerRezerwacji.Text,_uzytkownik.pesel);

            switch(pobierz)
            {
                case -1:
                    MessageBox.Show("Podano nieprawidłowy numer rezerwacji. Taka rezerwacja nie istnieje.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    b_zapłaćRezerwacje.Enabled = false;
                    break;
                case 1:
                    b_zapłaćRezerwacje.Enabled = true;
                    break;
                case 0:
                    MessageBox.Show("Podano nieprawidłowy numer rezerwacji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    b_zapłaćRezerwacje.Enabled = false;
                    break;
                default:
                    break;
            }      
        }
    }
}
