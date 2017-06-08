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
            this.p_rezerwuj.Visible = false;
            this.p_zaplac.Visible = true;
        }

        /// <summary>
        /// Konstruktor z parametrem, otrzymuje jako parametr obiekt typu wyieczka, aby potem zapisac go do bazy
        /// </summary>
        /// <param name="wycieczka"></param>
        public RezerwacjaView(int idWycieczki)
        {
            _idWycieczki = idWycieczki;
            InitializeComponent();
            this.p_zaplac.Visible = false;
            this.p_rezerwuj.Visible = true;
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

        private void b_anlujZaplate_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void b_zapłaćRezerwacje_Click(object sender, EventArgs e)
        {
            bazaEntities db = new bazaEntities();
            Rezerwacja rez = new Rezerwacja();
            Uczestnictwo uczest = new Uczestnictwo();

            try
            {
                int numer = int.Parse(tb_numerRezerwacji.Text);
                rez = (from rezerwacja in db.Rezerwacja
                           where rezerwacja.numer_rezerwacji == numer
                           select rezerwacja).FirstOrDefault();

                uczest = (from uczestnictwo in db.Uczestnictwo
                              where uczestnictwo.numer_rezerwacji == numer
                              select uczestnictwo).FirstOrDefault();

                tb_nazwaWycieczkiZaplac.Text = rez.Wycieczka.nazwa;
                tb_kwotaCalkowita.Text = (uczest.cena_rezerwacji).ToString();
                tb_kwotaDoZaplaty.Text = (uczest.cena_rezerwacji - rez.zaliczka).ToString();

                try
                {
                    decimal kwota = decimal.Parse(tb_kwotaZaplacona.Text);
                    if ((kwota + rez.zaliczka) == uczest.cena_rezerwacji)
                    {
                        rez.zaliczka += kwota;
                        rez.stan = true;
                        MessageBox.Show("Wycieczka została w całości zapłacona.", "Zapłacono", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else if((kwota + rez.zaliczka) > uczest.cena_rezerwacji)
                    {
                        MessageBox.Show("Podano za wysoką kwotę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if((kwota + rez.zaliczka) < uczest.cena_rezerwacji)
                    {
                        rez.zaliczka += kwota;
                        rez.stan = false;
                        MessageBox.Show("Zapłacono: " + rez.zaliczka.ToString() + 
                            "\nDo zapłaty pozostało: " + (uczest.cena_rezerwacji - rez.zaliczka).ToString(), 
                            "Do zapłaty", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }

                    db.SaveChanges();
                    this.Dispose();
                }
                catch (FormatException exception)
                {
                    MessageBox.Show("Podano nieprawidłową kwotę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Podano nieprawidłowy numer rezerwacji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }

        private void tb_numerRezerwacji_Leave(object sender, EventArgs e)
        {
            bazaEntities db = new bazaEntities();
            int numer;
 
            try
            {
                numer = int.Parse(tb_numerRezerwacji.Text);

                var rez = (from rezerwacja in db.Rezerwacja
                           where rezerwacja.numer_rezerwacji == numer
                           select rezerwacja).FirstOrDefault();

                var uczest = (from uczestnictwo in db.Uczestnictwo
                              where uczestnictwo.numer_rezerwacji == numer
                              select uczestnictwo).FirstOrDefault();

                tb_nazwaWycieczkiZaplac.Text = rez.Wycieczka.nazwa;
                tb_kwotaCalkowita.Text = (uczest.cena_rezerwacji).ToString();
                tb_kwotaDoZaplaty.Text = (uczest.cena_rezerwacji - rez.zaliczka).ToString();

                if((uczest.cena_rezerwacji - rez.zaliczka) <= 0)
                {
                    tb_kwotaZaplacona.Enabled = false;
                }
                else
                {
                    tb_kwotaZaplacona.Enabled = true;

                }
            }
            catch(FormatException exception)
            {
                MessageBox.Show("Podano nieprawidłowy numer rezerwacji.","Błąd",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }



        }
    }
}
