using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.Diagnostics;

namespace APV
{
    public partial class Reportes : Form
    {
        conexion CN = new conexion();
        public string n = "";
        public string t = "";
        int op = 0;
        string consulta = "";
        public MySqlDataAdapter da;
        public DataSet ds;
        string total = "";

        public Reportes(string nombre, string tipo)
        {
            InitializeComponent();
            n = nombre;
            t = tipo;
        }

        public void GenerarDocumento(Document docu)
        {
            PdfPTable tabla = new PdfPTable(dgvReportes.ColumnCount);
            tabla.DefaultCell.Padding = 3; //espaciado
            float[] header = GetTamañoColumnas(dgvReportes); //encabezados
            tabla.SetWidths(header); //tamaños del ancho
            tabla.WidthPercentage = 100; //100% del tamaño de la celda
            tabla.DefaultCell.BorderWidth = 1; //celda por celda con borde 1
            tabla.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER; //todo elemento se lee de izquierda a derecha

            //pega celda por celda cada elemento
            for (int i = 0; i < dgvReportes.ColumnCount; i++)
            {
                tabla.AddCell(dgvReportes.Columns[i].HeaderText);
            }

            tabla.HeaderRows = 0;
            tabla.DefaultCell.BorderWidth = 1;
            //renglones
            for (int y = 0; y < dgvReportes.RowCount; y++)
            {
                //columnas
                for (int x = 0; x < dgvReportes.ColumnCount; x++)
                {
                    tabla.AddCell(dgvReportes[x, y].Value.ToString());
                }
                tabla.CompleteRow();
            }
            docu.Add(tabla); //terminar y pegar la tabla
        }

        public float[] GetTamañoColumnas(DataGridView dg)
        {
            float[] valores = new float[dg.ColumnCount]; //numero de columnas

            for (int i = 0; i < dg.ColumnCount; i++)
            {
                valores[i] = (float)dg.Columns[i].Width;
            }
            return valores;
        }

