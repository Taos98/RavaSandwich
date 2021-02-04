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
    public partial class IngresoIngredi : Form
    {
        String fecha = DateTime.Now.ToString("d");
        public IngresoIngredi()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void IngresoIngrediente_Load(object sender, EventArgs e)
        {
            //Carga el combobox de los productos de inventario

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
            comm.CommandText = "SELECT nombre_prod from productos";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())//Si la tabla tiene 1 o más filas...
            {
                //Rellena la lista desplegable
                comboProductos.Items.Add(dr.GetString(0));
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
            
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //Pregunta si no se seleccionó un valor nulo en el comboBox (Lista de productos)
            if((comboProductos.SelectedItem != null))
            {
                Login l = new Login();
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
                //Actualiza el producto con la cantidad a ingresar
                comm.CommandText = "UPDATE productos SET ingreso_produc = ingreso_produc +" + numericCantidad.Value.ToString() + ", stock_final_prod=stock_inicio_prod+" + numericCantidad.Value.ToString() + ", rut = '" + l.getRut() + "', fecha ='" + fecha + "'  WHERE nombre_prod = '" + comboProductos.SelectedItem.ToString() + "'";                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                MessageBox.Show("Se ha agregado " + numericCantidad.Value.ToString() + " al producto " + comboProductos.SelectedItem.ToString(), "Datos actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            else //En caso de que esté seleccionado un valor nulo
            {
                MessageBox.Show("Por favor, seleccione un producto " , "Casillero producto vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
