using BD.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.Mapping;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD.View
{
    
    public partial class RaporterView : Form
    {
        RaporterController controller;
        int rodzaj;
        public RaporterView(int rodzaj)
        {
            InitializeComponent();
            this.rodzaj = rodzaj;
            controller = new RaporterController(this);
            controller.ZaladujKolumny(rodzaj);
        }
        private void b_GenerujRaport_Click(object sender, EventArgs e)
        {
            PdfCreator pdf = new PdfCreator(textBox1.Text);
            try
            {
                pdf.createPDF(lv_Sortowanie);
                MessageBox.Show("Raport został wygenerowany dla odpowiednich kolumn.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch
            {
                MessageBox.Show("Najpierw musisz wypełnić pola dla raportu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void b_DodajKolumny_Click(object sender, EventArgs e)
        {
            switch (rodzaj)
            {
                case 0:
                    controller.WypelnijDlaWycieczek(false);
                    break;
                case 1:
                    controller.WypelnijDlaReklamacji(false);
                    break;
                case 2:
                    controller.WypelnijDlaPojazdow(false);
                    break;
            }
        }

        private void sortListViewByColumn(object sender, ColumnClickEventArgs e)
        {
            if (((ListView)sender).Sorting == System.Windows.Forms.SortOrder.Ascending)
                ((ListView)sender).Sorting = System.Windows.Forms.SortOrder.Descending;
            else
                ((ListView)sender).Sorting = System.Windows.Forms.SortOrder.Ascending;
            ((ListView)sender).Sort();
            ((ListView)sender).ListViewItemSorter = new ListViewItemComparer(e.Column, ((ListView)sender).Sorting);
        }

        private void lv_Sortowanie_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            sortListViewByColumn(sender, e);
        }
    }
}
