using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace BD
{   /// <summary>
    /// Klasa odpowiedzialna za tworzenie połączenia z bazą danych, jegozamykanie i tworzenie zapytania.
    /// </summary>
    public class Polacz_z_baza
    {
        private SqlConnection _polaczenie;
        private SqlCommand _zapytanie;

        /// <summary>
        /// Funkcja otwierająca połączenie z bazą danych.
        /// </summary>
        /// <returns>Zwraca nowo utworzone połączenie.</returns>
        public SqlConnection PolaczZBaza()
        {
            _polaczenie = new SqlConnection();
            _polaczenie.ConnectionString = "Server=bditake.database.windows.net; Database=baza; User Id=bdsql; password=Chuj123123";
            _polaczenie.Open();
            return this._polaczenie;
        }

        /// <summary>
        /// Funkcja tworząca zapytanie do bazy danych.
        /// </summary>
        /// <param name="zapytanieSql">Parametr przekazujący ciąg znaków będący zapytaniem SQL do wykonania.</param>
        /// <returns>Zwraca zapytanie do bazy danych.</returns>
        public SqlCommand UtworzZapytanie(string zapytanieSql)
        {   
            _zapytanie = new SqlCommand();
            _zapytanie.Connection = _polaczenie;
            _zapytanie.CommandText = zapytanieSql;
            return this._zapytanie;
        }

        /// <summary>
        /// Funkcja zamykająca połączeni z bazą danych.
        /// </summary>
        /// <returns></returns>
        public bool ZakonczPolaczenie()
        {
            _polaczenie.Close();
            if(_polaczenie == null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// Metoda, która umozliwia pobranie z bazy danych wyszukanej wartosci string
        /// </summary>
        /// <param name="zapytanie">Wykonywane zapytanie w języku SQL</param>
        /// <returns>Zwaca wyszukaną wartosć string</returns>
        public string PobierzDaneString(SqlCommand zapytanie)
        {
            string wartosc = null;
            SqlDataReader reader = zapytanie.ExecuteReader();
            if (reader.Read())
                wartosc = reader.GetString(0);
            reader.Close();
            return wartosc;
        }

        /// <summary>
        /// Metoda, która umozliwia pobranie z bazy danych wyszukanej wartosci DateTime
        /// </summary>
        /// <param name="zapytanie">Wykonywane zapytanie w języku SQL</param>
        /// <returns>Zwaca wyszukaną wartosć DateTime</returns>
        public DateTime PobierzDaneDate(SqlCommand zapytanie)
        {
            DateTime wartosc = new DateTime(2013, 6, 1, 12, 32, 30);
            SqlDataReader reader = zapytanie.ExecuteReader();
            if (reader.Read())
                wartosc = reader.GetDateTime(0);
            reader.Close();
            return wartosc;
        }

        /// <summary>
        /// Metoda, która umozliwia pobranie z bazy danych wyszukanej wartosci int
        /// </summary>
        /// <param name="zapytanie">Wykonywane zapytanie w języku SQL</param>
        /// <returns>Zwaca wyszukaną wartosć int</returns>
        public int PobierzDaneInt(SqlCommand zapytanie)
        {
            int wartosc = 0;
            SqlDataReader reader = zapytanie.ExecuteReader();
            if (reader.Read())
                wartosc = reader.GetInt32(0);
            reader.Close();
            return wartosc;
        }        
    }
}
