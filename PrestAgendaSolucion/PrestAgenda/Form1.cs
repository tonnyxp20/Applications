using System;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PrestAgenda
{
    public partial class Form1 : Form
    {
        conexion CN = new conexion();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                CN.abrir();
                MessageBox.Show("Conexion exitosa!");
                CN.cerrar();
            }
            catch(MySqlException x)
            {
                MessageBox.Show(x.ToString());
            }
        }
    }
}