        public void cargarReporte(DataGridView dgv)
        {
            try
            {
                string consulta = "SELECT cajero, venta, fecha, producto FROM ventas";
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, CN.cn);
                DataSet ds = new DataSet();
                da.Fill(ds, "ventas");
                dgv.DataSource = ds.Tables["ventas"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void regresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(t, n);
            menu.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            //cargarReporte(dgvReportes);
            txtArchivo.Enabled = false;
            btnImprimir.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (rdbFecha.Checked == true || rdbNoVenta.Checked == true || rdbProducto.Checked == true || rdbVendedor.Checked == true)
            {
                txtArchivo.Enabled = true;
                btnImprimir.Enabled = true;

                switch (op)
                {
                    case 1:
                        consulta = "SELECT venta, fecha, cajero, producto, cantidad, precio, total FROM ventas WHERE fecha >= '" + dtpFecha0.Text + "' AND fecha <= '" + dtpFecha.Text + "';";
                        da = new MySqlDataAdapter(consulta, CN.cn);
                        ds = new DataSet();
                        da.Fill(ds, "ventas");
                        dgvReportes.DataSource = ds.Tables["ventas"];

                        int suma = 0;
                        for (int i = 0; i < dgvReportes.Rows.Count; i++)
                        {
                            suma += Convert.ToInt32(dgvReportes.Rows[i].Cells[6].Value);
                        }

                        total = suma.ToString();
                        break;

                    case 2:
                        consulta = "SELECT venta, fecha, cajero, producto, cantidad, precio, total FROM ventas WHERE venta = '" + cmbDato1.Text + "';";
                        da = new MySqlDataAdapter(consulta, CN.cn);
                        ds = new DataSet();
                        da.Fill(ds, "ventas");
                        dgvReportes.DataSource = ds.Tables["ventas"];

                        int suma1 = 0;
                        for (int i = 0; i < dgvReportes.Rows.Count; i++)
                        {
                            suma1 += Convert.ToInt32(dgvReportes.Rows[i].Cells[6].Value);
                        }

                        total = suma1.ToString();
                        break;

                    case 3:
                        consulta = "SELECT venta, fecha, cajero, producto, cantidad, precio, total FROM ventas WHERE producto = '" + cmbDato1.Text + "';";
                        da = new MySqlDataAdapter(consulta, CN.cn);
                        ds = new DataSet();
                        da.Fill(ds, "ventas");
                        dgvReportes.DataSource = ds.Tables["ventas"];

                        int suma2 = 0;
                        for (int i = 0; i < dgvReportes.Rows.Count; i++)
                        {
                            suma2 += Convert.ToInt32(dgvReportes.Rows[i].Cells[6].Value);
                        }

                        total = suma2.ToString();
                        break;

                    case 4:
                        consulta = "SELECT venta, fecha, cajero, producto, cantidad, precio, total FROM ventas WHERE cajero = '" + cmbDato1.Text + "';";
                        da = new MySqlDataAdapter(consulta, CN.cn);
                        ds = new DataSet();
                        da.Fill(ds, "ventas");
                        dgvReportes.DataSource = ds.Tables["ventas"];

                        int suma3 = 0;
                        for (int i = 0; i < dgvReportes.Rows.Count; i++)
                        {
                            suma3 += Convert.ToInt32(dgvReportes.Rows[i].Cells[6].Value);
                        }

                        total = suma3.ToString();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Seleccione una opción.");
            }
        }

        private void rdbFecha_CheckedChanged(object sender, EventArgs e)
        {
            op = 1;

            lblDato1.Visible = true;
            cmbDato1.Visible = false;
            lblDato1.Text = "Desde la Fecha:";
            dtpFecha0.Visible = true;

            lblDato2.Visible = true;
            lblDato2.Text = "Hasta la Fecha:";
            dtpFecha.Visible = true;
        }

        private void rdbNoVenta_CheckedChanged(object sender, EventArgs e)
        {
            op = 2;

            lblDato1.Visible = true;
            lblDato1.Text = "Número de venta:";
            cmbDato1.Visible = true;

            lblDato2.Visible = false;
            dtpFecha0.Visible = false;
            dtpFecha.Visible = false;
            cmbDato1.Items.Clear();

            string nombre = "venta.txt";
            string direccion = @"C:\\Archivo\\";
            string[] arreglo = new string[2];
            bool buscar = false;

            if (File.Exists(direccion + nombre))
            {
                using (FileStream flujo_archivo = new FileStream(direccion + nombre, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    using (StreamReader lector = new StreamReader(flujo_archivo))
                    {
                        string separar = lector.ReadLine();
                        while (separar != null && buscar == false)
                        {
                            arreglo = separar.Split(':');
                            if (arreglo[0].Trim().Equals("#Venta") && lector.ReadLine() == null)
                            {
                                int count = Convert.ToInt32(arreglo[1]);
                                for (int i = 0; i < count-1; i++)
                                {
                                    cmbDato1.Items.Add(i+1);
                                }
                                cmbDato1.SelectedIndex = 0;
                                buscar = true;
                            }
                            else
                            {
                                separar = lector.ReadLine();
                            }
                        }
                    }
                }
            }
        }

        private void rdbProducto_CheckedChanged(object sender, EventArgs e)
        {
            op = 3;

            lblDato1.Visible = true;
            lblDato1.Text = "Producto:";
            cmbDato1.Visible = true;

            lblDato2.Visible = false;
            dtpFecha0.Visible = false;
            dtpFecha.Visible = false;
            cmbDato1.Items.Clear();

            try
            {
                CN.abrir();
                CN.consulta("SELECT producto FROM inventario");

                while (CN.dr.Read())
                {
                    cmbDato1.Items.Add(Convert.ToString(CN.dr["producto"]));
                }
                cmbDato1.SelectedIndex = 0;
                CN.cerrar();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void rdbVendedor_CheckedChanged(object sender, EventArgs e)
        {
            op = 4;

            lblDato1.Visible = true;
            lblDato1.Text = "Vendedor:";
            cmbDato1.Visible = true;

            lblDato2.Visible = false;
            dtpFecha0.Visible = false;
            dtpFecha.Visible = false;
            cmbDato1.Items.Clear();

            try
            {
                CN.abrir();
                CN.consulta("SELECT nombre FROM usuarios");

                while (CN.dr.Read())
                {
                    cmbDato1.Items.Add(Convert.ToString(CN.dr["nombre"]));
                }
                cmbDato1.SelectedIndex = 0;
                CN.cerrar();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (txtArchivo.Text != "")
            {
                string nombre_archivo = @"C:\\Archivo\\" + txtArchivo.Text + ".pdf";
                Chunk x; //formato del texto
                Chunk n;
                Document doc = new Document(PageSize.LETTER, 30, 30, 30, 30); //forma del documento
                x = new Chunk(" ", FontFactory.GetFont("Verdana", 12));
                n = new Chunk ("Abarrotes Punto de Venta", FontFactory.GetFont("Verdana", 14, BaseColor.BLUE));

                try
                {

                    DateTime dt = DateTime.Now;
                    string fecha = dt.ToShortDateString();
                    //flujo de archivo
                    FileStream arch = new FileStream(nombre_archivo, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                    PdfWriter.GetInstance(doc, arch);

                    if (rdbFecha.Checked == true)
                    {
                        doc.Open();
                        doc.Add(new Paragraph(n) { Alignment = Element.ALIGN_CENTER });
                        doc.Add(x);
                        doc.Add(new Paragraph("Reporte por " +rdbFecha.Text+ " del dia " +dtpFecha0.Text+ " hasta " + dtpFecha.Text) { Alignment = Element.ALIGN_LEFT });
                        doc.Add(new Paragraph("Fecha: " + fecha) { Alignment = Element.ALIGN_RIGHT });
                        doc.Add(new Paragraph(x));
                        GenerarDocumento(doc);
                        doc.Add(new Paragraph(x));
                        doc.Add(new Paragraph("Subtotal: " + total) { Alignment = Element.ALIGN_RIGHT });
                        Process.Start(nombre_archivo);
                        doc.Close();
                    }
                    else if(rdbNoVenta.Checked == true)
                    {
                        doc.Open();
                        doc.Add(new Paragraph(n) { Alignment = Element.ALIGN_CENTER });
                        doc.Add(x);
                        doc.Add(new Paragraph("Reporte por " + rdbNoVenta.Text + " " + cmbDato1.Text) { Alignment = Element.ALIGN_LEFT });
                        doc.Add(new Paragraph("Fecha: " + fecha) { Alignment = Element.ALIGN_RIGHT });
                        doc.Add(new Paragraph(x));
                        GenerarDocumento(doc);
                        doc.Add(new Paragraph(x));
                        doc.Add(new Paragraph("Subtotal: " + total) { Alignment = Element.ALIGN_RIGHT });
                        Process.Start(nombre_archivo);
                        doc.Close();
                    }
                    else if(rdbProducto.Checked == true)
                    {
                        doc.Open();
                        doc.Add(new Paragraph(n) { Alignment = Element.ALIGN_CENTER });
                        doc.Add(x);
                        doc.Add(new Paragraph("Reporte por " + rdbProducto.Text + " " + cmbDato1.Text) { Alignment = Element.ALIGN_LEFT });
                        doc.Add(new Paragraph("Fecha: " + fecha) { Alignment = Element.ALIGN_RIGHT }); ;
                        doc.Add(new Paragraph(x));
                        GenerarDocumento(doc);
                        doc.Add(new Paragraph(x));
                        doc.Add(new Paragraph("Subtotal: " + total) { Alignment = Element.ALIGN_RIGHT });
                        Process.Start(nombre_archivo);
                        doc.Close();
                    }
                    else if(rdbVendedor.Checked == true)
                    {
                        doc.Open();
                        doc.Add(new Paragraph(n) { Alignment = Element.ALIGN_CENTER });
                        doc.Add(x);
                        doc.Add(new Paragraph("Reporte por " + rdbVendedor.Text + " " + cmbDato1.Text) { Alignment = Element.ALIGN_LEFT });
                        doc.Add(new Paragraph("Fecha: " + fecha) { Alignment = Element.ALIGN_RIGHT }); ;
                        doc.Add(new Paragraph(x));
                        GenerarDocumento(doc);
                        doc.Add(new Paragraph(x));
                        doc.Add(new Paragraph("Subtotal: " + total) { Alignment = Element.ALIGN_RIGHT });
                        Process.Start(nombre_archivo);
                        doc.Close();
                    }
                }
                catch (Exception xx)
                {
                    MessageBox.Show(xx.ToString());
                }
                txtArchivo.Clear();
            }
            else
            {
                MessageBox.Show("Ingrese el nombre del archivo.");
            }
        }

        private void cmbDato1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
