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
    /// <summary>
    /// Widok odpowiedzialny za wyświetlenie forma do edycji wycieczki
    /// </summary>
    public partial class WycieczkaView : Form
    {
        /// <summary>
        /// Zmienna przechowująca id aktualnie wybranego katalogu
        /// </summary>
        private int idKatalog;

        /// <summary>
        /// Obiekt przechowujący kontroler.
        /// </summary>
        KierownikController controller;

        /// <summary>
        /// Zmienna przechowująca id aktualnie wybraną opcje(dodaj/edytuj)
        /// /// </summary
        private int _opcja;

        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public WycieczkaView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Konstruktor, który tworzy formę wyciećzki dostosowaną do wybranej opcji edycji bądź dodawania wycieczki
        /// </summary>
        /// <param name="opcja">Kiedy jeden dodaje wycieczke, kiedy zero usuwa.</param>
        /// <param name="idKatalog">ID katalogu z którego pobieramy informacje dotyczące wycieczki i ceny</param>
        public WycieczkaView(int opcja, int idKatalog)
        {
            InitializeComponent();
            this.controller = new KierownikController(this);
            this.idKatalog = idKatalog;
            _opcja = opcja;
            controller.WypelnijKatalogBoxy();
            //Data odjazdu nie moze byc taka sama jak data przyjazdu
            tb_data_wyjazdu.Value = DateTime.Now;
            tb_data_powrotu.Value = tb_data_powrotu.Value.AddDays(1);

            this.b_dodaj.Visible = Convert.ToBoolean(opcja);
            this.b_zapisz.Visible = !Convert.ToBoolean(opcja);

            if (opcja == 0)
                controller.WypelnijKatalogDoEdycji(idKatalog);
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
        /// Zdarzenie obsługujące wyłączenie okna poprzez wciśnięcie "X", program wraca do głównego panelu danego użytkownika.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void Wycieczka_FormClosing(object sender, FormClosingEventArgs e)
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

        private void b_zapisz_Click(object sender, EventArgs e)
        {
            if (controller.EdytujKatalog(idKatalog))
                MessageBox.Show("Wycieczke edytowano pomyślnie.", "Edytowano wycieczkę", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Napotkano problem podczas edycji wycieczki.", "Błąd edycji wycieczki", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            this.Dispose();
        }
        //Za każdym razem jeśli zmieni się data w polu odjazdu, data w polu odjazdu zinkrementuje się o jeden
        private void tb_data_wyjazdu_ValueChanged(object sender, EventArgs e)
        {
            if (_opcja != 0)
                tb_data_powrotu.Value = ((DateTimePicker)sender).Value.AddDays(1);
        }

        private void b_dodaj_Click(object sender, EventArgs e)
        {
            if (tb_data_wyjazdu.Value > tb_data_powrotu.Value)
            {
                MessageBox.Show("Wybrano błędne daty. Data powrotu nie może być późniejsza niż data odjazdu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (controller.DodajKatalog())
                {
                    MessageBox.Show("Wycieczka została dodana pomyślnie.", "Dodano wycieczkę", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    if (MessageBox.Show("Napotkano problem podczas dodawania wycieczki.", "Błąd dodawania wycieczki", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        this.Dispose();
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Metoda zabezpieczająca przed wprowadzeniem znaków innych niż cyfry do tb_cena
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void tb_cena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != 44))
            {
                e.Handled = true;
            }
        }
    }
}