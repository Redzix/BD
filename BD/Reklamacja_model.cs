using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class Reklamacja_model
    {
        private int _numer;
        private bool _stan;
        private string _opis;

        public Reklamacja_model(){}
        ~Reklamacja_model(){}

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

        public string Opis
        {
            get
            {
                return this._opis;
            }
            set
            {
                this._opis = value;
            }
        }
    }
}
