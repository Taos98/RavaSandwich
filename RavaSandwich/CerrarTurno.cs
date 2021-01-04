using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RavaSandwich
{
    public partial class CerrarTurno : Form
    {
        public CerrarTurno()
        {
            InitializeComponent();
            //Carga los valores guardados de los otros form
            CajaBilletes cb = new CajaBilletes();
            txtDineroFisico.Text = cb.getTotal()+"";

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }
    }
}
