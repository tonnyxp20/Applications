using System;
using System.Globalization;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Hilos
{
    public partial class Form1 : Form
    {
        //int total = 60;
        public int total;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //pbProgreso.Maximum = total;
            lblTiempo.Text = "Tiempo : " + total;
            pbProgreso.Value = total;
            //pbProgreso.Value = 0;
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
            /*for (int i = 0; i <= total; i++)
            {
                Thread.Sleep(100);
                CambiarProgreso(i);
                if (i == total)
                {
                    MessageBox.Show("Finish");
                    Thread.CurrentThread.Suspend(); //para el hilo
                }
            }*/

            for (int i = total; i <= total; i--)
            {
                Thread.Sleep(100);
                CambiarProgreso(i);
                if (i == 0)
                {
                    MessageBox.Show("Finish");
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
                lblTiempo.Text = "Tiempo : " + T;
                pbProgreso.Value = T; // termina el hilo
            }
        }
    }
}
