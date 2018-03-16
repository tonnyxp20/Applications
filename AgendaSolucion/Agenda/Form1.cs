using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Agenda
{
    public partial class Form1 : Form
    {
        int count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnArchivo_Click(object sender, EventArgs e)
        {
            string nombre = "agenda.txt";
            string direccion = @"C:\\Archivo\\";

            if (File.Exists(direccion + nombre))
            {
                using (FileStream flujo_archivo = new FileStream(direccion + nombre, FileMode.Append, FileAccess.Write, FileShare.None))
                {
                    using (StreamWriter escritor = new StreamWriter(flujo_archivo))
                    {
                        escritor.WriteLine(txtDato.Text);
                    }
                }
            }
            else
            {
                using (FileStream flujo_archivo = new FileStream(direccion + nombre, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (StreamWriter escritor = new StreamWriter(flujo_archivo))
                    {
                        escritor.WriteLine(txtDato.Text);
                    }
                }
            }
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            string nombre = "agenda.txt";
            string direccion = @"C:\\Archivo\\";

            if (File.Exists(direccion + nombre))
            {
                using (FileStream flujo_archivo = new FileStream(direccion + nombre, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    using (StreamReader lector = new StreamReader(flujo_archivo))
                    {
                        txtDato.Text = lector.ReadToEnd();
                    }
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            string nombre = "agenda.txt";
            string direccion = @"C:\\Archivo\\";

            string[] datos = File.ReadAllLines(direccion + nombre);

            count++;
            txtDato.Text = datos[count];

            btnAtras.Enabled = true;
            if(datos[datos.Length-1] == datos[count])
            {
                btnSiguiente.Enabled = false;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            string nombre = "agenda.txt";
            string direccion = @"C:\\Archivo\\";

            string[] datos = File.ReadAllLines(direccion + nombre);

            count--;
            txtDato.Text = datos[count];

            btnSiguiente.Enabled = true;
            if (datos[0] == datos[count])
            {
                btnAtras.Enabled = false;
            }
        }
    }
}
