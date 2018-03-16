using System;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PrestAgenda
{
    public partial class login : Form
    {
        conexion CN = new conexion();
        temporal T = new temporal();

        public login()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (lblConnection.Text == "Conectado Servidor")
            {
                try
                {
                    CN.abrir();
                    CN.consulta("SELECT * FROM usuarios WHERE contrasena = '"+txtContraseña.Text+"' AND usuario = '"+txtUsuario.Text+"';");
                    int count = 0;
                    while (CN.dr.Read())
                    {
                        count++;
                    }

                    if (count == 1)
                    {
                        control pane = new control();
                        pane.Show();
                        this.Hide();
                    }
                }
                catch (MySqlException x)
                {
                    MessageBox.Show(x.ToString());
                }
                CN.cerrar();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                CN.abrir();
                lblConnection.Text = "Conectado Servidor";
                btnAceptar.Enabled = true;
                CN.cerrar();
            }
            catch
            {
                CN.cerrar();
                try
                {
                    T.abrir();
                    lblConnection.Text = "Conectado Local";
                    btnAceptar.Enabled = false;
                    T.cerrar();
                }
                catch
                {
                    T.cerrar();
                    lblConnection.Text = "Desconectado Local";
                    btnAceptar.Enabled = false;
                }
            }
        }

        private void linkRegistrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro reg = new Registro();
            reg.Show();
            this.Hide();
        }
    }
}
