using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class Klient_model
    {
        private string _imie;
        private string _nazwisko;
        private string _adres;
        private string _miejscowosc;


        public string Imie
        {
            get
            {
                return this._imie;
            }
            set
            {
                this._imie = value;
            }
        }

        public string Nazwisko
        {
            get
            {
                return this._nazwisko;
            }
            set
            {
                this._nazwisko = value;
            }
        }

        public string Adres
        {
            get
            {
                return this._adres;
            }
            set
            {
                this._adres = value;
            }
        }

        public string Miejscowosc
        {
            get
            {
                return this._miejscowosc;
            }
            set
            {
                this._miejscowosc = value;
            }
        }
    }
}
