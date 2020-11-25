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
    public partial class AgregarUsuario : Form
    {
        public AgregarUsuario()
        {
            InitializeComponent();
            comboRol.Items.Add("administrador");
            comboRol.Items.Add("usuario");
            //txtRut.PlaceholderText = "11222333-k";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Pregunta si no hay datos nulos en los datos solicitados (Lista de productos)
            if ((comboRol.SelectedItem != null && txtNombre.Text != null && txtRut.Text != null && txtContrasenia.Text != null && txtTelefono.Text !=null && txtCorreo.Text != null && txtDireccion.Text!= null))
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
                //Actualiza el producto
                comm.CommandText = "INSERT into usuarios VALUES ('" + txtRut.Text + "','" + txtNombre.Text + "', '" + txtContrasenia.Text + "','" + comboRol.SelectedItem + "','"+txtTelefono.Text+"', '"+txtCorreo.Text+"', '"+txtDireccion.Text+"')";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                MessageBox.Show("Se ha agregado el usuario " + txtNombre.Text + " de manera Exitosa", "Se agregó un nuevo usuario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
                GestionarPersonal gp = new GestionarPersonal();
                gp.Show();
                this.Close();

            }
            else //En caso de que esté seleccionado un valor nulo
            {
                MessageBox.Show("Por favor, llene los campos solicitados ", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtRut_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            GestionarPersonal gp = new GestionarPersonal();
            gp.Show();
            this.Close();
        }
    }
}
