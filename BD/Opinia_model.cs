using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BD
{
    public class Opinia_model
    {
        private int _idOpini;
        private int _ocena;
        private string _opis;
        private int _idUczestnictwa;

        public Opinia_model(){}

        ~Opinia_model(){}

        public int IdOpini
        {
            get
            {
                return this._idOpini;
            }
            set
            {
                this._idOpini = value;
            }
        }

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

        public int IdUczestnictwa
        {
            get
            {
                return this._idUczestnictwa;
            }
            set
            {
                this._idUczestnictwa = value;
            }
        }


        public List<Opinia_model> PobierzOpinie()
        {
            List<Opinia_model> _listaOpini = new List<Opinia_model>();
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();
            SqlCommand _zapytanie = _polacz.UtworzZapytanie("SELECT * FROM Pojazd");

            SqlDataReader reader = _zapytanie.ExecuteReader();
            while (reader.Read())
            {
                Opinia_model opinia = new Opinia_model();

                opinia.IdOpini = Convert.ToInt32(reader["id_opini"]);
                opinia.Ocena = Convert.ToInt32(reader["ocena"]);
                opinia.Opis = reader["opis"].ToString();
                opinia.IdUczestnictwa = Convert.ToInt32(reader["id_uczestnictwa"]);


                _listaOpini.Add(opinia);
            }
            _polacz.ZakonczPolaczenie();
            return _listaOpini;
        }
    }
}
