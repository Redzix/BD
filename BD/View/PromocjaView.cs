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
        KierownikController controller;
        int idKatalog;
        public PromocjaView()
        {
            InitializeComponent();
        }

        public PromocjaView(int idKatalog)
        {
            InitializeComponent();
            controller = new KierownikController(this);
            this.idKatalog = idKatalog;
            bool stan = controller.LadujPromocje(idKatalog);
            b_dodaj.Visible = !stan;
            b_edytuj.Visible = stan;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (controller.DodajPromocje(this.idKatalog))
                MessageBox.Show("Dodano");
            else
                MessageBox.Show("Nie dodano");
            controller.LadujKatalog();
            this.Dispose();
        }

        private void b_edytuj_Click(object sender, EventArgs e)
        {
            if (controller.EdytujPromocje(this.idKatalog))
                MessageBox.Show("Zmieniono promocję");
            else
                MessageBox.Show("NIe zmieniono, bo coś się popsuło");
            controller.LadujKatalog();
            this.Dispose();
        }
    }
}
