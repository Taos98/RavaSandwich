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
    public partial class HistorialVentas : Form
    {
        public HistorialVentas()
        {
            InitializeComponent();
            llenarTabla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void llenarTabla()
        {
            String fecha = DateTime.Now.ToString("d");
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
            comm.CommandText = "SELECT * from vista_ventas where \"fecha\" like '"+fecha+"%' ORDER BY \"fecha\" ASC";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)//Si la tabla tiene 1 o más filas...
            {
                //Crear objeto referente a la tabla
                DataTable dt = new DataTable();
                //Cargar Tabla
                dt.Load(dr);
                //Mostrar tabla
                tablaVentas.DataSource = dt;
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
           
        }

        private void btnVerTodo_Click(object sender, EventArgs e)
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
            comm.CommandText = "SELECT * from vista_ventas ORDER BY \"fecha\" ASC";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)//Si la tabla tiene 1 o más filas...
            {
                //Crear objeto referente a la tabla
                DataTable dt = new DataTable();
                //Cargar Tabla
                dt.Load(dr);
                //Mostrar tabla
                tablaVentas.DataSource = dt;
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
        }

        private void btnVentasHoy_Click(object sender, EventArgs e)
        {
            llenarTabla();
        }
    }
}
