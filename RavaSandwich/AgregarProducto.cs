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
    public partial class AgregarProducto : Form
    {
        String fecha = DateTime.Now.ToString("d");
        Login l = new Login();
        public AgregarProducto()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarProducto_Load(object sender, EventArgs e)
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
            comm.CommandText = "SELECT DISTINCT tipo_prod from productos";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())//Si la tabla tiene 1 o más filas...
            {
                //Rellena la lista desplegable
                comboTipo.Items.Add(dr.GetString(0));
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Pregunta si no se seleccionó un valor nulo en el comboBox (Lista de productos)
            if ((comboTipo.SelectedItem != null && txtNombre.Text != null))
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
                //Actualiza el producto
                comm.CommandText = "INSERT into productos (nombre_prod, tipo_prod, stock_final_prod, ingreso_produc, stock_inicio_prod, consumo_prod, rut, fecha) VALUES ('"+txtNombre.Text+"','"+comboTipo.SelectedItem.ToString()+"',"+numericCantidad.Value.ToString()+","+numericCantidad.Value.ToString()+", 0, 0,'"+l.getRut()+"','"+fecha+"')" ;
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                MessageBox.Show("Se ha agregado el producto " + txtNombre.Text+" de manera Exitosa", "Se agregó un nuevo producto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            else //En caso de que esté seleccionado un valor nulo
            {
                MessageBox.Show("Por favor, llene los campos solicitados ", "Casillero producto vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
