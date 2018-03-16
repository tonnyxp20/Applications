using System;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace PrestAgenda
{
    public partial class buscar : Form
    {
        conexion CN = new conexion();
        public string cliente = "";
        public string apellidos = "";

        public buscar()
        {
            InitializeComponent();
        }

        public void cargar(DataGridView dgv)
        {
            try
            {
                string consulta = "SELECT num_cliente, nombre, apellidos FROM clientes;";
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            control pane = new control();
            pane.Show();
            this.Hide();
        }

        private void buscar_Load(object sender, EventArgs e)
        {
            cargar(dgvClientes);
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cliente = dgvClientes.CurrentRow.Cells[0].Value.ToString().TrimEnd();
            txtNombre.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString().TrimEnd();
            apellidos = dgvClientes.CurrentRow.Cells[2].Value.ToString().TrimEnd();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            control pane = new control();
            pane.cliente = cliente;
            pane.txtNombre.Text = txtNombre.Text;
            pane.txtApellidos.Text = apellidos;
            pane.Show();
            this.Hide();
        }
    }
}
