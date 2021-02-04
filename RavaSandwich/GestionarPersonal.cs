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
            //Carga el combobox con los nombre de todos los usuarios

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
            //Al seleccionar un nombre del combobox se carga los detalles de sus datos personales.

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
            //Consulta de los datos que se van a extraer
            comm.CommandText = "SELECT nombre, rut, telefono, correo, direccion from usuarios where nombre ='"+boxPersonal.SelectedItem.ToString()+"'";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            dr.Read();//Se lee 1 fila nomas
            
            
           //Rellena los textBox con los datos solicitados
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Pregunta si no se seleccionó un valor nulo en el comboBox (Lista de productos)
            if (boxPersonal.SelectedItem != null)
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
                //Elimina el usuario seleccionado de la base de datos
                comm.CommandText = "DELETE FROM usuarios where nombre = '" + boxPersonal.SelectedItem.ToString() + "'";
                DialogResult dia = MessageBox.Show("Desea eliminar el usuario " + boxPersonal.SelectedItem.ToString() + "?", "Eliminar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (dia == DialogResult.Yes)
                {
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    MessageBox.Show("Se ha eliminado el usuario " + boxPersonal.SelectedItem.ToString() + " de manera Exitosa", "Usuario Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                    GestionarPersonal ma = new GestionarPersonal();
                    ma.Show();
                    this.Close();
                }
                else
                {
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                }
            }
            else //En caso de que esté seleccionado un valor nulo
            {
                MessageBox.Show("Se ha cancelado la Eliminación ", "Eliminación Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Invoca un formulario que agrega un nuevo usuario
            AgregarUsuario au = new AgregarUsuario();
            if (Application.OpenForms[au.Name] == null)
            {
                au.Show();
                this.Close();
            }
            else
            {
                Application.OpenForms[au.Name].Activate();
            }
        }
        
    }
}
