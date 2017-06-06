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
    public partial class RezerwacjaView : Form
    {
        private int _idWycieczki;

        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public RezerwacjaView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Konstruktor z parametrem, otrzymuje jako parametr obiekt typu wyieczka, aby potem zapisac go do bazy
        /// </summary>
        /// <param name="wycieczka"></param>
        public RezerwacjaView(int idWycieczki)
        {
            _idWycieczki = idWycieczki;
            InitializeComponent();
        }
        /// <summary>
        /// Zdarzenie obsługujące wyłączenie okna po wciśnięciu przycisku "Anuluj".
        /// Usuwa utworzone dotąd w ramach swojego działania niezapisane obiekty.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_rezerwacja_anuluj_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Zdarzenie obsługujące wyłączenie okna poprzez wciśnięcie "X", program wraca do głównego panelu danego użytkownika.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
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

        private void b_rezerwacja_zapisz_Click(object sender, EventArgs e)
        {
            bazaEntities db = new bazaEntities();

            var cenaRezerwacji = (from katalog in db.Katalog
                                  where katalog.id_wycieczki == _idWycieczki
                                  select katalog.Cennik.cena).FirstOrDefault();

            try
            {
                
                var nowyKlient = new Klient
                {
                    pesel = tb_pesel.Text,
                    imie = tb_imie.Text,
                    nazwisko = tb_nazwisko.Text,
                    ulica = tb_adres.Text,
                    miejscowosc = tb_miejscowosc.Text,
                };

                var czyKlientIstnieje = (from czyIstnieje in db.Klient
                                         where czyIstnieje.pesel.Equals(nowyKlient.pesel)
                                         select czyIstnieje).FirstOrDefault();

                if(czyKlientIstnieje == null)
                {
                    db.Klient.Add(nowyKlient);
                }            

                var nowaRezerwacja = new Rezerwacja
                {
                    liczba_osob = int.Parse(tb_liczba_osob.Text),
                    stan = false,
                    zaliczka = decimal.Parse(tb_zaliczka.Text),
                    id_wycieczki = _idWycieczki,
                    Klient_pesel = nowyKlient.pesel
                };

               var noweUczestnictwo = new Uczestnictwo
                {
                    liczba_osob = nowaRezerwacja.liczba_osob,
                    numer_rezerwacji = nowaRezerwacja.numer_rezerwacji,
                    cena_rezerwacji = cenaRezerwacji * nowaRezerwacja.liczba_osob
               };
                nowaRezerwacja.Klient = nowyKlient;
                noweUczestnictwo.Rezerwacja = nowaRezerwacja;
                db.Rezerwacja.Add(nowaRezerwacja);
                db.Uczestnictwo.Add(noweUczestnictwo);
                db.SaveChanges();

                MessageBox.Show("Dodano nową rezerwację .", "Dodawanie rezerwacji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            catch(Exception exception)
            {
                MessageBox.Show("Napotkano problem podczas dodawania nowej rezerwacji. Błąd:\n" + exception.Message.ToString() , "Dodawanie rezerwacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

         }    
    }
}
