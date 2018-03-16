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
    public partial class Inventario : Form
    {

        conexion CN = new conexion();
        public string n = "";
        public string t = "";

        public Inventario(string nombre, string tipo)
        {
            InitializeComponent();
            n = nombre;
            t = tipo;
        }

        public void limpiar()
        {
            txtProducto.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
            txtAgregar.Clear();
        }

        public void cargar(DataGridView dgv)
        {
            try
            {
                string consulta = "SELECT producto, precio, existencia FROM inventario";
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, CN.cn);
                DataSet ds = new DataSet();
                da.Fill(ds, "inventario");
                dgv.DataSource = ds.Tables["inventario"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtProducto.Text != "" && txtPrecio.Text != "" && txtCantidad.Text != "")
            {
                try
                {
                    CN.abrir();
                    CN.movimientos("INSERT INTO inventario VALUES(null, '"+txtProducto.Text+"', '"+txtPrecio.Text+"', '"+txtCantidad.Text+"');");
                    MessageBox.Show("Producto guardado!");
                    CN.cerrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                cargar(dgvInventario);
            }
            else
            {
                MessageBox.Show("Agregue el nuevo producto por favor.");
            }
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            cargar(dgvInventario);
        }

        private void btnAgregar_producto_Click(object sender, EventArgs e)
        {
            if (txtAgregar.Text != "")
            {
                int actual, nuevo, suma;
                actual = Convert.ToInt32(txtCantidad.Text);
                nuevo = Convert.ToInt32(txtAgregar.Text);

                suma = actual + nuevo;
                suma.ToString();

                try
                {
                    CN.abrir();
                    CN.movimientos("UPDATE inventario SET existencia = '"+suma+"' WHERE producto = '"+txtProducto.Text+"';");
                    MessageBox.Show("Cantidad del producto actualizada");
                    CN.cerrar();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.ToString());
                }
                cargar(dgvInventario);
                limpiar();
            }
            else
            {
                MessageBox.Show("Ingrese la nueva cantidad al stock");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnPrecio_nuevo_Click(object sender, EventArgs e)
        {
            if (txtPrecio.Text != "")
            {
                try
                {
                    CN.abrir();
                    CN.movimientos("UPDATE inventario SET precio = '"+txtPrecio.Text+"' WHERE producto = '"+txtProducto.Text+"';");
                    MessageBox.Show("Precio actualizado!");
                    CN.cerrar();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.ToString());
                }
                cargar(dgvInventario);
            }
            else
            {
                MessageBox.Show("Ingrese el precio nuevo por favor.");
            }
        }

        private void regresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(n, t);
            menu.Show();
            this.Hide();
        }

        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProducto.Text = dgvInventario.CurrentRow.Cells[0].Value.ToString().TrimEnd();
            txtPrecio.Text = dgvInventario.CurrentRow.Cells[1].Value.ToString().TrimEnd();
            txtCantidad.Text = dgvInventario.CurrentRow.Cells[2].Value.ToString().TrimEnd();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
    }
}
