using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtPantalla.Enabled = false;
        }

        double n1 = 0;
        double n2 = 0;
        int op = 0;
        double R = 0;
        bool punto = true;

        private void btnUno_Click(object sender, EventArgs e)
        {

            if (punto == true)
            {
                txtPantalla.Text = "0.";
                txtPantalla.Text = "1.";
                punto = false;
            }
            else
            {
                txtPantalla.Text = txtPantalla.Text + "1.";
            }
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            if (txtPantalla.Text == "0.")
            {
                txtPantalla.Text = "2.";
            }
            else
            {
                txtPantalla.Text = txtPantalla.Text + "2.";
            }
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            if (txtPantalla.Text == "0.")
            {
                txtPantalla.Text = "3.";
            }
            else
            {
                txtPantalla.Text = txtPantalla.Text + "3.";
            }
        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            if (txtPantalla.Text == "0.")
            {
                txtPantalla.Text = "4.";
            }
            else
            {
                txtPantalla.Text = txtPantalla.Text + "4.";
            }
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            if (txtPantalla.Text == "0.")
            {
                txtPantalla.Text = "5."; //sustituir
            }
            else
            {
                txtPantalla.Text = txtPantalla.Text + "5."; //concatenar
                //borrar .
            }
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            if (txtPantalla.Text == "0.")
            {
                txtPantalla.Text = "6.";
            }
            else
            {
                txtPantalla.Text = txtPantalla.Text + "6.";
            }
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            if (txtPantalla.Text == "0.")
            {
                txtPantalla.Text = "7.";
            }
            else
            {
                txtPantalla.Text = txtPantalla.Text + "7.";
            }
        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            if (txtPantalla.Text == "0.")
            {
                txtPantalla.Text = "8.";
            }
            else
            {
                txtPantalla.Text = txtPantalla.Text + "8.";
            }
        }

        private void btnNueve_Click(object sender, EventArgs e)
        {
            if (txtPantalla.Text == "0.")
            {
                txtPantalla.Text = "9.";
            }
            else
            {
                txtPantalla.Text = txtPantalla.Text + "9.";
            }
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            /*if (txtResult.Text.Contains('.') == false)
            {
                this.txtResult.Text = this.txtResult.Text + ".";
            }
            else()
            {

            }*/

        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            n1 = Convert.ToDouble(txtPantalla.Text);
            op = 1;
            txtPantalla.Clear();
            
            /*if(op!=0)
            {

            }
            else
            {
                if (op == 1)
                {

                }
            }*/

        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            n1 = Convert.ToDouble(txtPantalla.Text);
            op = 2;
            txtPantalla.Clear();
            txtPantalla.Focus();
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            n1 = Convert.ToDouble(txtPantalla.Text);
            op = 3;
            txtPantalla.Clear();
            txtPantalla.Focus();
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            n1 = Convert.ToDouble(txtPantalla.Text);
            op = 4;
            txtPantalla.Clear();
            txtPantalla.Focus();
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            n2 = Convert.ToDouble(txtPantalla.Text);

            switch (op)
            {
                case 1:
                    R = n1 + n2;
                    break;

                case 2:
                    R = n1 - n2;
                    break;

                case 3:
                    R = n1 * n2;
                    break;

                case 4:
                    R = n1 / n2;
                    break;
            }

            txtPantalla.Text = R.ToString();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtPantalla.Clear();
            txtPantalla.Text = "0.";
        }

        private void btnCero_Click(object sender, EventArgs e)
        {
            if (txtPantalla.Text == "0.")
            {
                txtPantalla.Text = "0.";
            }
            else
            {
                txtPantalla.Text = txtPantalla.Text + "0.";
            }
        }

    }
}
