using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RavaSandwich
{
    public partial class ConfirmarPedido : Form
    {
        public ConfirmarPedido()
        {
            InitializeComponent();
            Login lo = new Login();
            Ventas ve = new Ventas();
            labelNombreCajero.Text = lo.getNombre();
            textBoxTotalAPagar.Text = ve.getTotal()+"";
            checkBoxPYEfectivo.Visible = false;
            checkBoxPYDescuentos.Visible = false;
            checkBoxPYOnline.Visible = false;
            textBoxDescuento.Visible = false;
            labelIndicarDescto.Visible = false;
            String[] pedido = ve.getPedidoCliente().Split("\n");
            for(int i = 0; i<pedido.Length-1; i++)
            {
                listBoxPedido.Items.Add(pedido[i]);
            }

        }

        private void checkBoxPedidosYa_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPedidosYa.Checked == true)
            {
                checkBoxPYEfectivo.Visible = true;
                checkBoxPYDescuentos.Visible = true;
                checkBoxPYOnline.Visible = true;
                textBoxDescuento.Visible = true;
                labelIndicarDescto.Visible = true;
            }
            else
            {
                checkBoxPYEfectivo.Visible = false;
                checkBoxPYDescuentos.Visible = false;
                checkBoxPYOnline.Visible = false;
                textBoxDescuento.Visible = false;
                labelIndicarDescto.Visible = false;
            }
        }

        private void checkBoxPYDescuentos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPYDescuentos.Checked == true)
            {
                textBoxDescuento.Visible = true;
                labelIndicarDescto.Visible = true;
            }
            else
            {
                textBoxDescuento.Visible = false;
                labelIndicarDescto.Visible = false;
            }
        }
    }
}
