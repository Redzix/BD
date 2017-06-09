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
    public partial class PanelPracowniczyView : Form
    {
        private PanelPracowniczyController controller;

        /// <summary>
        /// Główny konstruktor okna.
        /// </summary>
        public PanelPracowniczyView()
        {
            InitializeComponent();
            controller = new PanelPracowniczyController(this);
        }
        /// <summary>
        /// Zdarzenie obsługujące wyjście z aplikacji
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_zakoncz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
  
        /// <summary>
        /// Obsługuje wyszukiwanie w bazie loginu i hasła podanych przez użytkownika wraz z odpowiednimi prawami, 
        /// następnie uruchamia odpowiedni panel
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_zaloguj_Click(object sender, EventArgs e)
        {
            int sprawdz = controller.SprawdzDaneLogowania(tb_nazwa_uzytkownika.Text, tb_haslo.Text);

            switch (sprawdz)
            {
                case 1:
                    break;
                case 0:
                    MessageBox.Show("Wprowadź poprawne dane logowania.", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -1:
                    MessageBox.Show("Błąd logowania. Stopień uprawnien dla podanych danych nie isnieje.", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -2:
                    MessageBox.Show("Wystąpił problem podczas pobierania danych z bazy.","Błąd logowania",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }

            /*
            string login = tb_nazwa_uzytkownika.Text;
            string password = tb_haslo.Text;
            string uprawnienia = "";
            int i = 0;
            bool czyZnaleziono = false;
            string[,] loginy = new string[4, 3];
     
            loginy[0, 0] = "kierowca";
            loginy[0, 1] = "kierowca";
            loginy[0, 2] = "kierowca";

            loginy[1, 0] = "kierownik";
            loginy[1, 1] = "kierownik";
            loginy[1, 2] = "kierownik";

            loginy[2, 0] = "klient";
            loginy[2, 1] = "klient";
            loginy[2, 2] = "klient";

            loginy[3, 0] = "pilot";
            loginy[3, 1] = "pilot";
            loginy[3, 2] = "pilot";                  

            // Przegląda baze loginów i haseł, dopóki nie znajdzie prawidłowego dopasowania bądź nie przekroczy limitu
            while((czyZnaleziono == false) && i<4)
            {
                if (login.Equals(loginy[i, 0]) && password.Equals(loginy[i, 1]))
                {
                    czyZnaleziono = true;
                    uprawnienia = loginy[i, 2];                   
                }
                else
                {
                    czyZnaleziono = false;
                }
                    i++;
            }

            // Jeśli znaleziono pasującą parę login/hasło, sprawdza uprawnienia znalezionego użytkownika
            if(czyZnaleziono == true)
            {
                if (uprawnienia.Equals("kierownik"))
                 {
                    this.Hide();
                    KierownikView kierownik = new KierownikView(login);
                    kierownik.Closed += (s, args) => this.Close();
                    kierownik.ShowDialog();

                }
                 else if (uprawnienia.Equals("klient"))
                 {
                    this.Hide();
                    KlientView klient = new KlientView();
                    klient.Closed += (s, args) => this.Close();
                    klient.ShowDialog();

                }
                 else if (uprawnienia.Equals("kierowca"))
                 {
                    this.Hide();
                    KierowcaView kierowca = new KierowcaView(login);
                    kierowca.Closed += (s, args) => this.Close();
                    kierowca.ShowDialog();

                }
                 else if (uprawnienia.Equals("pilot"))
                 {
                    this.Hide();
                    PilotView pilot = new PilotView(login);
                    pilot.Closed += (s, args) => this.Close();
                    pilot.ShowDialog();
                }
            }
            else
            {
                // Jeśli nie znaleziono poprawnej pary, wyświetla informacje o błędzie logowania
                MessageBox.Show("Podano nieprawidłowe dane użytkownika.", "Błąd logowania.", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            */

        }
    }
}
