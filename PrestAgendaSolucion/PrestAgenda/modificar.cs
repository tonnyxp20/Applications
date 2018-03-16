using System;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace PrestAgenda
{
    public partial class modificar : Form
    {
        conexion CN = new conexion();

        public modificar()
        {
            InitializeComponent();
            timer1.Start();
        }

        public void limpiar()
        {
            lblCliente.Text = "####";
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtColonia.Clear();
            txtCalle.Clear();
            txtNumero.Clear();
        }

        public void cargar(DataGridView dgv)
        {
            try
            {
                string consulta = "SELECT num_cliente, nombre, apellidos, telefono, colonia, calle, numero FROM clientes";
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, CN.cn);
                DataSet ds = new DataSet();
                da.Fill(ds, "clientes");
                dgv.DataSource = ds.Tables["clientes"];
            }
            catch (MySqlException x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void regresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            control pane = new control();
            pane.Show();
            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                CN.abrir();
                lblConnection.Text = "Conectado";
                CN.cerrar();
                regresarToolStripMenuItem.Enabled = true;
                btnGuardar.Enabled = true;
                btnBorrar.Enabled = true;
            }
            catch
            {
                CN.cerrar();
                lblConnection.Text = "Desconectado";
                regresarToolStripMenuItem.Enabled = false;
                btnGuardar.Enabled = false;
                btnBorrar.Enabled = false;
            }
        }

        private void modificar_Load(object sender, EventArgs e)
        {
            cargar(dgvClientes);
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblCliente.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString().TrimEnd();
            txtNombre.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString().TrimEnd();
            txtApellidos.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString().TrimEnd();
            txtTelefono.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString().TrimEnd();
            txtColonia.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString().TrimEnd();
            txtCalle.Text = dgvClientes.CurrentRow.Cells[5].Value.ToString().TrimEnd();
            txtNumero.Text = dgvClientes.CurrentRow.Cells[6].Value.ToString().TrimEnd();
        }

        private void chkNumero_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNumero.Checked == true)
            {
                txtNumero.Text = " ";
                txtNumero.Enabled = false;
            }
            else
            {
                txtNumero.Enabled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CN.abrir();
                CN.movimiento("UPDATE clientes SET telefono = '"+txtTelefono.Text+"', colonia = '"+txtColonia.Text+"', calle = '"+txtCalle.Text+"', numero = '"+txtNumero.Text+"' WHERE num_cliente = '"+lblCliente.Text+"';");
                CN.cerrar();
                MessageBox.Show("Cliente actualizado!");
                limpiar();
                cargar(dgvClientes);
            }
            catch(MySqlException x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que desea eliminar el cliente?", "Eliminar Cliente", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                CN.abrir();
                CN.movimiento("DELETE FROM clientes WHERE num_cliente = '" + lblCliente.Text + "';");
                CN.cerrar();
                MessageBox.Show("Cliente borrado!");
                limpiar();
                cargar(dgvClientes);
            }
        }
    }
}
