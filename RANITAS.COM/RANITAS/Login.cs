using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RANITAS
{
    public partial class Login : Form
    {
        conexion CN = new conexion();

        public Login()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text == "" && txtContrasena.Text == "")
                {
                    MessageBox.Show("Ingrese los datos de usuario");
                }
                else
                {
                    CN.abrir();
                    CN.consulta("SELECT * FROM usuarios WHERE usuario = '"+txtUsuario.Text+"' AND contrasena = '"+txtContrasena.Text+"';");

                    int count = 0;
                    while (CN.dr.Read())
                    {
                        count++;
                    }

                    if (count == 1)
                    {
                        Panel pane = new Panel();
                        pane.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Acceso denegado! \nUsuario o Contraseña incorrecto.");
                    }
                    CN.cerrar();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                CN.abrir();
                lblConectar.Text = "Conectado";
                btnIngresar.Enabled = true;
                CN.cerrar();
            }
            catch (Exception)
            {
                lblConectar.Text = "Desconectado";
                btnIngresar.Enabled = false;
                CN.cerrar();
            }
        }
    }
}
