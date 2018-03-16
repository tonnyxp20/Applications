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
    public partial class Inventario : Form
    {
        conexion CN = new conexion();

        public Inventario()
        {
            InitializeComponent();
        }

        public void llenar(ComboBox cmb)
        {
            try
            {
                CN.abrir();
                CN.consulta("SELECT nombre FROM productos");

                while (CN.dr.Read())
                {
                    cmb.Items.Add((string)CN.dr["nombre"]);
                }
                CN.cerrar();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        public void limpiar()
        {
            cmbNombre.Items.Clear();
            lblCantidad.Text = "0";
            txtCantidad.Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Productos prod = new Productos();
            prod.Show();
            this.Hide();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int actual = Convert.ToInt32(lblCantidad.Text);
                int nuevo = Convert.ToInt32(txtCantidad.Text);
                int suma = actual + nuevo;

                CN.abrir();
                CN.movimientos("UPDATE productos SET stock = '"+suma+"' WHERE nombre = '"+cmbNombre.Text+"';");
                MessageBox.Show("Registro actualizado!");
                txtCantidad.Clear();
                CN.cerrar();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CN.abrir();
                CN.consulta("SELECT stock FROM productos WHERE nombre = '"+cmbNombre.Text+"';");

                while (CN.dr.Read())
                {
                    lblCantidad.Text = Convert.ToString(CN.dr["stock"]);
                }
                CN.cerrar();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            llenar(cmbNombre);
        }

        private void cmbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
