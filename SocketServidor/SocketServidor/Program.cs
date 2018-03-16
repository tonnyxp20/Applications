using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets; //conexion socket
using System.Threading; //hilos
using System.Collections;
using System.Net;

namespace SocketServidor
{
    class Program
    {
        //identificador
        public static Hashtable clientelista = new Hashtable();

        static void Main(string[] args)
        {
            recibir(); //juego

            //protocolo de control de transmicion (TCP)
            TcpListener serverSocket = new TcpListener(8888);
            TcpClient clientSocket = default(TcpClient);

            int counter = 0;
            bool x = true;

            serverSocket.Start(); //ejecuta el socket
            Console.WriteLine("Servidor iniciado...");

            //agrega los clientes
            while ((true))
            {
                counter += 1;
                clientSocket = serverSocket.AcceptTcpClient();
                byte[] bytesDe = new byte[70000]; //max capacidad de 70000 bytes
                string datoCliente = null;
                NetworkStream flujo_red = clientSocket.GetStream(); //toma el flujo desde un socket
                flujo_red.Read(bytesDe, 0, (int)clientSocket.ReceiveBufferSize); //lee toda la info del cliente
                datoCliente = System.Text.Encoding.ASCII.GetString(bytesDe); //los bytes convertidos de ascii a string
                datoCliente = datoCliente.Substring(0, datoCliente.IndexOf("$")); //lee toma el dato y lo corta de 0 hasta el indice de $
                clientelista.Add(datoCliente, clientSocket);
                string nom = datoCliente; //respaldo de la info
                transmision(datoCliente + " ha entrado ", nom, false); //mensaje para los clientes
                Console.WriteLine(datoCliente + " se ha unido"); //mensaje para el servidor
                Manejador cliente = new Manejador();
                cliente.startClient(clientSocket, nom, clientelista);

            }

            // clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine("Salir");
            Console.ReadLine();
        }

        public static void recibir()
        {
            byte[] ByRec;
            Socket juego = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint direccion = new IPEndPoint(IPAddress.Parse("192.168.43.84"), 1234);

            try
            {
                juego.Bind(direccion);
                juego.Listen(1);

                Console.WriteLine("Escuchando...");
                Socket escuchar = juego.Accept();
                Console.WriteLine("Conectado con exito");

                ByRec = new byte[255];
                int a = escuchar.Receive(ByRec, 0, ByRec.Length, 0);
                Array.Resize(ref ByRec, a);
                Console.WriteLine("Cliente dice: " + Encoding.Default.GetString(ByRec));

                // muestra el msg
                juego.Close();
            }
            catch(Exception x)
            {
                Console.WriteLine(x.Message);
            }
            Console.WriteLine("Presione cualquier tecla para terminar");
            Console.ReadLine();

        }

        public static void transmision(string msg, string us, bool flag)
        {
            //para cada uno de los clientes de lista, envia el msg
            foreach (DictionaryEntry Item in clientelista)
            {
                TcpClient Socket_Trans;
                Socket_Trans = (TcpClient)Item.Value;
                NetworkStream flujo_trans = Socket_Trans.GetStream(); //toma el flujo desde un socket
                //bytes[] --> Datos/INFO
                Byte[] byte_trans = null;

                if (flag == true)
                {
                    byte_trans = Encoding.ASCII.GetBytes(us + " Dice: " + msg); //lee los bytes y los traduce a string
                }
                else
                {
                    byte_trans = Encoding.ASCII.GetBytes(msg); //se ha unido al chat
                }

                flujo_trans.Write(byte_trans, 0, byte_trans.Length);
                flujo_trans.Flush(); //vacia y envia la informacion
            }
        }
    }

    public class Manejador
    {
        TcpClient clienteSocket;
        string nomm;
        Hashtable lista_cliente;

        public void startClient(TcpClient in_ClienteSocket, string cli_nom, Hashtable c_lista)
        {
            this.clienteSocket = in_ClienteSocket;
            this.nomm = cli_nom;
            this.lista_cliente = c_lista;
            Thread hilo = new Thread(chatt); //recursividad con metodo chatt
            hilo.Start(); //ejecuta el hilo
        }

        private void chatt()
        {
            int peticion = 0;
            byte[] datosDe = new byte[70000];
            string datosCliente = null;
            Byte[] datosEnviado = null;
            string Respuesta = null;
            string cont = null;

            while ((true))
            {
                try
                {
                    peticion += 1; //peticion = peticion + 1
                    NetworkStream flujo_red = this.clienteSocket.GetStream();
                    flujo_red.Read(datosDe, 0, (int)clienteSocket.ReceiveBufferSize);
                    datosCliente = System.Text.Encoding.ASCII.GetString(datosDe);
                    datosCliente = datosCliente.Substring(0, datosCliente.IndexOf("$"));
                    Console.WriteLine("De cliente_" + nomm + ": " + datosCliente); //genera el msg del usuario
                    cont = Convert.ToString(peticion);
                    Program.transmision(datosCliente, nomm, true);
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.ToString());
                    Environment.Exit(0);
                }
            }
        }
    }
}