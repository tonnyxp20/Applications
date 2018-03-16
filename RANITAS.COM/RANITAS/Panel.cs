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
    public partial class Panel : Form
    {
        conexion CN = new conexion();

        public Panel()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            Registro regist = new Registro();
            regist.Show();
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Reportes report = new Reportes();
            report.Show();
            this.Hide();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Panel_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                CN.abrir();
                lblConnect.Text = "Conectado";
                btnRegistro.Enabled = true;
                btnReportes.Enabled = true;
                CN.cerrar();
            }
            catch (Exception)
            {
                lblConnect.Text = "Desconectado";
                CN.cerrar();
                btnRegistro.Enabled = false;
                btnReportes.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
    }
}
