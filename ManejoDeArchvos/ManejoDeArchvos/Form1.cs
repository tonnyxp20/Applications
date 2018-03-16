using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //flujos de datos de entrada y salida

namespace ManejoDeArchvos
{
    public partial class Form1 : Form
    {
        static StreamWriter sw; //escritura
        static StreamReader sr; //lectura

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            //string nombre = "texto.txt";
            string nombre = txtNombre.Text + ".txt";
            string direccion = @"C:\\Archivo\\"; // @ referencia a una direccion

            if (txtNombre.Text == "")
                MessageBox.Show("Escriba el nombre del archivo");
            else
            {
                if (File.Exists(direccion + nombre))
                {
                    MessageBox.Show("Si existe el archivo");
                    //sw = File.AppendText(direccion + nombre); //anexa el archivo a la direccion
                    sw = File.CreateText(direccion + nombre);
                    sw.WriteLine(txtDato.Text);
                    sw.Close();
                }
                else
                {
                    MessageBox.Show("El archivo no existe");
                    sw = File.CreateText(direccion + nombre); //crea el archivo
                    sw.WriteLine(txtDato.Text);
                    sw.Close();
                }
            }
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text + ".txt";
            string direccion = @"C:\\Archivo\\";

            sr = new StreamReader(direccion + nombre); //busca el archivo
            string linea;

            linea = sr.ReadToEnd(); //lee el archivo hasta al final
            txtDato.Text = linea;
            sr.Close();
        }
    }
}
