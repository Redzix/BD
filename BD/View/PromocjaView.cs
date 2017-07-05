using BD.Controller;
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
    public partial class PromocjaView : Form
    {
        /// <summary>
        /// Obiekt przechowujący kontroler.
        /// </summary>
        KierownikController controller;

        /// <summary>
        /// Id aktualnie wybranego katalogu
        /// </summary>
        int idKatalog;

        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public PromocjaView()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Konstruktor pobierający inforamcje o aktualnie wybranym katalogu, wywołujący funkcję pobrania i zapisu informacji o
        /// promocji do widoku.
        /// </summary>
        /// <param name="idKatalog">Aktualny katalog</param>
        public PromocjaView(int idKatalog)
        {
            InitializeComponent();
            controller = new KierownikController(this);
            this.idKatalog = idKatalog;
            bool stan = controller.LadujPromocje(idKatalog);
            b_dodaj.Visible = !stan;
            b_edytuj.Visible = stan;
        }

        /// <summary>
        /// Metoda obsługująca klikniecie przyciku dodaj promocję, wywołuje funkcję odpowiedzialną za dodawanie
        /// nowej promocji.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param
        private void button1_Click(object sender, EventArgs e)
        {
            if (controller.DodajPromocje(this.idKatalog))
                MessageBox.Show("Dodano");
            else
                MessageBox.Show("Nie dodano");
            this.Dispose();
        }

        /// <summary>
        /// Metoda obsługująca klikniecie przyciku dodaj promocję, wywołuje funkcję odpowiedzialną za edycję
        /// promocji.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param
        private void b_edytuj_Click(object sender, EventArgs e)
        {
            if (controller.EdytujPromocje(this.idKatalog))
                MessageBox.Show("Zmieniono promocję");
            else
                MessageBox.Show("NIe zmieniono, bo coś się popsuło");
            this.Dispose();
        }

        /// <summary>
        /// Metoda zabezpieczająca przed wprowadzeniem znaków innych niż cyfry do tb_cena
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void tb_kwota_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != 44))
            {
                e.Handled = true;
            }
        }
    }
}
