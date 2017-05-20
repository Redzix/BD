using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD
{
    public partial class Klient : Form
    {
        public Klient()
        {
            InitializeComponent();
        }

        private void b_katalog_wyjdz_Click(object sender, EventArgs e)
        {
            //klasyczna obsługa wyjścia z programu po klinięciu "X"/przycisku, messagebox pyta, czy zakończyć, jeśtli tak wyacza okno, jesli nie działa dalej
            DialogResult czyZakonczyc = MessageBox.Show("Czy na pewno chcesz wyjść?","Zamknięcie aplikacji",MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (czyZakonczyc == DialogResult.Yes)
            {
                Application.Exit();
            }else
            {
                return;
            }
        }

        private void b_katalog_rezerwuj_Click(object sender, EventArgs e)
        {
            Rezerwacja rezerwacja = new Rezerwacja();
            rezerwacja.ShowDialog();
        }

        private void wystawOpinięToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opinia opinia = new Opinia();
            opinia.ShowDialog();
        }

        private void reklamujWycieczkęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reklamacja reklamancja = new Reklamacja();
            reklamancja.ShowDialog();
        }

        private void rezygnacjaZWycieczkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rezygnacja rezygnacja = new Rezygnacja();
            rezygnacja.ShowDialog();
        }

        private void Klient_FormClosing(object sender, FormClosingEventArgs e)
        {
            //klasyczna obsługa wyjścia z programu po klinięciu "X", messagebox pyta, czy zakończyć, jeśtli tak wyacza okno, jesli nie działa dalej
            DialogResult czyZakonczyc = MessageBox.Show("Czy na pewno chcesz wyjść?", "Zamknięcie aplikacji", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (czyZakonczyc == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
