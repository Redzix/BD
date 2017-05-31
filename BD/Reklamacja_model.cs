using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BD
{
    public class Reklamacja_model
    {
        private int _numer;
        private int _stan;
        private string _opis;
        private string _kierownikPesel;
        private int _idUczestnictwo;

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

        public int Stan
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

        public string KierownikPesel
        {
            get
            {
                return this._kierownikPesel;
            }
            set
            {
                this._kierownikPesel = value;
            }
        }

        public int IdUczestnictwo
        {
            get
            {
                return this._idUczestnictwo;
            }
            set
            {
                this._idUczestnictwo = value;
            }
        }



        public List<Reklamacja_model> PobierzReklamacje()
        {
            List<Reklamacja_model> _listaReklamacji = new List<Reklamacja_model>();
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();
            SqlCommand _zapytanie = _polacz.UtworzZapytanie("SELECT * FROM Reklamacja");

            SqlDataReader reader = _zapytanie.ExecuteReader();
            while (reader.Read())
            {
                Reklamacja_model reklamacja = new Reklamacja_model();
                reklamacja.Numer = Convert.ToInt32(reader["numer_reklamacji"]);
                reklamacja.Opis = reader["opis"].ToString();
                reklamacja.Stan = Convert.ToInt32(reader["stan"]);
                reklamacja.KierownikPesel = reader["Kierownik_pesel"].ToString();
                reklamacja.IdUczestnictwo = Convert.ToInt32(reader["id_uczestnictwo"]);

                _listaReklamacji.Add(reklamacja);
            }
            _polacz.ZakonczPolaczenie();
            return _listaReklamacji;
        }

        public bool DodajReklamacje(Reklamacja_model reklamacja)
        {
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();

            int numerRezerwacji = 0;

            numerRezerwacji = _polacz.PobierzDaneInt(_polacz.UtworzZapytanie("SELECT Uczestnictwo.numer_rezerwacji " +
                "FROM Reklamacja " +
                "INNER JOIN Uczestnictwo on Uczestnictwo.id_uczestnictwo = Reklamacja.id_uczestnictwo " +
                "WHERE numer_reklamacji = " + reklamacja.Numer));

            if (numerRezerwacji != 0)
            {
                //tu cos lepszego potem
                MessageBox.Show("Opinia do danej rezerwacji już istnieje. Nowa nie została dodana do bazy.");
                return false;
            }
            else
            {
                SqlCommand _zapytanie = _polacz.UtworzZapytanie("INSERT INTO Reklamacja " +
                    "VALUES(" + reklamacja.Numer + ",'" + reklamacja.Opis + "'," + reklamacja.Stan + ",'" + reklamacja.KierownikPesel + "'," + reklamacja.IdUczestnictwo + ")");
                _zapytanie.ExecuteNonQuery();
                return true;
            }
        }

    }
}
