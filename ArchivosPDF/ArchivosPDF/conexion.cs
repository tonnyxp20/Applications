﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ArchivosPDF
{
    class conexion
    {
        public MySqlConnection cn = new MySqlConnection("server=127.0.0.1;database=prueba;Uid=root;pwd=;");

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
