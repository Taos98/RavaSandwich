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
            Login l = new Login();
            labelNombre.Text = l.getNombre();//Carga el nombre de la persona que inicio sesión
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

        private void MenuAdmin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            Caja ca = new Caja();
            ca.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gestionar_Turno gt = new Gestionar_Turno();
            gt.Show();
            
        }
    }
}
