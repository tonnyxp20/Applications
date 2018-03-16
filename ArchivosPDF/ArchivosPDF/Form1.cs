using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.IO;
using System.Diagnostics;

namespace ArchivosPDF
{
    public partial class Form1 : Form
    {
        conexion CN = new conexion();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLlenar_Click(object sender, EventArgs e)
        {
            try
            {
                string consulta = "SELECT * FROM usuarios";
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, CN.cn);
                DataSet ds = new DataSet();
                da.Fill(ds, "usuarios");
                dgv1.DataSource = ds.Tables["usuarios"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //string txt1 = "a"; 
            //string txt2 = "b"; 
            string nombre_archivo = @"C:\\Users\\Antonio\\Documents\\" +txtArchivo.Text+ ".pdf";
            Chunk x; //formato del texto
            Document doc = new Document(PageSize.LETTER, 30, 30, 20, 20); //forma del documento
            x = new Chunk(" ", FontFactory.GetFont("ARIAL", 12));

            try
            {
                //flujo de archivo
                FileStream arch = new FileStream(nombre_archivo, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                PdfWriter.GetInstance(doc, arch);
                doc.Open();
                doc.Add(new Paragraph("APV Reportes"));
                doc.Add(new Paragraph(""));
                doc.Add(new Paragraph(x));
                GenerarDocumento(doc);
                Process.Start(nombre_archivo);
            }
            catch(Exception xx)
            {
                MessageBox.Show(xx.ToString());
            }
            doc.Close();
        }

        public void GenerarDocumento(Document docu)
        {
            PdfPTable tabla = new PdfPTable(dgv1.ColumnCount);
            tabla.DefaultCell.Padding = 3; //espaciado
            float[] header = GetTamañoColumnas(dgv1); //encabezados
            tabla.SetWidths(header); //tamaños del ancho
            tabla.WidthPercentage = 100; //100% del tamaño de la celda
            tabla.DefaultCell.BorderWidth = 1; //celda por celda con borde 1
            tabla.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT; //todo elemento se lee de izquierda a derecha

            //pega celda por celda cada elemento
            for(int i=0; i < dgv1.ColumnCount; i++)
            {
                tabla.AddCell(dgv1.Columns[i].HeaderText);
            }

            tabla.HeaderRows = 0;
            tabla.DefaultCell.BorderWidth = 1;
            //renglones
            for(int y=0; y < dgv1.RowCount; y++)
            {
                //columnas
                for(int x=0; x < dgv1.ColumnCount; x++)
                {
                    tabla.AddCell(dgv1[x, y].Value.ToString());
                }
                tabla.CompleteRow();
            }
            docu.Add(tabla); //terminar y pegar la tabla
        }

        public float[] GetTamañoColumnas(DataGridView dg)
        {
            float[] valores = new float[dg.ColumnCount]; //numero de columnas

            for(int i=0; i < dg.ColumnCount; i++)
            {
                valores[i] = (float)dg.Columns[i].Width;
            }
            return valores;
        }
    }
}
