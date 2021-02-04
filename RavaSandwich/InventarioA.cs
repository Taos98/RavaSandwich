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
    public partial class InventarioA : Form
    {
        public InventarioA()
        {
            InitializeComponent();
            llenarTabla();//Carga de inmediato la tabla de inventario
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuAdmin menu = new MenuAdmin();
            menu.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            //Abre un formulario de ingreso, ademas evita que se abran varios form del mismo
            IngresoIngredi ing = new IngresoIngredi();
            if(Application.OpenForms[ing.Name] == null)
            {
                ing.Show();
            }
            else
            {
                Application.OpenForms[ing.Name].Activate();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Actualiza la tabla de inventario con los valores actuales
            llenarTabla();
        }

        private void btnConsumo_Click(object sender, EventArgs e)
        {
            ConsumirProd con = new ConsumirProd();
            //verifica si ya hay una ventana existente
            if (Application.OpenForms[con.Name] == null)
            {
                //abre una nueva
                con.Show();
            }
            else
            {
                //sobreexpone la ventana activa
                Application.OpenForms[con.Name].Activate();
            }
            
        }
        private void llenarTabla()
        {
            //Datos de conexión a BD
            NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; Port = 5432; User Id = postgres; Password = TomiMati2005; Database = Rava");
            //Abrir BD
            conn.Open();
            //Crear objeto de comandos
            NpgsqlCommand comm = new NpgsqlCommand();
            //Crear objeto conexión
            comm.Connection = conn;
            //No se que hace xd
            comm.CommandType = CommandType.Text;
            //Consulta
            comm.CommandText = "SELECT * from vista_inventario_full ORDER BY \"Nombre\" ASC";
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

        private void btnAgregarI_Click(object sender, EventArgs e)
        {
            AgregarProducto ag = new AgregarProducto();
            //verifica si ya hay una ventana existente
            if (Application.OpenForms[ag.Name] == null)
            {
                ag.Show();
            }
            else
            {
                Application.OpenForms[ag.Name].Activate();
            }
        }

        private void btnEliminarI_Click(object sender, EventArgs e)
        {
            EliminarProducto el = new EliminarProducto();
            //verifica si ya hay una ventana existente
            if (Application.OpenForms[el.Name] == null)
            {
                el.Show();
            }
            else
            {
                Application.OpenForms[el.Name].Activate();
            }
        }
    }
}
