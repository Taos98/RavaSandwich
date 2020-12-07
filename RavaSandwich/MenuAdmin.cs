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
            this.Close();
        }

        private void btnAgregarPersonal_Click(object sender, EventArgs e)
        {
            GestionarPersonal gp = new GestionarPersonal();
            gp.Show();
            this.Close();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Ventas ve = new Ventas();
            ve.Show();
            this.Close();
        }
    }
}
