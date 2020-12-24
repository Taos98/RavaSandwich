using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RavaSandwich
{
    public partial class CajaBilletes : Form
    {
        public CajaBilletes()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Caja ca = new Caja();
            ca.Show();
            this.Close();
        }
    }
}
