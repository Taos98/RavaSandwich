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
    public partial class GestionarPersonal : Form
    {
        public GestionarPersonal()
        {
            InitializeComponent();
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
            comm.CommandText = "SELECT nombre from usuarios ORDER BY nombre ASC";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())//Si la tabla tiene 1 o más filas...
            {
                //Rellena la lista desplegable
                boxPersonal.Items.Add(dr.GetString(0));
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void boxPersonal_SelectedIndexChanged(object sender, EventArgs e)
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
            comm.CommandText = "SELECT nombre, rut, telefono, correo, direccion from usuarios where nombre ='"+boxPersonal.SelectedItem.ToString()+"'";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            dr.Read();//Si la tabla tiene 1 o más filas...
            
               //Rellena la lista desplegable
           
            txtNombre.Text = dr.GetString(0);
            txtRut.Text = dr.GetString(1);
            txtTelefono.Text = dr.GetString(2);
            txtCorreo.Text = dr.GetString(3);
            txtDireccion.Text = dr.GetString(4);
            
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
        }

        private void GestionarPersonal_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            MenuAdmin ma = new MenuAdmin();
            ma.Show();
            this.Close();
        }
    }
}
