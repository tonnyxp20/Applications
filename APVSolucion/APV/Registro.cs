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
    public partial class Registro : Form
    {
        conexion CN = new conexion();
        public string n = "";
        public string t = "";

        public Registro(string nombre, string tipo)
        {
            InitializeComponent();
            n = nombre;
            t = tipo;
        }

        public void limpiar()
        {
            txtUsuario.Clear();
            txtContrasena.Clear();
            txtRContrasena.Clear();
            cmbTipo.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" && txtContrasena.Text != "" && txtRContrasena.Text != "" && cmbTipo.Text != "")
            {
                if (txtContrasena.Text != txtRContrasena.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden, intente nuevamente...");
                    txtContrasena.Clear();
                    txtRContrasena.Clear();
                }
                else
                {

                    try
                    {
                        CN.abrir();
                        CN.movimientos("INSERT INTO usuarios VALUES(null, '" + txtUsuario.Text + "', '" + txtContrasena.Text + "', '" + cmbTipo.Text + "');");
                        MessageBox.Show("Registro exitoso!");
                        CN.cerrar();
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(x.ToString());
                    }
                    limpiar();
                }
            }
            else
            {
                MessageBox.Show("Ingrese los datos antes de guardar.");
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void regresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(n, t);
            menu.Show();
            this.Hide();
        }

        private void cmbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
