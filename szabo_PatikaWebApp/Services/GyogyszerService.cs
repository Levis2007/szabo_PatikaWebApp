using MySql.Data.MySqlClient;
using szabo_PatikaWebApp.Models;

namespace szabo_PatikaWebApp.Services
{
    public class GyogyszerService
    {
        public List<Gyogyszer> GetAllGyogyszer()
        {
            try
            {
                List<Gyogyszer> gyogyszerek = new List<Gyogyszer>();

                string connectionString = "SERVER = localhost;" +
                              "DATABASE= patika;" +
                              "UID = root;" +
                              "PASSWORD =;";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string sql = "SELECT * FROM gyogyszer";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Gyogyszer gyogyszer = new Gyogyszer();
                    gyogyszer.Id = reader.GetInt32("Id");
                    gyogyszer.Nev = reader.GetString("Nev");
                    gyogyszer.Hatoanyag = reader.GetString("Hatoanyag");
                    gyogyszer.Venykoteles = reader.GetBoolean("Venykoteles");
                    gyogyszer.Kepnev = reader.GetString("Kepnev");
                    gyogyszerek.Add(gyogyszer);
                }
                conn.Close();

                return gyogyszerek;
            }
            catch (Exception ex)
            {
                List<Gyogyszer> gyogyszerek = new List<Gyogyszer>();
                return gyogyszerek;
            }
        }

        public Gyogyszer GetById(int id)
        {
            Gyogyszer result = new Gyogyszer();
            try
            {
                List<Gyogyszer> gyogyszerek = new List<Gyogyszer>();

                string connectionString = "SERVER = localhost;" +
                              "DATABASE= patika;" +
                              "UID = root;" +
                              "PASSWORD =;";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string sql = "SELECT * FROM gyogyszer WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("Id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result.Id = reader.GetInt32("Id");
                    result.Nev = reader.GetString("Nev");
                    result.Hatoanyag = reader.GetString("Hatoanyag");
                    result.Venykoteles = reader.GetBoolean("Venykoteles");
                    result.Kepnev = reader.GetString("Kepnev");
                }
                else
                {
                    Console.WriteLine("Nincs ilyen gyógyszer!");
                }
                conn.Close();
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
    }
}
