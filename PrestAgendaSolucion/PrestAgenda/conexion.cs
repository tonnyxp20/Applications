using System;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace PrestAgenda
{
    class conexion
    {
        public MySqlConnection cn = new MySqlConnection("Server=192.168.1.70; Database=prestamos; Uid=tonny; Pwd=12345;");

        public MySqlDataReader dr;

        public void abrir()
        {
            cn.Open();
        }

        public void cerrar()
        {
            cn.Close();
        }

        public void movimiento(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, cn);
            cmd.ExecuteNonQuery();
        }

        public void consulta(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, cn);
            dr = cmd.ExecuteReader();
        }
    }
}
