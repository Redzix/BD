using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class Pojazd_model
    {
        private string _numerRejestracyjny;
        private bool _dostepnosc;
        private string _marka;
        private bool _stan;
        private int _pojemnosc;

        public Pojazd_model(){}

        ~Pojazd_model(){}

        public string NumerRejestracyjny            
        {
            get
            {
                return this._numerRejestracyjny;
            }
            set
            {
                this._numerRejestracyjny = value;
            }
        }

        public bool Dostepnosc        
        {
            get
            {
                return this._dostepnosc;
            }
            set
            {
                this._dostepnosc = value;
            }
        }

        public string Marka
        {
            get
            {
                return this._marka;
            }
            set
            {
                this._marka = value;
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
        public int Pojemnosc
        {
            get
            {
                return this._pojemnosc;
            }
            set
            {
                this._pojemnosc = value;
            }
        }

        }
}
