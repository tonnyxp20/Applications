using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RANITAS
{
    class conexion
    {
        //public MySqlConnection cn = new MySqlConnection("server=169.254.150.254; database=cyber; Uid=tonny; pwd=happy1;");
        public MySqlConnection cn = new MySqlConnection("server=127.0.0.1; database=cyber; Uid=root; pwd=;");

        public MySqlDataReader dr;

        public void abrir()
        {
            cn.Open();
        }

        public void cerrar()
        {
            cn.Close();
        }

        public void consulta(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, cn);
            dr = cmd.ExecuteReader();
        }

        public void movimientos(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, cn);
            cmd.ExecuteNonQuery();
        }
    }
}
