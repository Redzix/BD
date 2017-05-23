using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class Wycieczka_model
    {
        private string _nazwa;
        private DateTime _dataWyjazdu;
        private DateTime _dataPowrotu;
        private string _opis;

        public Wycieczka_model(){}

        ~Wycieczka_model(){}

        public string Nazwa
        {
            get
            {
                return this._nazwa;
            }
            set
            {
                this._nazwa = value;
            }
        }

        public DateTime DataWyjazdu
        {
            get
            {
                return this._dataWyjazdu;
            }
            set
            {
                this._dataWyjazdu = value;
            }
        }

        public DateTime DataPowrotu
        {
            get
            {
                return this._dataPowrotu;
            }
            set
            {
                this._dataPowrotu = value;
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
