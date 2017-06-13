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
    public partial class RejestracjaView : Form
    {
        /// <summary>
        /// Obiekt przechowujący kontroler.
        /// </summary>
        private RejestracjaController controller;


        public RejestracjaView()
        {
            InitializeComponent();
            controller = new RejestracjaController(this);
        }

        /// <summary>
        /// Metoda obsługujące zdarzenie wyłączenia aplikacji poprzez wciśnięcie "X", program całkowicie kończy swoją pracę
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void RejestracjaView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult czyZakonczyc = MessageBox.Show("Czy na pewno chcesz wyjść?", "Zakończ", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

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

        /// <summary>
        /// Zdarzenie obsługujące wylogowanie z systemu po wciśnięciu przycisku "Wyjdź", po kliknięciu program przechodzi do panelu logowania.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_anuluj_Click(object sender, EventArgs e)
        {
            DialogResult czyZakonczyc = MessageBox.Show("Czy na pewno chcesz wyjść do panelu pracowniczego?", "Wyloguj", MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (czyZakonczyc == DialogResult.Yes)
            {
                this.Hide();
                PanelPracowniczyView panel_pracowniczy = new PanelPracowniczyView();
                panel_pracowniczy.Closed += (s, args) => this.Close();
                panel_pracowniczy.Show();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Metoda odpowiadajaca za wywołanie funkcji tworzących nowego użytkownika i sprawdzających poprawność wprowadzonych danych.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_zarejestruj_Click(object sender, EventArgs e)
        {
            if(controller.SprawdzCzyIstnieje(this.tb_pesel.Text))
            {//istnieje
                MessageBox.Show("Użytkownik o podanym peselu już istnieje.", "Użytkownik istnieje.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {//nie istnieje
                if (controller.SprawdzCzyLoginIstnieje(this.tb_login.Text))
                {
                    MessageBox.Show("Użytkownik o podanej nazwie użytkownika już istnieje.", "Nazwa użytkownika istnieje.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (this.tb_haslo.Text.Equals(this.tb_powtorzHaslo.Text) && (this.tb_haslo.Text.Length >= 8))
                    {
                        controller.UtworzNowegoUzytkownika();

                        MessageBox.Show("Użytkownika zarejestrowano pomyślnie","Zarejestrowano poprawnie",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.Hide();
                        PanelPracowniczyView panel_pracowniczy = new PanelPracowniczyView();
                        panel_pracowniczy.Closed += (s, args) => this.Close();
                        panel_pracowniczy.Show();
                    }
                    else
                    {
                        MessageBox.Show("Podane hasła są rózne. Wprowadź poprawne hasło. Pamiętaj, że hasło musi mieć co najmniej 8 znaków.", "Błędne hasło", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.tb_haslo.Clear();
                        this.tb_powtorzHaslo.Clear();
                    }
                }
            }
        }
    }
}
