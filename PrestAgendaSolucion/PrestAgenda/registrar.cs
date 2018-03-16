using System;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace PrestAgenda
{
    public partial class registrar : Form
    {
        conexion CN = new conexion();
        temporal T = new temporal();

        public registrar()
        {
            InitializeComponent();
            timer1.Start();
            timer2.Start();
        }

        public void tabla()
        {
            try
            {
                string query = "SELECT * FROM clientes;";
                MySqlDataAdapter da = new MySqlDataAdapter(query, T.t);
                DataSet ds = new DataSet();
                da.Fill(ds, "clientes");
                dgvRegistro.DataSource = ds.Tables["clientes"];
            }

            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
            }
        }

        public void copy()
        {
            string num_cliente;
            string nombre, apellidos, telefono;
            string colonia, calle, numero;
            string prestamo;

            for (int i = 0; i < dgvRegistro.RowCount; i++)
            {
                num_cliente = dgvRegistro.Rows[i].Cells[0].Value.ToString();
                nombre = dgvRegistro.Rows[i].Cells[1].Value.ToString();
                apellidos = dgvRegistro.Rows[i].Cells[2].Value.ToString();
                telefono = dgvRegistro.Rows[i].Cells[3].Value.ToString();
                colonia = dgvRegistro.Rows[i].Cells[4].Value.ToString();
                calle = dgvRegistro.Rows[i].Cells[5].Value.ToString();
                numero = dgvRegistro.Rows[i].Cells[6].Value.ToString();
                prestamo = dgvRegistro.Rows[i].Cells[7].Value.ToString();

                try
                {
                    CN.abrir();
                    CN.movimiento("INSERT INTO clientes VALUES('"+num_cliente+"', '"+nombre+"', '"+apellidos+"', '"+telefono+"', '"+colonia+"', '"+calle+"', '"+numero+"', '"+prestamo+"');");
                    CN.cerrar();
                }
                catch (MySqlException x)
                {
                    MessageBox.Show(x.ToString());
                }

                try
                {
                    T.abrir();
                    T.movimiento("DELETE FROM clientes WHERE num_cliente = '"+num_cliente+"';");
                    T.cerrar();
                }
                catch (MySqlException x)
                {
                    MessageBox.Show(x.ToString());
                }
            }
            tabla();
        }

        public void limpiar()
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtCantidad.Clear();
            txtColonia.Clear();
            txtCalle.Clear();
            txtNumero.Clear();
        }

        private void regresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            control pane = new control();
            pane.Show();
            this.Hide();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            Application.Exit();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(lblConnection.Text == "Conectado Servidor")
            try
            {
                CN.abrir();
                CN.movimiento("INSERT INTO clientes VALUES(null, '"+txtNombre.Text+"', '"+txtApellidos.Text+"', '"+txtTelefono.Text+"', '"+txtColonia.Text+"', '"+txtCalle.Text+"', '"+txtNumero.Text+"', '"+txtCantidad.Text+"');");
                CN.cerrar();
                MessageBox.Show("Cliente registrado!");
                limpiar();
            }
            catch (MySqlException x)
            {
                MessageBox.Show(x.ToString());
            }

            if(lblConnection.Text == "Conectado Local")
            {
                try
                {
                    T.abrir();
                    T.movimiento("INSERT INTO clientes VALUES(null, '"+txtNombre.Text+"', '"+txtApellidos.Text+"', '"+txtTelefono.Text+"', '"+txtColonia.Text+"', '"+txtCalle.Text+"', '"+txtNumero.Text+"', '"+txtCantidad.Text+"');");
                    T.cerrar();
                    MessageBox.Show("Cliente registrado!");
                    limpiar();
                }
                catch (MySqlException x)
                {
                    MessageBox.Show(x.ToString());
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                CN.abrir();
                lblConnection.Text = "Conectado Servidor";
                regresarToolStripMenuItem.Enabled = true;
                CN.cerrar();
            }
            catch
            {
                CN.cerrar();
                try
                {
                    T.abrir();
                    lblConnection.Text = "Conectado Local";
                    regresarToolStripMenuItem.Enabled = false;
                    T.cerrar();
                }
                catch
                {
                    lblConnection.Text = "Desconectado Local";
                    btnGuardar.Enabled = false;
                    regresarToolStripMenuItem.Enabled = false;
                    T.cerrar();
                }
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(lblConnection.Text == "Conectado Servidor")
            {
                copy();
            }
        }
    }
}
