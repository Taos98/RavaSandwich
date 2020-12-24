using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RavaSandwich
{
    public partial class Caja : Form
    {
        public Caja()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            //Se crea un objeto login para obtener el rol
            Login l = new Login();
            //Si la persona que inició sesión es un usuario, se despliega el menú principal del usuario, en caso de que sea administrador, se desplegará el menú principal del administrador.
            if (l.getRol() == "usuario")
            {
                MenuUsuario mu = new MenuUsuario();
                mu.Show();
                this.Close();
            }
            else if (l.getRol() == "administrador")
            {
                MenuAdmin ma = new MenuAdmin();
                ma.Show();
                this.Close();
            }

        }

        private void btnBillete_Click(object sender, EventArgs e)
        {
            CajaBilletes cb = new CajaBilletes();
            cb.Show();
            this.Close();
        }

        private void btnSueldos_Click(object sender, EventArgs e)
        {
            CajaSueldos cs = new CajaSueldos();
            cs.Show();
            this.Close();
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            CajaGastos cg = new CajaGastos();
            cg.Show();
            this.Close();
        }
    }
    }
}
