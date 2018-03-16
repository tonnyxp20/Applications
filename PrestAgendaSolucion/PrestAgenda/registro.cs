using System;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PrestAgenda
{
    public partial class Registro : Form
    {
        conexion CN = new conexion();
        temporal T = new temporal();

        public Registro()
        {
            InitializeComponent();
            timer1.Start();
        }

        public void limpiar()
        {
            txtUsuario.Clear();
            txtContrasena.Clear();
            txtRContrasena.Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContrasena.Text == txtRContrasena.Text)
                {
                    CN.abrir();
                    CN.movimiento("INSERT INTO usuarios VALUES(null, '" + txtUsuario.Text + "', '" + txtContrasena.Text + "');");
                    MessageBox.Show("Registro exitoso!");
                    limpiar();
                    CN.cerrar();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta!");
                }
            }
            catch (MySqlException x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                CN.abrir();
                lblConnection.Text = "Conectado Servidor";
                btnGuardar.Enabled = true;
                CN.cerrar();
            }
            catch
            {
                CN.cerrar();
                btnGuardar.Enabled = false;
                lblConnection.Text = "Desconectado";
            }
        }
    }
}
