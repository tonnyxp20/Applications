using System;
using System.Globalization;
using System.Windows.Forms;

namespace RANITAS
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            int milesima, segundo, minuto;
            milesima = Convert.ToInt32(lblMilesimas.Text);
            milesima += 1;
            lblMilesimas.Text = milesima.ToString();

            if(milesima == 60)
            {
                segundo = Convert.ToInt32(lblSegundos.Text);
                segundo += 1;
                lblSegundos.Text = segundo.ToString();
                lblMilesimas.Text = "00";

                if(segundo == 60)
                {
                    minuto = Convert.ToInt32(lblMinutos.Text);
                    minuto += 1;
                    lblMinutos.Text = minuto.ToString();
                    lblSegundos.Text = "00";
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            lblMilesimas.Text = "00";
            lblSegundos.Text = "00";
            lblMinutos.Text = "00";
        }
    }
}
