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
    public partial class Productos : Form
    {
        conexion CN = new conexion();

        public Productos()
        {
            InitializeComponent();
        }

        public void limpiar()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            cmbCategoria.Items.Clear();
        }

        public void llenar(ComboBox cmb)
        {
            try
            {
                CN.abrir();
                CN.consulta("SELECT nombre FROM categoria");

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

        public void cargar(DataGridView dgv)
        {
            try
            {
                string consulta = "SELECT nombre, precio, stock, categoria FROM productos;";
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, CN.cn);
                DataSet ds = new DataSet();
                da.Fill(ds, "productos");
                dgv.DataSource = ds.Tables["productos"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            cargar(dgvProductos);
            llenar(cmbCategoria);
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                CN.abrir();
                CN.movimientos("UPDATE productos SET precio = '"+txtPrecio.Text+"' WHERE nombre = '"+txtNombre.Text+"' ;");
                MessageBox.Show("Registro actualizado!");
                cargar(dgvProductos);
                CN.cerrar();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CN.abrir();
                CN.movimientos("INSERT INTO productos VALUES(null, '"+txtNombre.Text+"', '"+txtPrecio.Text+"', '"+txtStock.Text+"', '"+cmbCategoria.Text+"');");
                MessageBox.Show("Registro exitoso!");
                cargar(dgvProductos);
                limpiar();
                CN.cerrar();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventario inv = new Inventario();
            inv.Show();
            this.Hide();
        }

        private void departamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Departamentos dept = new Departamentos();
            dept.Show();
            this.Hide();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString().TrimEnd();
            txtPrecio.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString().TrimEnd();
            txtStock.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString().TrimEnd();
            cmbCategoria.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString().TrimEnd();
        }
    }
}
