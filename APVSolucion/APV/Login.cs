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

namespace APV
{
    public partial class Login : Form
    {
        conexion CN = new conexion();
        public string nombre = "";
        public string tipo = "";

        public Login()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                CN.abrir();
                CN.consulta("SELECT * FROM usuarios WHERE nombre = '"+txtUsuario.Text+"' AND contraseña = '"+txtContrasena.Text+"';");

                int count = 0;
                while (CN.dr.Read())
                {
                    count++;
                    nombre = txtUsuario.Text;
                    tipo = (string)CN.dr["tipo"];
                }

                if (count == 1)
                {
                    Menu menu = new Menu(nombre, tipo);
                    menu.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Acceso denegado! \nUsuario o Contraseña incorrecto.");
                }
                CN.cerrar();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
