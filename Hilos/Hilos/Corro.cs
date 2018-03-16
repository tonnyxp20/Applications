using System;
using System.Globalization;
using System.Threading;
using System.Media;
using System.Windows.Forms;
using System.Drawing;

namespace Hilos
{
    public partial class Corro : Form
    {
        public int total;
        public int count = 0;
        int recorrer;

        public Corro()
        {
            InitializeComponent();
        }

        private void Corrro_Load(object sender, EventArgs e)
        {
            lblTiempo.Text = "Tiempo : " + total;
            pbProgreso.Value = total;
        }

        private void btnCorrer_Click(object sender, EventArgs e)
        {
            ThreadStart delegado = new ThreadStart(reloj);
            Thread hilo = new Thread(delegado);
            hilo.Start();

            total = Convert.ToInt32(txtTiempo.Text);
            pbProgreso.Maximum = total;
        }

        public void reloj()
        {
            for (int i = total; i <= total; i--)
            {
                Thread.Sleep(150);
                CambiarProgreso(i);
                if (i == 0)
                {
                    MessageBox.Show("Finish");
                    pb1.Image = imageList1.Images[0];
                    Thread.CurrentThread.Suspend(); //para el hilo
                }
            }
        }

        delegate void delegado2(int T2);

        public void CambiarProgreso(int T)
        {
            if (this.InvokeRequired)
            {
                delegado2 del = new delegado2(CambiarProgreso);
                object[] parametros = new object[] { T };
                this.Invoke(del, parametros);
            }
            // posiciones y secuencia
            // contador
            else
            {
                if (count == 0)
                {
                    pb1.Image = imageList1.Images[0];
                    pb1.Location = new Point(recorrer = recorrer + 20, pb1.Location.Y);

                    count++;
                }

                else if (count == 1)
                {
                    pb1.Image = imageList1.Images[1];
                    pb1.Location = new Point(recorrer = recorrer + 20, pb1.Location.Y);

                    count++;
                }

                else if (count == 2)
                {
                    pb1.Image = imageList1.Images[2];
                    pb1.Location = new Point(recorrer = recorrer + 20, pb1.Location.Y);

                    count++;
                }

                else if (count == 3)
                {
                    pb1.Image = imageList1.Images[3];
                    pb1.Location = new Point(recorrer = recorrer + 20, pb1.Location.Y);

                    count = 0;
                }

                if (recorrer > 460)
                {
                    recorrer = -80;
                }

                lblTiempo.Text = "Tiempo : " + T;
                pbProgreso.Value = T; // termina el hilo
            }
        }
    }
}
