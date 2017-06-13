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
        /// <summary>
        /// Obiekt przechowujący kontroler
        /// </summary>
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
        /// Metoda obsługująca zdarzenie wyjście z aplikacji
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_zakoncz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
  
        /// <summary>
        /// Obsługuje wyszukiwanie w bazie loginu i hasła podanych przez użytkownika wraz z odpowiednimi prawami, 
        /// następnie uruchamia odpowiedni panel
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
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
        }
       
    }
}
