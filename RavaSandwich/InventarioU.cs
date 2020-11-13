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
    public partial class InventarioU : Form
    {
        public InventarioU()
        {
            InitializeComponent();
            llenarTabla();
            
        }

        private void Inventario_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            Login lo = new Login();
            lo.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuUsuario menu = new MenuUsuario();
            menu.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            llenarTabla();
        }
        //Metodo para llenar la tabla de BD o actualizar
        private void llenarTabla()
        {
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
            comm.CommandText = "SELECT * from vista_inventario ORDER BY \"Nombre\" ASC";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)//Si la tabla tiene 1 o más filas...
            {
                //Crear objeto referente a la tabla
                DataTable dt = new DataTable();
                //Cargar Tabla
                dt.Load(dr);
                //Mostrar tabla
                tablaInventario.DataSource = dt;
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoIngredi ing = new IngresoIngredi();
            if (Application.OpenForms[ing.Name] == null)
            {
                ing.Show();
            }
            else
            {
                Application.OpenForms[ing.Name].Activate();
            }
        }

        private void btnConsumo_Click(object sender, EventArgs e)
        {
            ConsumirProd con = new ConsumirProd();
            if(Application.OpenForms[con.Name] == null)
            {
                con.Show();
            }
            else
            {
                Application.OpenForms[con.Name].Activate();
            }
        }
    }
}
