using System;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace PrestAgenda
{
    public partial class control : Form
    {
        conexion CN = new conexion();
        temporal T = new temporal();

        public string cliente = "";

        public control()
        {
            InitializeComponent();
            timer1.Start();
        }

        public void prestamo()
        {
            try
            {
                CN.abrir();
                CN.consulta("SELECT prestamo FROM clientes WHERE num_cliente = '"+cliente+"';");
                if (CN.dr.Read())
                {
                    lblTotal.Text = Convert.ToInt32(CN.dr["prestamo"]).ToString();
                }
                CN.cerrar();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }

            try
            {
                CN.abrir();
                    CN.consulta("SELECT restante FROM abono WHERE num_cliente = '" +cliente+ "' ORDER BY restante asc;");
                    if (CN.dr.Read())
                    {
                        lblActual.Text = CN.dr["restante"].ToString();
                    }
                    else
                    {
                        lblActual.Text = lblTotal.Text;
                    }
                    CN.cerrar();
            }
            catch (MySqlException x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        public void habilitar()
        {
            if (txtNombre.Text != "" && txtApellidos.Text != "")
            {
                txtAbono.Enabled = true;
                btnAgregar.Enabled = true;
            }
            else
            {
                txtAbono.Enabled = false;
                btnAgregar.Enabled = false;
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login welcome = new login();
            welcome.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar search = new buscar();
            search.Show();
            this.Hide();
        }

        private void control_Load(object sender, EventArgs e)
        {
            habilitar();
            prestamo();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registrar alta = new registrar();
            alta.Show();
            this.Hide();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modificar update = new modificar();
            update.Show();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int actual = Convert.ToInt32(lblActual.Text);
            int total = Convert.ToInt32(txtAbono.Text);

            int restante = actual - total;

            if (lblConnection.Text == "Conectado Servidor")
            {
                try
                {
                    CN.abrir();
                    CN.movimiento("INSERT INTO abono VALUES('" + cliente + "', '" + txtNombre.Text + "', '" + txtApellidos.Text + "', '" + restante + "', '" + dtpFecha.Text + "');");
                    CN.cerrar();
                    MessageBox.Show("Abono registrado!");
                    txtAbono.Clear();
                    prestamo();
                }
                catch (MySqlException x)
                {
                    MessageBox.Show(x.ToString());
                }
            }

            if(lblConnection.Text == "Conectado Local")
            {
                try
                {
                    T.abrir();
                    T.movimiento("INSERT INTO abono VALUES('" + cliente + "', '" + txtNombre.Text + "', '" + txtApellidos.Text + "', '" + restante + "', '" + dtpFecha.Text + "');");
                    T.cerrar();
                    MessageBox.Show("Abono registrado!");
                    txtAbono.Clear();
                    prestamo();
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
                btnBuscar.Enabled = true;
                modificarToolStripMenuItem.Enabled = true;
                reportesToolStripMenuItem.Enabled = true;
                logoutToolStripMenuItem.Enabled = true;
                CN.cerrar();
            }
            catch
            {
                CN.cerrar();
                try
                {
                    T.abrir();
                    lblConnection.Text = "Conectado Local";
                    btnBuscar.Enabled = false;
                    btnAgregar.Enabled = false;
                    modificarToolStripMenuItem.Enabled = false;
                    reportesToolStripMenuItem.Enabled = false;
                    logoutToolStripMenuItem.Enabled = false;
                    T.cerrar();
                }
                catch
                {
                    lblConnection.Text = "Desconectado Local";
                    T.cerrar();
                }
            }
        }
    }
}
