﻿using System;
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
        RezygnacjaController controller;

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

         private void b_oblicz_Click(object sender, EventArgs e)
         {
            int oblicz = controller.Oblicz(tb_numerRezerwacji.Text);

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

           /* bazaEntities db = new bazaEntities();
            try
            {
                int numer = int.Parse(tb_numerRezerwacji.Text);

                var query = (from uczestnictwo in db.Uczestnictwo
                             where uczestnictwo.numer_rezerwacji == numer
                             select new
                                 {
                                     nazwa = uczestnictwo.Rezerwacja.Wycieczka.nazwa,
                                     cenaRezerwacji = uczestnictwo.cena_rezerwacji,
                                     liczbaOsob = uczestnictwo.liczba_osob
                                 }).FirstOrDefault();

                tb_nazwaWycieczki.Text = query.nazwa;
                tb_liczbaOsob.Text = query.liczbaOsob.ToString();

                if (query.liczbaOsob < int.Parse(tb_liczbaRezygnujacychOsob.Text))
                {
                    MessageBox.Show("Podano zbyt dużą ilość rezygnujących osób." ,"Bład wprowadzaznia danych",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    this.b_zapisz.Enabled = false;
                }
                else if (query.liczbaOsob == int.Parse(tb_liczbaRezygnujacychOsob.Text))
                {
                    if (MessageBox.Show("rezerwacja zostanie usunięta, czy na pewno chcesz to zrobić?", "Usuwanie rezerwacji", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var usun = (from uczestnictwo in db.Uczestnictwo
                                    where uczestnictwo.numer_rezerwacji == numer
                                    select uczestnictwo.Rezerwacja).FirstOrDefault();
                        db.Rezerwacja.Remove(usun);
                        this.b_zapisz.Enabled = true;
                    }
                    else
                    {
                        this.b_zapisz.Enabled = false;
                    }
               
                }
                else
                {
                    var cenaPoRezygnacji = query.cenaRezerwacji - (int.Parse(tb_liczbaRezygnujacychOsob.Text) * (query.cenaRezerwacji / query.liczbaOsob));
                    tb_cenaPoRezygnacji.Text = cenaPoRezygnacji.ToString();
                    this.b_zapisz.Enabled = true;
                }
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Wprowadź prawidłowy numer rezerwacji oraz liczbę rezygnujących osób..", "Błąd podczas pobierania danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Rezerwacja nie isnieje.", "Błąd podczas pobierania danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Wystąpił problem podczas zapisywania zmian do bazy danych.", "Błąd podczas zapisywania danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void b_zapisz_Click(object sender, EventArgs e)
        {
            int zapisz = controller.Zapisz(tb_numerRezerwacji.Text);

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
    }
}
