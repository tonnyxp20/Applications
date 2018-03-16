using System;
using System.Drawing;
using System.Globalization;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JuegoCarreras
{
    public partial class Form1 : Form
    {
        TcpClient clienteSocket = new TcpClient();
        NetworkStream flujoserver = default(NetworkStream);
        string leerdato = null;

        public int total = 60000;
        public int count = 0;
        public int vidas = 3;
        public int i;

        SoundPlayer music = new SoundPlayer(@"C:\Users\Antonio\Music\PacMan.wav");
        SoundPlayer gameover = new SoundPlayer(@"C:\Users\Antonio\Music\GameOver.wav");
        SoundPlayer winner = new SoundPlayer(@"C:\Users\Antonio\Music\Winner.wav");
        SoundPlayer heart = new SoundPlayer(@"C:\Users\Antonio\Music\Hurt.wav");


        public Random rdn = new Random();
        public int cordX, cordY;
        public int poscX, poscY;

        static Keys tecla;

        public int aleatorio = 0;

        public Form1()
        {
            InitializeComponent();

            bowser.Parent = pbFondo;
            mario.Parent = pbFondo;
            tunel.Parent = pbFondo;

            vida1.Parent = pbFondo;
            vida2.Parent = pbFondo;
            vida3.Parent = pbFondo;

            btnReiniciar.Enabled = false;
            lbltiempo.Visible = false;
        }

        public void comenzar()
        {
            lbltiempo.Visible = true;
            btnComenzar.Enabled = false;
            btnReiniciar.Enabled = true;

            ThreadStart delegado = new ThreadStart(reloj);
            Thread hilo = new Thread(delegado);
            hilo.Start();
            moverTunel();
            music.PlayLooping();
        }

        /*public void enviar()
        {
            Socket juego = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint direccion = new IPEndPoint(IPAddress.Parse("192.168.43.84"), 1234);

            string texto;
            byte[] textoEnviar;

            try
            {
                juego.Connect(direccion);
                MessageBox.Show("Conectado con exito");
                //MessageBox.Show("Ingrese el texto a enviar al servidor: ");
                texto = "Hola soy el jugador 2";
                textoEnviar = Encoding.Default.GetBytes(texto);
                juego.Send(textoEnviar, 0, textoEnviar.Length, 0);
                MessageBox.Show("Enviado exitosamente");
                juego.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }*/

        public void recibir()
        {
            byte[] ByRec;
            Socket juego = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint direccion = new IPEndPoint(IPAddress.Parse("192.168.43.84"), 1234);

            try
            {
                juego.Bind(direccion);
                juego.Listen(1);

                // Console.WriteLine("Escuchando...");
                Socket escuchar = juego.Accept();
                comenzar();
                // Console.WriteLine("Conectado con exito");

                ByRec = new byte[255];
                int a = escuchar.Receive(ByRec, 0, ByRec.Length, 0);
                Array.Resize(ref ByRec, a);
                // Console.WriteLine("Cliente dice: " + Encoding.Default.GetString(ByRec));
                // string texto = Encoding.Default.GetString(ByRec);
                // lblPlayer.Text = Encoding.Default.GetString(ByRec);
                // MessageBox.Show(texto);
                juego.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                juego.Close();
            }
            // Console.WriteLine("Presione cualquier tecla para terminar");
            // Console.ReadLine();
        }

        private void socket()
        {
            try
            {
                leerdato = "Conectado al servidor ...";

                msg();

                //clienteSocket.Connect("192.168.43.7", 8888);
                //clienteSocket.Connect("192.168.1.75", 8888);
                clienteSocket.Connect("127.0.0.1", 8888);

                flujoserver = clienteSocket.GetStream();

                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(lblPlayer.Text + "$");
                flujoserver.Write(outStream, 0, outStream.Length);
                flujoserver.Flush();

                Thread hilo = new Thread(obtener_msg);
                hilo.Start();
                Thread.Sleep(100);

                comenzar();
            }
            catch (Exception)
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
            catch (Exception)
            {
                clienteSocket.Close();
            }
        }

        /*public void metodo()
        {
            try
            {
                string[] array = new string[2];
                string[] posc = new string[2];
                string[] coord = new string[2];
                array = leerdato.Split(':');
                if (array[0].Trim().Equals("Jugador 2 Dice"))
                {
                    string lugar = array[1];
                    posc = lugar.Split(';');

                    if (posc[0].Trim().Equals("coor"))
                    {
                        string co = coord[1];
                        coord = co.Split(',');

                        poscX = Convert.ToInt32(coord[0]);
                        poscY = Convert.ToInt32(coord[1]);

                        mario.Location = new Point(poscX, poscY);
                    }
                    else if (posc[0].Trim().Equals("text"))
                    {
                        //array[0]es Jugador1 y el otro es hola y en la caja de texto se mostraria "Jugador 1 dice hola"
                        txtChat.Text = txtChat.Text + Environment.NewLine + " >> " + array[0] + ": " + posc[1];
                    }
                }
                else
                {
                    try
                    {
                        aleatorio = Convert.ToInt32(leerdato);
                    }
                    catch (Exception)
                    {
                        txtChat.Text = txtChat.Text + Environment.NewLine + " >> " + leerdato;
                    }
                }
            }
            catch (Exception)
            {
                // txtChat.Text = txtChat.Text + Environment.NewLine + " >> " + leerdato;
            }
        }*/

        private void msg()
        {
            if (this.InvokeRequired)

                this.Invoke(new MethodInvoker(msg));

            else
            {
                try
                {
                    aleatorio = Convert.ToInt32(leerdato);
                }
                catch(Exception)
                {
                    try
                    {
                        string[] datos = new string[2];
                        string[] coord = new string[2];
                        datos = leerdato.Split(':');
                        if (datos[0].Trim().Equals("Jugador 1 Dice"))
                        {
                            string lugar = datos[1];
                            coord = lugar.Split(',');

                            poscX = Convert.ToInt32(coord[0]);
                            poscY = Convert.ToInt32(coord[1]);

                            mario.Location = new Point(poscX, poscY);
                        }
                    }
                    catch (Exception)
                    {
                       // txtChat.Text = txtChat.Text + Environment.NewLine + " >> " + leerdato;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            socket();
            //recibir();
            //comenzar();

            bowser.Image = imgListBw.Images[0];
            mario.Image = imgListMb.Images[0];

            vida1.Image = imgListHeart.Images[0];
            vida2.Image = imgListHeart.Images[0];
            vida3.Image = imgListHeart.Images[0];
            lbltiempo.Text = "Tiempo : " + total;
        }

        private void txtTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                byte[] flujo_salida = System.Text.Encoding.ASCII.GetBytes(txtTexto.Text + "$");

                flujoserver.Write(flujo_salida, 0, flujo_salida.Length);

                flujoserver.Flush();

                txtTexto.Clear();
            }
        }

        private void txtChat_TextChanged(object sender, EventArgs e)
        {
            txtChat.Select(txtChat.Text.Length, 0);
            txtChat.ScrollToCaret();
        }

        private void txtChat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            comenzar();
        }

        public void reloj()
        {
            for (int i = 0; i <= total; i++)
            {
                Thread.Sleep(150);
                CambiarProgreso(i);
            }
        }

        delegate void delegado2(int T2);

        public void CambiarProgreso(int T)
        {
            if (this.InvokeRequired)
            {
                delegado2 del = new delegado2(CambiarProgreso);
                object[] parametros = new object[] { T };
                Invoke(del, parametros);
            }
            else
            {
                if (count == 0)
                {
                    bowser.Image = imgListBw.Images[0];
                    mario.Image = imgListMb.Images[0];
                    count++;
                }

                else if (count == 1)
                {
                    bowser.Image = imgListBw.Images[1];
                    mario.Image = imgListMb.Images[1];
                    count = 0;
                }

                if (bowser.Location.X == mario.Location.X && bowser.Location.Y == mario.Location.Y)
                {
                    vidas -= 1;

                    if (vidas == 2)
                    {
                        vida3.Visible = false;
                        heart.Play();
                    }

                    if (vidas == 1)
                    {
                        vida2.Visible = false;
                        heart.Play();
                    }

                    if (vidas == 0)
                    {
                        vida3.Visible = false;
                        music.Stop();
                        gameover.Play();
                        MessageBox.Show("You Win!!!");
                        mario.Location = new Point(40, 480);
                        bowser.Location = new Point(660, 480);
                        tunel.Visible = false;
                        lbltiempo.Visible = false;
                    }
                }

                if (mario.Location.X == tunel.Location.X && mario.Location.Y == tunel.Location.Y)
                {
                    music.Stop();
                    winner.Play();
                    MessageBox.Show("You Lose!!!");
                    mario.Location = new Point(40, 480);
                    bowser.Location = new Point(660, 480);
                    tunel.Visible = false;
                    lbltiempo.Visible = false;
                }

                lbltiempo.Text = "Tiempo : " + T;
            }
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.Abort();
            Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            tecla = e.KeyCode;

            cordX = bowser.Location.X;
            cordY = bowser.Location.Y;

            flujoserver = clienteSocket.GetStream();

            byte[] enviar = Encoding.ASCII.GetBytes(Convert.ToString(cordX) + "," + Convert.ToString(cordY) + "$");
            flujoserver.Write(enviar, 0, enviar.Length);
            flujoserver.Flush();

            switch (tecla)
            {
                case Keys.Up:
                    if (bowser.Location.Y >= 20)
                    {
                        bowser.Location = new Point(bowser.Location.X, bowser.Location.Y - 10);
                    }
                    break;

                case Keys.Down:
                    if (bowser.Location.Y <= 500)
                    {
                        bowser.Location = new Point(bowser.Location.X, bowser.Location.Y + 10);
                    }
                    break;

                case Keys.Left:
                    if (bowser.Location.X >= 20)
                    {
                        bowser.Location = new Point(bowser.Location.X - 10, bowser.Location.Y);
                    }
                    break;

                case Keys.Right:
                    if (bowser.Location.X <= 700)
                    {
                        bowser.Location = new Point(bowser.Location.X + 10, bowser.Location.Y);
                    }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            tecla = Keys.Escape;
        }

        public void moverTunel()
        {
            ThreadStart delegado2 = new ThreadStart(reloj2);
            Thread hilo2 = new Thread(delegado2);
            hilo2.Start();
        }

        public void reloj2()
        {
            for (int i = 0; i <= total; i++)
            {
                Thread.Sleep(3000);
                CambiarProgreso2(i);
            }
        }

        delegate void delegado3(int T2);

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {

        }

        public void CambiarProgreso2(int T)
        {
            if (this.InvokeRequired)
            {
                delegado3 del = new delegado3(CambiarProgreso2);
                object[] parametros = new object[] { T };
                this.Invoke(del, parametros);
            }
            else
            {
                tunel.Image = imgListTunel.Images[0];
                aleatorio = rdn.Next(0, 9);
      
                if (aleatorio == 0)
                {
                    tunel.Location = new Point(360, 280);
                }
                else if (aleatorio == 1)
                {
                    tunel.Location = new Point(50, 70);
                }
                else if (aleatorio == 2)
                {
                    tunel.Location = new Point(680, 70);
                }
                else if (aleatorio == 3)
                {
                    tunel.Location = new Point(590, 280);
                }
                else if (aleatorio == 4)
                {
                    tunel.Location = new Point(520, 450);
                }
                else if (aleatorio == 5)
                {
                    tunel.Location = new Point(210, 360);
                }
                else if (aleatorio == 6)
                {
                    tunel.Location = new Point(70, 400);
                }
                else if (aleatorio == 7)
                {
                    tunel.Location = new Point(410, 380);
                }
                else if (aleatorio == 8)
                {
                    tunel.Location = new Point(100, 230);
                }
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            mario.Location = new Point(40, 480);
            bowser.Location = new Point(660, 480);
            vida1.Visible = true;
            vida2.Visible = true;
            vida3.Visible = true;
            music.PlayLooping();

            //el contador del reloj empieza otra vez desde 1
            i = 1;
            lbltiempo.Visible = true;
            vidas = 3;
            tunel.Visible = true;
        }
    }
}
