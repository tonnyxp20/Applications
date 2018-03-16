using System;
using System.Globalization;
using System.Net.Sockets;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace socket
{
    public partial class M1 : Form
    {
        conexion CN = new conexion();

        TcpClient clienteSocket = new TcpClient();
        NetworkStream flujoserver = default(NetworkStream);
        string leerdato = null;

        public M1()
        {
            InitializeComponent();
            timer1.Start();
        }

        public void cargar(DataGridView dgv)
        {
            try
            {
                string consulta = "SELECT usuario, contrasena, nombre FROM usuario;";
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, CN.cn);
                DataSet ds = new DataSet();
                da.Fill(ds, "usuario");
                dgv.DataSource = ds.Tables["usuario"];
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void socket()
        {
            try
            {
                leerdato = "Conectado al servidor ...";

                msg();

                //clienteSocket.Connect("127.0.0.1", 8888);
                clienteSocket.Connect("192.168.43.7", 8888);

                flujoserver = clienteSocket.GetStream();

                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(txtus.Text + "$");

                flujoserver.Write(outStream, 0, outStream.Length);

                flujoserver.Flush();

                Thread hilo = new Thread(obtener_msg);
                hilo.Start();
            }
            catch(Exception)
            {
                clienteSocket.Close();
                MessageBox.Show("No se ha podido establecer la conexion con Servidor");
                Application.Exit();
            }
        }

        private void obtener_msg()
        {
            try
            {
                while (true)
                {
                    flujoserver = clienteSocket.GetStream();
                    int tam = 0;
                    byte[] enflujo = new byte[70000];
                    tam = clienteSocket.ReceiveBufferSize;
                    flujoserver.Read(enflujo, 0, tam);
                    string dato_regreso = System.Text.Encoding.ASCII.GetString(enflujo);
                    leerdato = "" + dato_regreso;
                    msg();
                }
            }
            catch(Exception)
            {
                clienteSocket.Close();
                MessageBox.Show("No se ha podido establecer la conexion con Servidor");
                Application.Exit();
            }
        }

        private void msg()
        {
            if (this.InvokeRequired)

                this.Invoke(new MethodInvoker(msg));

            else

                txtchat.Text = txtchat.Text + Environment.NewLine + " >> " + leerdato;
        }

        private void M1_Load(object sender, EventArgs e)
        {
            socket();
            cargar(dg1);
            dg1.Visible = false;
        }

        private void txttexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                byte[] flujo_salida = System.Text.Encoding.ASCII.GetBytes(txttexto.Text + "$");

                flujoserver.Write(flujo_salida, 0, flujo_salida.Length);

                flujoserver.Flush();

                txttexto.Clear();
            }
        }

        private void txtchat_TextChanged(object sender, EventArgs e)
        {
            txtchat.Select(txtchat.Text.Length, 0);
            txtchat.ScrollToCaret();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                CN.abrir();
                lblconexion.Text = "Conectado";
                cargar(dg1);
                btnentrar.Enabled = true;
                CN.cerrar();
            }
            catch
            {
                lblconexion.Text = "Desconectado";
                btnentrar.Enabled = false;
                dg1.Visible = false;
                CN.cerrar();
            }
        }

        private void btnentrar_Click(object sender, EventArgs e)
        {
            try
            {
                CN.abrir();
                CN.consulta("SELECT * FROM usuario WHERE usuario = '" + txtuser.Text + "' AND contrasena = '" + txtpwd.Text + "' ;");

                int cont = 0;
                while (CN.dr.Read())
                {
                    cont++;
                }

                if (cont == 1)
                {
                    MessageBox.Show("Bienvenido " + txtuser.Text + "!");
                    txtuser.Clear();
                    txtpwd.Clear();
                    dg1.Visible = true;
                }
                else
                {
                    MessageBox.Show("Acceso denegado!");
                    dg1.Visible = false;
                }

                CN.cerrar();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void chkmostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkmostrar.Checked == false)
            {
                txtpwd.UseSystemPasswordChar = true;
                chkmostrar.Text = "Mostrar caracteres";
            }
            else 
            {
                txtpwd.UseSystemPasswordChar = false;
                chkmostrar.Text = "Ocultar caracteres";
            }
        }

        private void txtchat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
