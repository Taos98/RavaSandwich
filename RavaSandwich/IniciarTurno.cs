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
    public partial class IniciarTurno : Form
    {
        public IniciarTurno()
        {
            InitializeComponent();
            comboPuesto.Items.Add("Caja");
            comboPuesto.Items.Add("Plancha");
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
            comm.CommandText =
                "SELECT rut FROM Usuarios ORDER BY rut ASC";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())//Si la tabla tiene 1 o más filas...
            {
                comboRut.Items.Add(dr.GetString(0));
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if ((comboRut.SelectedItem != null && comboPuesto.SelectedItem != null && txtHora.Text != ""))
            {
                //verifica si es el primer turno del dia
                if (verificarTurnoDia() == false)
                {
                    //Realiza la actualizacion de stock de productos de bodega
                    actualizarStockInventario();
                }
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
                comm.CommandText =
                    "INSERT INTO Turno (rut, puesto, fecha, hora_ingreso, hora_salida) VALUES ('" + comboRut.SelectedItem.ToString() + "','" + comboPuesto.SelectedItem.ToString() + "','" + dateTimeFecha.Value.ToString("d") + "', '" + txtHora.Text + "', ' - ')";
                DialogResult dialogResult = MessageBox.Show("¿Desea agregar turno para '" + txtNombre.Text + "'?", "Agregar turno", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (dialogResult == DialogResult.Yes)
                {
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                    

                    MessageBox.Show(
                        txtNombre.Text + "\nha iniciado su turno con: \nfecha: " + dateTimeFecha.Value.ToString("d") + "\nhora: " + txtHora.Text,
                        "Iniciar Turno", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); ;
                }
                else if (dialogResult == DialogResult.No)
                {
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                    MessageBox.Show(
                        "Operación cancelada",
                        "Iniciar Turno", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una opcion", "Casillero producto vacío",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }

        }

        private void comboRut_SelectedIndexChanged(object sender, EventArgs e)
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
            comm.CommandText =
                "SELECT nombre FROM usuarios " +
                "WHERE rut = '" + comboRut.SelectedItem.ToString() + "'";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            dr.Read();
            txtNombre.Text = dr.GetString(0);
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Gestionar_Turno t = new Gestionar_Turno();
            t.Show();
            this.Close();
        }
        //Verifica si inicio el turno por primera vez en el dia para no reestablecer varias veces el stock
        private bool verificarTurnoDia()
        {
            String fecha = DateTime.Now.ToString("d");
            int contador = 0;
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
            comm.CommandText =
                "SELECT puesto FROM turno where fecha = '"+fecha+"'";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())//Si la tabla tiene 1 o más filas...
            {
                contador++;
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();

            return (contador > 0);//Si hay al menos 1 turno, entonces la verificacion será verdadera
        }
        //Se conecta a la BD para pasar el stock final al inicio, cada vez que se inicie el primer turno del dia
        private void actualizarStockInventario()
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
            comm.CommandText = "UPDATE productos SET stock_inicio_prod = stock_final_prod , stock_final_prod=0";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
        }
    }
}
