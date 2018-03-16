using System;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace PrestAgenda
{
    class temporal
    {
        public MySqlConnection t = new MySqlConnection("Server=127.0.0.1; Database=prestamos; Uid=root; Pwd=;");

        public MySqlDataReader dr;

        public void abrir()
        {
            t.Open();
        }

        public void cerrar()
        {
            t.Close();
        }

        public void movimiento(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, t);
            cmd.ExecuteNonQuery();
        }

        public void consulta(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, t);
            dr = cmd.ExecuteReader();
        }
    }
}
