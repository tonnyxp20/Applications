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
    public partial class Departamentos : Form
    {
        conexion CN = new conexion();

        public Departamentos()
        {
            InitializeComponent();
        }

        public void limpiar()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CN.abrir();
                CN.movimientos("INSERT INTO categoria VALUES(null, '"+txtNombre.Text+"', '"+txtDescripcion.Text+"');");
                MessageBox.Show("Registro exitoso!");
                limpiar();
                CN.cerrar();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Productos prod = new Productos();
            prod.Show();
            this.Hide();
        }
    }
}
