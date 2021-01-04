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
    public partial class Caja : Form
    {
        public Caja()
        {
            InitializeComponent();
            //Fecha actual:
            String fecha = DateTime.Now.ToString("d");

            //Datos de conexión a BD
            NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; Port = 5432; User Id = postgres; Password = censurado; Database = Rava_Sandwich");
            //Abrir BD
            conn.Open();
            //Crear objeto de comandos
            NpgsqlCommand comm = new NpgsqlCommand();
            //Crear objeto conexión
            comm.Connection = conn;
            //No se que hace xd
            comm.CommandType = CommandType.Text;
            //Consulta
            comm.CommandText = "SELECT metodo_pago, total_a_pagar, fecha_venta from ventas";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())//Si la tabla tiene 1 o más filas...
            {
                if (dr.GetString(2).Contains(fecha))
                {
                    listVentas.Items.Add("-" + dr.GetString(0) + "  " + dr.GetInt16(1));
                }
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
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
            
        }

        private void btnSueldos_Click(object sender, EventArgs e)
        {
            CajaSueldos cs = new CajaSueldos();
            cs.Show();
            
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            CajaGastos cg = new CajaGastos();
            cg.Show();
           
        }

        private void btnCerrarTurno_Click(object sender, EventArgs e)
        {
            CerrarTurno ct = new CerrarTurno();
            ct.Show();
            this.Close();
        }
    }
}
