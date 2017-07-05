using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD.Controller
{
    /// <summary>
    /// Kontroler do sortowania listview
    /// </summary>
    class ListViewItemComparer : IComparer
    {
        /// <summary>
        /// Kolumna do sortowania
        /// </summary>
        private int col;
        /// <summary>
        /// Rodzaj sortowania
        /// </summary>
        private SortOrder order;
        /// <summary>
        /// Konstruktor dla porównywacza
        /// </summary>
        /// <param name="column">Numer kolumny sortowanej</param>
        /// <param name="order">Rodzaj aktualnego sortowania</param>
        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }
        /// <summary>
        /// Porównanie dwóch obiektów w listview
        /// </summary>
        /// <param name="x">Pierwszy ListViewItem</param>
        /// <param name="y">Drugi ListViewItem</param>
        /// <returns>Zwraca wartość, czy x jest większe/mniejsze/równe y</returns>
        public int Compare(object x, object y)
        {
            int returnVal = -1;

            double num1, num2;
            if (double.TryParse(((ListViewItem)x).SubItems[col].Text, out num1) && double.TryParse(((ListViewItem)y).SubItems[col].Text, out num2))
            {
                bool temp = (num1 > num2);
                returnVal = (temp) ? 1 : -1;
            }
            else
            {

                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                ((ListViewItem)y).SubItems[col].Text);
            }
            if (order == SortOrder.Descending)
                returnVal *= -1;
            return returnVal;
        }
    }
}
