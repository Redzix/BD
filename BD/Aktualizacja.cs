using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace BD
{
    class Aktualizacja
    {
        private SqlConnection _polaczenie;
        private SqlCommand _zapytanie;
 
        private string lastupdate;
        private string databasename;
        private string nazwaTabeli;

        public Aktualizacja(string nazwa)
        {
            _polaczenie = new SqlConnection();
            _zapytanie = new SqlCommand();
            nazwaTabeli = nazwa;
        }

        public string ostatniaAktualizacja
        {
            get
            {
                return this.lastupdate;
            }
            set
            {
                this.lastupdate = value;
            }
        }

        public string dataOstatniejAktualizacji()
        {
            
            _polaczenie.ConnectionString = "Server=bditake.database.windows.net; Database=baza; User Id=bdsql; password=Chuj123123";
            _polaczenie.Open();

            _zapytanie.Connection = _polaczenie;
            _zapytanie.CommandText = "select OBJECT_NAME(OBJECT_ID) AS DatabaseName," +
                " last_user_update" +
                " from sys.dm_db_index_usage_stats " +
                "where database_id = DB_ID('baza') AND CHARINDEX(OBJECT_NAME(OBJECT_ID), '"+ nazwaTabeli +"', 1)<>0" +
                "order by last_user_update desc";

            SqlDataReader reader = _zapytanie.ExecuteReader();
            reader.Read();
            var tmpupdate = reader["last_user_update"].ToString();
            this.databasename = reader["DatabaseName"].ToString();
            reader.Close();

            _polaczenie.Close();
            return tmpupdate;
        }

        public bool czyBylaAktualizacja() 
        {
            if (dataOstatniejAktualizacji().Equals(lastupdate))
                return false;
            else
            {
                this.lastupdate = dataOstatniejAktualizacji();
                return true;
            }
        }
    }
}
