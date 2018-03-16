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
    public partial class Registro : Form
    {
        conexion CN = new conexion();
        int id_usuario = 0;

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
            cmbTipo.Items.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Panel pane = new Panel();
            pane.Show();
            this.Hide();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContrasena.Text == txtRContrasena.Text)
                {
                    CN.abrir();
                    CN.movimientos("INSERT INTO usuarios VALUES(null, '"+txtUsuario.Text+"', '"+txtContrasena.Text+"', '"+cmbTipo.Text+"');");
                    MessageBox.Show("Registro exitoso!");
                    limpiar();
                    CN.cerrar();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta!");
                }
            }
            catch(Exception x)
            {
                MessageBox.Show("Error " + x.ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" || txtContrasena.Text != "" || txtRContrasena.Text != "" || cmbTipo.Text != "")
            {
                try
                {
                    CN.abrir();
                    CN.consulta("SELECT * FROM usuarios WHERE usuario = '" + txtUsuario.Text + "'");
                    while (CN.dr.Read())
                    {
                        id_usuario = (int)(CN.dr["id"]);
                        txtContrasena.Text = (string)(CN.dr["contrasena"]);
                        txtRContrasena.Text = (string)(CN.dr["contrasena"]);
                        cmbTipo.Text = (string)(CN.dr["tipo"]);
                    }
                    CN.cerrar();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.ToString());
                }
            }
            else
            {
                MessageBox.Show("Ingrese los datos de usuarios");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" || txtContrasena.Text != "" || txtRContrasena.Text != "" || cmbTipo.Text != "")
            {
                if (txtContrasena.Text == txtRContrasena.Text)
                {
                    try
                    {
                        CN.abrir();
                        CN.movimientos("UPDATE usuarios SET usuario = '" + txtUsuario.Text + "', contrasena = '" + txtRContrasena.Text + "', tipo = '" + cmbTipo.Text + "' WHERE id = '" + id_usuario + "';");
                        MessageBox.Show("Usuario actualizado!");
                        CN.cerrar();
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(x.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta!");
                }
            }
            else
            {
                MessageBox.Show("Ingrese los datos de usuarios");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" || txtContrasena.Text != "" || txtRContrasena.Text != "" || cmbTipo.Text != "")
            {
                try
                {
                    CN.abrir();
                    CN.movimientos("DELETE FROM usuarios WHERE id = '" + id_usuario + "';");
                    MessageBox.Show("Usuario borrado!");
                    limpiar();
                    CN.cerrar();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.ToString());
                }
            }
            else
            {
                MessageBox.Show("Ingrese los datos de usuarios");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                CN.abrir();
                //si hay conexion
                btnGuardar.Enabled = true;
                btnBuscar.Enabled = true;
                btnEditar.Enabled = true;
                btnBorrar.Enabled = true;
                CN.cerrar();
            }
            catch (Exception)
            {
                CN.cerrar();
                btnGuardar.Enabled = false;
                btnBuscar.Enabled = false;
                btnEditar.Enabled = false;
                btnBorrar.Enabled = false;
            }
        }
    }
}
