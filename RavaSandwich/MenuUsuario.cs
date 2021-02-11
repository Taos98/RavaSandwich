using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RavaSandwich
{
    public partial class MenuUsuario : Form
    {
        public MenuUsuario()
        {
            InitializeComponent();
            Login l = new Login();
            labelNombre.Text = l.getNombre();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            InventarioU inv = new InventarioU();
            inv.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Ventas ve = new Ventas();
            ve.Show();
            this.Close();
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            Caja ca = new Caja();
            ca.Show();
            this.Close();
        }

        private void btnGestionarTurno_Click(object sender, EventArgs e)
        {
            Gestionar_Turno t = new Gestionar_Turno();
            t.Show();
        }
    }
}
