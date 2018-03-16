using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APV
{
    public partial class Menu : Form
    {
        public string n = "";
        public string t = "";

        public Menu(string nombre, string tipo)
        {
            InitializeComponent();
            n = nombre;
            t = tipo;

            if(t == "general")
            {
                registrarToolStripMenuItem.Enabled = false;
                inventarioToolStripMenuItem.Enabled = false;
                reportesToolStripMenuItem.Enabled = false;
            }
            else if(t == "administrador")
            {
                registrarToolStripMenuItem.Enabled = true;
                inventarioToolStripMenuItem.Enabled = true;
                reportesToolStripMenuItem.Enabled = true;
            }
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas(n, t);
            venta.Show();
            this.Hide();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventario stock = new Inventario(n, t);
            stock.Show();
            this.Hide();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes reporte = new Reportes(n , t);
            reporte.Show();
            this.Hide();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro(n, t);
            registro.Show();
            this.Hide();
        }
    }
}
