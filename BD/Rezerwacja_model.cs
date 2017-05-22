using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class Rezerwacja_model
    {
        private int _numer;
        private int _liczbaOsob;
        private bool _stan;
        private decimal _zaliczka;

        public Rezerwacja_model(){}

        ~Rezerwacja_model(){}

        public int Numer
        {
            get
            {
                return this._numer;
            }
            set
            {
                this._numer = value;
            }
        }

        public int LiczbaOsob
        {
            get
            {
                return this._liczbaOsob;
            }
            set
            {
                this._liczbaOsob = value;
            }
        }

        public bool Stan
        {
            get
            {
                return this._stan;
            }
            set
            {
                this._stan = value;
            }
        }

        public decimal Zaliczka
        {
            get
            {
                return this._zaliczka;
            }
            set
            {
                this._zaliczka = value;
            }
        }
    }
}
