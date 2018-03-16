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
using System.IO;

namespace APV
{
    public partial class Ventas : Form
    {
        conexion CN = new conexion();
        public string n = "";
        public string t = "";

        public Ventas(string nombre, string tipo)
        {
            InitializeComponent();
            n = nombre;
            t = tipo;
            txtVendedor.Text = n;
        }

        public void descontarProducto()
        {
            int actual = 0;
            int resta = 0;
            int nuevo = 0;

            try
            {
                CN.abrir();
                CN.consulta("SELECT existencia FROM inventario WHERE producto = '"+cmbProducto.Text+"';");

                while (CN.dr.Read())
                {
                    actual = Convert.ToInt32(CN.dr["existencia"]);
                }

                if (actual > 1)
                {
                    nuevo = Convert.ToInt32(txtCantidad.Text);
                    resta = actual - nuevo;
                }
                else if (actual == 3)
                {
                    MessageBox.Show("El producto: " +cmbProducto.Text+ "esta por terminarse!");
                }
                CN.cerrar();

                CN.abrir();
                CN.movimientos("UPDATE inventario SET existencia = '" + resta + "' WHERE producto = '" + cmbProducto.Text + "';");
                CN.cerrar();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        public void ticket()
        {
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
                                txtVenta.Text = arreglo[1];
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
            else
            {
                using (FileStream flujo_archivo = new FileStream(direccion + nombre, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (StreamWriter escritor = new StreamWriter(flujo_archivo))
                    {
                        escritor.WriteLine("#Venta: 1");
                        txtVenta.Text = "1";
                    }
                }
            }
        }

        public void generarTicket()
        {
            string nombre = "venta.txt";
            string direccion = @"C:\\Archivo\\";

            if (File.Exists(direccion + nombre))
            {
                using (FileStream flujo_archivo = new FileStream(direccion + nombre, FileMode.Append, FileAccess.Write, FileShare.None))
                {
                    using (StreamWriter escritor = new StreamWriter(flujo_archivo))
                    {
                        int num = Convert.ToInt32(txtVenta.Text);
                        int nuevo = num + 1;

                        escritor.WriteLine("Fecha: " + dtpFecha.Text);
                        escritor.WriteLine("Total: $ " + txtTotal.Text);
                        escritor.WriteLine("#Venta: " + nuevo);
                        txtVenta.Text = nuevo.ToString();
                        MessageBox.Show("Gracias por su compra :)");
                    }
                }
            }
        }

        private void regresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(n, t);
            menu.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void cargarVentas(DataGridView dgv)
        {
            try
            {
                string consulta = "SELECT producto, cantidad, precio, total FROM ventas WHERE venta = '"+txtVenta.Text+"'";
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, CN.cn);
                DataSet ds = new DataSet();
                da.Fill(ds, "ventas");
                dgv.DataSource = ds.Tables["ventas"];

                int suma = 0;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    suma += Convert.ToInt32(dgv.Rows[i].Cells[3].Value);
                }

                txtTotal.Text = suma.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void llenarProducto(ComboBox cmb)
        {
            try
            {
                CN.abrir();
                CN.consulta("SELECT producto FROM inventario");

                while (CN.dr.Read())
                {
                    cmb.Items.Add((string)CN.dr["producto"]);
                }
                CN.cerrar();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            cargarVentas(dgvVentas);
            llenarProducto(cmbProducto);
            ticket();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CN.abrir();
                CN.consulta("SELECT * FROM inventario WHERE producto = '" + cmbProducto.Text + "';");

                while (CN.dr.Read())
                {
                    txtPrecio.Text = Convert.ToString(CN.dr["precio"]);
                }
                CN.cerrar();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            txtCantidad.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "" && cmbProducto.Text != "")
            {
                int precio, cantidad, total;
                precio = Convert.ToInt32(txtPrecio.Text);
                cantidad = Convert.ToInt32(txtCantidad.Text);

                total = cantidad * precio;
                total.ToString();
                try
                {
                    CN.abrir();
                    CN.movimientos("INSERT INTO ventas VALUES(null, '"+txtVendedor.Text+"', '"+txtVenta.Text+"', '"+dtpFecha.Text+"', '"+cmbProducto.Text+"', '"+txtCantidad.Text+"', '"+txtPrecio.Text+"', '"+total+"');");
                    CN.cerrar();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.ToString());
                }
                cargarVentas(dgvVentas);
                descontarProducto();
                txtCantidad.Clear();
                btnCerrar_venta.Enabled = true;
            }
            else
            {
                MessageBox.Show("Seleccione el producto e ingrese la cantidad.");
            }
        }

        private void btnCerrar_venta_Click(object sender, EventArgs e)
        {
            generarTicket();
            cargarVentas(dgvVentas);
            btnCerrar_venta.Enabled = false;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void cmbProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
