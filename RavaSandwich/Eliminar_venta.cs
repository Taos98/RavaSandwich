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
    public partial class Eliminar_venta : Form
    {
        String fecha = DateTime.Now.ToString("d");
        public Eliminar_venta()
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
            comm.CommandText = "SELECT nombre_cliente, fecha from ventas";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())//Si la tabla tiene 1 o más filas...
            {
                if (dr.GetString(1).Contains(fecha))
                {
                    cbNombreCliente.Items.Add(dr.GetString(0));
                }
                
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Pregunta si no se seleccionó un valor nulo en el comboBox (Lista de productos)
            if (cbNombreCliente.SelectedItem != null && listBoxPedido.SelectedItem!=null)
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
                comm.CommandText = "DELETE FROM ventas where pedido = '" + listBoxPedido.SelectedItem.ToString() + "'";
                DialogResult dia = MessageBox.Show("Desea eliminar esta venta? \n" + listBoxPedido.SelectedItem.ToString() , "Eliminar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (dia == DialogResult.Yes)
                {
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    MessageBox.Show("Se ha eliminado la venta de \n" + listBoxPedido.SelectedItem.ToString() + " de manera Exitosa", "Venta Anulada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
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

        private void cbNombreCliente_SelectedIndexChanged(object sender, EventArgs e)
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
            comm.CommandText = "SELECT pedido, fecha from ventas WHERE nombre_cliente ='"+cbNombreCliente.SelectedItem.ToString()+"'";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())//Si la tabla tiene 1 o más filas...
            {
                if (dr.GetString(1).Contains(fecha))
                {
                    listBoxPedido.Items.Add(dr.GetString(0));
                }

            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
        }
    }
}
