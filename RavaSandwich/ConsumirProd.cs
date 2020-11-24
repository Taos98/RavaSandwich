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
    public partial class ConsumirProd : Form
    {
        public ConsumirProd()
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
            comm.CommandText = "SELECT nombre_prod from productos ORDER BY nombre_prod ASC";
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

        private void comboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void btnConsumir_Click(object sender, EventArgs e)
        {
            //Pregunta si no se seleccionó un valor nulo en el comboBox (Lista de productos)
            if ((comboProductos.SelectedItem != null))
            {
                //Pregunta si la cantidad a consumir es menor a la cantidad disponible
                if (verificarStock())
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
                comm.CommandText = "UPDATE productos SET consumo_turno = consumo_turno+ " + numericCantidad.Value.ToString() + ", stock_fin_turno=stock_fin_turno-" + numericCantidad.Value.ToString() + " WHERE nombre_prod = '" + comboProductos.SelectedItem.ToString() + "'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                MessageBox.Show("Se ha consumido " + numericCantidad.Value.ToString() + " del producto " + comboProductos.SelectedItem.ToString(), "Datos actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            else
            {
                MessageBox.Show("La cantidad a consumir supera a la cantidad que se encuentra disponible ", "Error al consumir producto", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            }
            else //En caso de que esté seleccionado un valor nulo
            {
                MessageBox.Show("Por favor, seleccione un producto ", "Casillero producto vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Verifica si el stock a consumir supera al stock disponible
        private bool verificarStock()
        {
 
            int stockDB, stock;
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
            comm.CommandText = "SELECT stock_fin_turno from productos where nombre_prod = '" + comboProductos.SelectedItem.ToString() + "'";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();

            //lee una fila
            dr.Read();
            //extrae el valor de la fila y lo asigna a una variable
            stockDB = dr.GetInt16(0);
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
            stock = Int32.Parse(numericCantidad.Value.ToString());
            return stockDB >= stock;
        }

        private void ConsumirProd_Load(object sender, EventArgs e)
        {

        }
    }
}
