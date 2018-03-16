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

namespace ManejoDe_Archivos2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnArchivo_Click(object sender, EventArgs e)
        {
            string n = txtNombre.Text + ".txt";
            string d = @"C:\\Archivo\\";

            if (txtNombre.Text == "")
                MessageBox.Show("Escriba un nombre");
            else
            {
                if (File.Exists(d + n))
                {
                    //Si existe el archivo
                    //Append anexa el archivo a la direccion
                    //Write escribe sobre el arcgivo existente
                    using (FileStream flujo_archivo = new FileStream(d + n, FileMode.Append, FileAccess.Write, FileShare.None))
                    {
                        using (StreamWriter escritor = new StreamWriter(flujo_archivo))
                        {
                            escritor.WriteLine(txtDato.Text);
                        }
                    }
                }
                else
                {
                    //El archivo no existe, lo va crear
                    using (FileStream flujo_archivo = new FileStream(d + n, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        using (StreamWriter escritor = new StreamWriter(flujo_archivo))
                        {
                            escritor.WriteLine(txtDato.Text);
                        }
                    }
                }
            }
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            string n = txtNombre.Text + ".txt";
            string d = @"C:\\Archivo\\";

            if (File.Exists(d + n))
            {
                //Abre el archivo para leer
                using (FileStream flujo_archivo = new FileStream(d + n, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    using (StreamReader lector = new StreamReader(flujo_archivo))
                    {
                        txtDato.Text = lector.ReadToEnd();
                    }
                }
            }
            else
            {
                MessageBox.Show("El archivo no existe");
            }
        }
    }
}
