using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class Wycieczka_model
    {
        private DateTime _dataOdjazdu;
        private DateTime _dataPowrotu;
        private string _opis;

        public Wycieczka_model(){}

        ~Wycieczka_model(){}

        public DateTime DataOdjazdu
        {
            get
            {
                return this._dataOdjazdu;
            }
            set
            {
                this._dataOdjazdu = value;
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
