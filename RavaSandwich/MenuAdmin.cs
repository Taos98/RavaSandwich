using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace RavaSandwich
{
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            InventarioA inv = new InventarioA();
            inv.Show();
        }
    }
}
