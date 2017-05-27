using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BD
{
    public class Pilot_model : Pracownik_model
    {
        public List<Pilot_model> pobierzPilotow()
        {
            List<Pilot_model> _listaKPilotow = new List<Pilot_model>();
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();
            SqlCommand _zapytanie = _polacz.UtworzZapytanie("SELECT * FROM Pilot");

            SqlDataReader reader = _zapytanie.ExecuteReader();
            while (reader.Read())
            {
                Pilot_model pilot = new Pilot_model();

                pilot.NumerPesel = reader["pesel"].ToString();
                pilot.Imie = reader["imie"].ToString();
                pilot.Nazwisko = reader["nazwisko"].ToString();
                pilot.Adres = reader["ulica"].ToString();
                pilot.Miejscowosc = reader["miejscowosc"].ToString();

                _listaKPilotow.Add(pilot);
            }
            _polacz.ZakonczPolaczenie();
            return _listaKPilotow;
        }
    }
}
