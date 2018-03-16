using System;
using System.Globalization;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

/**/
/**/

namespace socket
{
    public partial class Form1 : Form
    {

        TcpClient clienteSocket = new TcpClient();
        NetworkStream flujoserver = default(NetworkStream);
        string leerdato = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void obtener_msg()
        {
            while (true)
            {
                flujoserver= clienteSocket.GetStream();
                int tam = 0;
                byte[] enflujo = new byte[70000];
                tam = clienteSocket.ReceiveBufferSize;
                flujoserver.Read(enflujo, 0, tam);
                string dato_regreso = System.Text.Encoding.ASCII.GetString(enflujo);
                leerdato = "" + dato_regreso;
                msg();
            }
        }

        private void msg()
        {
            if (this.InvokeRequired)

                this.Invoke(new MethodInvoker(msg));

            else

                txtchat.Text = txtchat.Text + Environment.NewLine + " >> " + leerdato;
        }

        private void btnenviar_Click(object sender, EventArgs e)
        {
            byte[] flujo_salida = System.Text.Encoding.ASCII.GetBytes(txttexto.Text + "$");

            flujoserver.Write(flujo_salida, 0, flujo_salida.Length);

            flujoserver.Flush();

        }

        private void btncon_Click(object sender, EventArgs e)
        {

            leerdato = "Conectado al servidor ...";

            msg();

            //clienteSocket.Connect("127.0.0.1", 8888);
            clienteSocket.Connect("192.168.1.69", 8888);

            flujoserver = clienteSocket.GetStream();



            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(txtus.Text + "$");

            flujoserver.Write(outStream, 0, outStream.Length);

            flujoserver.Flush();



            Thread hilo = new Thread(obtener_msg);

            hilo.Start();
        } 

    }
}
