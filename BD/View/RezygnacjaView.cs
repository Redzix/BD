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
    public partial class RezygnacjaView : Form
    {
        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public RezygnacjaView()
        {
            InitializeComponent();
            tb_cenaPoRezygnacji.Enabled = false;
            tb_liczbaOsob.Enabled = false;
            tb_nazwaWycieczki.Enabled = false;            
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

         private void b_pobierz_Click(object sender, EventArgs e)
         {
            bazaEntities db = new bazaEntities();

            int numer = int.Parse(tb_numerRezerwacji.Text);
            var query = (from uczestnictwo in db.Uczestnictwo
                         where uczestnictwo.numer_rezerwacji == numer
                         select new {
                            nazwa = uczestnictwo.Rezerwacja.Wycieczka.nazwa,
                            cenaRezerwacji =  uczestnictwo.cena_rezerwacji,
                            liczbaOsob = uczestnictwo.liczba_osob}).FirstOrDefault();

            tb_nazwaWycieczki.Text = query.nazwa;
            tb_liczbaOsob.Text = query.liczbaOsob.ToString();

            var cenaPoRezygnacji = query.cenaRezerwacji - (int.Parse(tb_liczbaRezygnujacychOsob.Text) * (query.cenaRezerwacji / query.liczbaOsob));
            tb_cenaPoRezygnacji.Text = cenaPoRezygnacji.ToString();
             
        }

        private void b_zapisz_Click(object sender, EventArgs e)
        {
            bazaEntities db = new bazaEntities();

            int numer = int.Parse(tb_numerRezerwacji.Text);                     

            var rezerwacja = (from rezerw in db.Rezerwacja
                              where rezerw.numer_rezerwacji == numer
                              select rezerw).FirstOrDefault();

            rezerwacja.liczba_osob = int.Parse(tb_liczbaOsob.Text) - int.Parse(tb_liczbaRezygnujacychOsob.Text);          

            var uczestnictwo = (from uc in db.Uczestnictwo
                                where uc.numer_rezerwacji == numer
                                select uc).FirstOrDefault();

            uczestnictwo.cena_rezerwacji = decimal.Parse(tb_cenaPoRezygnacji.Text);
            uczestnictwo.liczba_osob = int.Parse(tb_liczbaOsob.Text) - int.Parse(tb_liczbaRezygnujacychOsob.Text);         

            try
            {
                db.SaveChanges();
                MessageBox.Show("Zmiany wprowadzono poprawnie","Zmieniono rezerwację.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();s

            }catch(Exception exception)
            {
                MessageBox.Show("Wystąpił problem podczas wprowadzania zmian. Błąd:\n" + exception.Message,"Błąd podczas zmiany rezerwacji",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
