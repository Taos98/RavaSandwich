using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RavaSandwich
{
    public partial class CajaGastos : Form
    {
        public static String detalleG = "";
        public static int totalG = 0;
        static int numCasilleros = 0;
        public CajaGastos()
        {
            InitializeComponent();
            //Ocultar los ultimos 3 campos de gastos
            txtDescripcion4.Visible = false;
            txtMonto4.Visible = false;
            txtDescripcion5.Visible = false;
            txtMonto5.Visible = false;
            txtDescripcion6.Visible = false;
            txtMonto6.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Guarda la descripción del gasto con el monto
            if (txtDescripcion1.Text != "" && txtMonto1.Text != "")
            {
                if (txtDescripcion1.Text != "" && txtMonto1.Text != "")
                {
                    detalleG = detalleG + "Descripcion 1: " + txtDescripcion1.Text + ", Monto: " + txtMonto1.Text;
                    totalG = totalG + int.Parse(txtMonto1.Text);
                }
                if (txtDescripcion2.Text != "" && txtMonto2.Text != "")
                {
                    detalleG = detalleG + "\nDescripcion 2: " + txtDescripcion2.Text + ", Monto: " + txtMonto2.Text;
                    totalG = totalG + int.Parse(txtMonto2.Text);
                }
                if (txtDescripcion3.Text != "" && txtMonto3.Text != "")
                {
                    detalleG = detalleG + "\nDescripcion 3: " + txtDescripcion3.Text + ", Monto: " + txtMonto3.Text;
                    totalG = totalG + int.Parse(txtMonto3.Text);
                }
                if (txtDescripcion4.Text != "" && txtMonto4.Text != "")
                {
                    detalleG = detalleG + "\nDescripcion 4: " + txtDescripcion4.Text + ", Monto: " + txtMonto4.Text;
                    totalG = totalG + int.Parse(txtMonto4.Text);
                }
                if (txtDescripcion5.Text != "" && txtMonto5.Text != "")
                {
                    detalleG = detalleG + "\nDescripcion 5: " + txtDescripcion5.Text + ", Monto: " + txtMonto5.Text;
                    totalG = totalG + int.Parse(txtMonto5.Text);
                }
                if (txtDescripcion6.Text != "" && txtMonto6.Text != "")
                {
                    detalleG = detalleG + "\nDescripcion 6: " + txtDescripcion6.Text + ", Monto: " + txtMonto6.Text;
                    totalG = totalG + int.Parse(txtMonto6.Text);
                }
                MessageBox.Show("Se ha agregado los siguientes gastos: \n" + detalleG + " \nTotal: $" + totalG, "Gastos agregados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //Vuelve a la caja
                Caja ca = new Caja();
                ca.Show();
                //Se restablece el numero de casilleros extra a mostrar para que después se puedan volver a mostrar con el boton (+) Agregar gasto
                numCasilleros = 0;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese los datos solicitados", "Casillero vacío", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        //Obtiene el total (suma) de los gastos ingresados para que puedan ser utilizados en otra clase
        public int getTotalGastos()
        {
            return totalG;
        }
        //Obtiene las descripciones de los gastos ingresados para que puedan ser utilizados en otra clase
        public String getDescripcionGastos()
        {
            return detalleG;
        }

        private void btnAgregarGasto_Click(object sender, EventArgs e)
        {
            //Muestra más casilleros adicionales
            numCasilleros++;
            if (numCasilleros == 1)
            {
                txtDescripcion4.Visible = true;
                txtMonto4.Visible = true;
            }
            if (numCasilleros == 2)
            {
                txtDescripcion5.Visible = true;
                txtMonto5.Visible = true;
            }
            if (numCasilleros == 3)
            {
                txtDescripcion6.Visible = true;
                txtMonto6.Visible = true;
            }


        }
    }
}
