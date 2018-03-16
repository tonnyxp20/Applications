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
using iTextSharp.text.xml;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace RANITAS
{
    public partial class Reportes : Form
    {
        conexion CN = new conexion();
        int op = 0;
        string consulta = "";
        public MySqlDataAdapter da;
        public DataSet ds;
        string total = "";

        public Reportes()
        {
            InitializeComponent();
            timer1.Start();
        }

        public void GenerarDocumento(Document docu)
        {
            PdfPTable tabla = new PdfPTable(dg1.ColumnCount);
            tabla.DefaultCell.Padding = 3;
            float[] header = GetTamañoColumnas(dg1);
            tabla.SetWidths(header);
            tabla.WidthPercentage = 100;
            tabla.DefaultCell.BorderWidth = 1; 
            tabla.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            for (int i = 0; i < dg1.ColumnCount; i++)
            {
                tabla.AddCell(dg1.Columns[i].HeaderText);
            }

            tabla.HeaderRows = 0;
            tabla.DefaultCell.BorderWidth = 1;

            for (int y = 0; y < dg1.RowCount; y++)
            {
                for (int x = 0; x < dg1.ColumnCount; x++)
                {
                    tabla.AddCell(dg1[x, y].Value.ToString());
                }
                tabla.CompleteRow();
            }
            docu.Add(tabla); 
        }

        public float[] GetTamañoColumnas(DataGridView dg)
        {
            float[] valores = new float[dg.ColumnCount];

            for (int i = 0; i < dg.ColumnCount; i++)
            {
                valores[i] = (float)dg.Columns[i].Width;
            }
            return valores;
        }

        private void btnImpirmir_Click(object sender, EventArgs e)
        {
            Chunk x, n;
            Document doc = new Document(PageSize.LETTER, 30, 30, 20, 20);
            x = new Chunk(" ", FontFactory.GetFont("ARIAL", 12));
            n = new Chunk("RANITAS.COM", FontFactory.GetFont("ARIAL", 18, BaseColor.GREEN));

            DateTime dt = DateTime.Now;
            string fecha = dt.ToShortDateString();

            try
            {
                if (rdbFecha.Checked == true)
                {
                    string nombre_archivo = @"C:\\Archivo\\" + rdbFecha.Text + ".pdf";
                    FileStream arch = new FileStream(nombre_archivo, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                    PdfWriter.GetInstance(doc, arch);
                    doc.Open();
                    doc.Add(new Paragraph(n) { Alignment = Element.ALIGN_CENTER });
                    doc.Add(new Paragraph(x));
                    doc.Add(new Paragraph("Reporte por " + rdbFecha.Text + " del dia " + dtpFecha1.Text + " hasta el dia " + dtpFecha2.Text));
                    doc.Add(new Paragraph(""));
                    doc.Add(new Paragraph(x));
                    GenerarDocumento(doc);
                    doc.Add(new Paragraph(x));
                    doc.Add(new Paragraph("Total: " + total) { Alignment = Element.ALIGN_RIGHT });
                    Process.Start(nombre_archivo);
                }
                if(rdbCajero.Checked == true)
                {
                    string nombre_archivo = @"C:\\Archivo\\" + rdbCajero.Text + cmbDatos.Text + ".pdf";
                    FileStream arch = new FileStream(nombre_archivo, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                    PdfWriter.GetInstance(doc, arch);
                    doc.Open();
                    doc.Add(new Paragraph(n) { Alignment = Element.ALIGN_CENTER });
                    doc.Add(new Paragraph(x));
                    doc.Add(new Paragraph("Reporte por " + rdbCajero.Text + " " + cmbDatos.Text));
                    doc.Add(new Paragraph("Fecha: " + fecha) { Alignment = Element.ALIGN_RIGHT });
                    doc.Add(new Paragraph(""));
                    doc.Add(new Paragraph(x));
                    GenerarDocumento(doc);
                    doc.Add(new Paragraph(x));
                    doc.Add(new Paragraph("Total: " + total) { Alignment = Element.ALIGN_RIGHT });
                    Process.Start(nombre_archivo);
                }
                if(rdbEquipo.Checked == true)
                {
                    string nombre_archivo = @"C:\\Archivo\\" + rdbEquipo.Text + cmbDatos.Text + ".pdf";
                    FileStream arch = new FileStream(nombre_archivo, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                    PdfWriter.GetInstance(doc, arch);
                    doc.Open();
                    doc.Add(new Paragraph(n) { Alignment = Element.ALIGN_CENTER });
                    doc.Add(new Paragraph(x));
                    doc.Add(new Paragraph("Reporte por " + rdbEquipo.Text + " " + cmbDatos.Text));
                    doc.Add(new Paragraph("Fecha: " + fecha) { Alignment = Element.ALIGN_RIGHT });
                    doc.Add(new Paragraph(""));
                    doc.Add(new Paragraph(x));
                    GenerarDocumento(doc);
                    doc.Add(new Paragraph(x));
                    doc.Add(new Paragraph("Total: " + total) { Alignment = Element.ALIGN_RIGHT });
                    Process.Start(nombre_archivo);
                }
            }
            catch (Exception xx)
            {
                MessageBox.Show(xx.ToString());
            }
            doc.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            switch (op)
            {
                case 1:
                    consulta = "SELECT fecha, cajero, equipo, tiempo, costo FROM uso WHERE fecha >= '" + dtpFecha1.Text + "' AND fecha <= '" + dtpFecha2.Text + "';";
                    da = new MySqlDataAdapter(consulta, CN.cn);
                    ds = new DataSet();
                    da.Fill(ds, "uso");
                    dg1.DataSource = ds.Tables["uso"];

                    int suma = 0;
                    for (int i = 0; i < dg1.Rows.Count; i++)
                    {
                        suma += Convert.ToInt32(dg1.Rows[i].Cells[4].Value);
                    }

                    total = suma.ToString();
                    break;

                case 2:
                    consulta = "SELECT fecha, cajero, equipo, tiempo, costo  FROM uso WHERE cajero = '" + cmbDatos.Text+"';";
                    da = new MySqlDataAdapter(consulta, CN.cn);
                    ds = new DataSet();
                    da.Fill(ds, "uso");
                    dg1.DataSource = ds.Tables["uso"];

                    int suma1 = 0;
                    for (int i = 0; i < dg1.Rows.Count; i++)
                    {
                        suma1 += Convert.ToInt32(dg1.Rows[i].Cells[4].Value);
                    }

                    total = suma1.ToString();
                    break;

                case 3:
                    consulta = "SELECT fecha, cajero, equipo, tiempo, costo  FROM uso WHERE equipo = '" + cmbDatos.Text+"';";
                    da = new MySqlDataAdapter(consulta, CN.cn);
                    ds = new DataSet();
                    da.Fill(ds, "uso");
                    dg1.DataSource = ds.Tables["uso"];

                    int suma2 = 0;
                    for (int i = 0; i < dg1.Rows.Count; i++)
                    {
                        suma2 += Convert.ToInt32(dg1.Rows[i].Cells[4].Value);
                    }

                    total = suma2.ToString();
                    break;
            }
        }

        private void rdbFecha_CheckedChanged(object sender, EventArgs e)
        {
            op = 1;

            dtpFecha1.Visible = true;
            dtpFecha2.Visible = true;
            lblDato1.Visible = true;
            lblDato2.Visible = true;

            lblDato1.Text = "Del dia:";
            lblDato2.Text = "hasta el dia:";

            cmbDatos.Visible = false;
        }

        private void rdbCajeros_CheckedChanged(object sender, EventArgs e)
        {
            op = 2;
            lblDato1.Text = "Cajero:";
            lblDato1.Visible = true;
            cmbDatos.Visible = true;

            lblDato2.Visible = false;
            dtpFecha1.Visible = false;
            dtpFecha2.Visible = false;
            cmbDatos.Items.Clear();

            try
            {
                CN.abrir();
                CN.consulta("SELECT usuario FROM usuarios;");

                while (CN.dr.Read())
                {
                    cmbDatos.Items.Add(Convert.ToString(CN.dr["usuario"]));
                }
                cmbDatos.SelectedIndex = 0;
                CN.cerrar();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            lblDato1.Visible = false;
            lblDato2.Visible = false;
            cmbDatos.Visible = false;
            dtpFecha1.Visible = false;
            dtpFecha2.Visible = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Panel pane = new Panel();
            pane.Show();
            this.Hide();
        }

        private void rdbEquipo_CheckedChanged(object sender, EventArgs e)
        {
            op = 3;
            lblDato1.Text = "Equipo:";
            lblDato1.Visible = true;
            cmbDatos.Visible = true;

            lblDato2.Visible = false;
            dtpFecha1.Visible = false;
            dtpFecha2.Visible = false;
            cmbDatos.Items.Clear();

            try
            {
                CN.abrir();
                CN.consulta("SELECT nEquipo FROM equipos;");

                while (CN.dr.Read())
                {
                    cmbDatos.Items.Add(Convert.ToString(CN.dr["nEquipo"]));
                }
                cmbDatos.SelectedIndex = 0;
                CN.cerrar();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                CN.abrir();
                //si hay conexion
                btnBuscar.Enabled = true;
                btnImpirmir.Enabled = true;
                CN.cerrar();
            }
            catch (Exception)
            {
                btnBuscar.Enabled = false;
                btnImpirmir.Enabled = false;
                CN.cerrar();
            }
        }
    }
}
