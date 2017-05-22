using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class Opinia_model
    {
        private int _ocena;
        private string _opis;
                      
        public Opinia_model(){}

        ~Opinia_model(){}

        public int Ocena
        {
            get
            {
                return this._ocena;
            }
            set
            {
                this._ocena = value;
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
