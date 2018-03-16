using System;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace socket
{
    class conexion
    {
        public MySqlConnection cn = new MySqlConnection("Server=192.168.43.7; Database=chat; Uid=omar; Pwd=1234;");
        //public MySqlConnection cn = new MySqlConnection("Server=127.0.0.1; Database=chat; Uid=root; Pwd=;");

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
