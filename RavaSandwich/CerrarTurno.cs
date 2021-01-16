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
    public partial class CerrarTurno : Form
    {
        public CerrarTurno()
        {
            InitializeComponent();
            // Datos de conexión a BD
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
                "SELECT DISTINCT rut FROM turno WHERE fecha ='" + dateTimeFecha.Value.ToString("d") + "'";
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

        private void ctnCerrarTurno_Click(object sender, EventArgs e)
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
                "UPDATE Turno SET hora_salida = '" + txtHoraS.Text + "' WHERE fecha = '" + dateTimeFecha.Value.ToString("d") + "' AND rut = '" + comboRut.SelectedItem.ToString() + "' AND hora_salida = ' - ' ";



            DialogResult dialogResult = MessageBox.Show("¿Desea finaliar turno para '" + txtNombre.Text + "'?", "Cerrar turno", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.Yes)
            {
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();

                MessageBox.Show(
                    txtNombre.Text + "\nha cerrado su turno con: \nfecha: " + dateTimeFecha.Value.ToString("d") + "\nhora: " + txtHoraS.Text,
                    "Cerrar Turno", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); ;
            }
            else if (dialogResult == DialogResult.No)
            {
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
                MessageBox.Show(
                    "Operación cancelada",
                    "Cerrar Turno", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void comboRut_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Datos de conexión a BD
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
                "SELECT nombre FROM usuarios WHERE rut = '"+comboRut.SelectedItem.ToString()+"'";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                txtNombre.Text = dr.GetString(0);
            }
            txtPuesto.Text = obtenerPuestoActual(comboRut.SelectedItem.ToString());
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
        }
        private String obtenerPuestoActual(String rut)
        {
            String puesto = "";
            // Datos de conexión a BD
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
                "SELECT puesto FROM turno WHERE fecha ='" + dateTimeFecha.Value.ToString("d") + "' and rut = '" + comboRut.SelectedItem.ToString() + "'";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            if(dr.Read())//Si la tabla tiene 1 o más filas...
            {
                puesto = dr.GetString(0);
                return puesto;
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
            return puesto;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Gestionar_Turno t = new Gestionar_Turno();
            t.Show();
            this.Close();
            
        }

        private void dateTimeFecha_ValueChanged(object sender, EventArgs e)
        {
            comboRut.Items.Clear();
            // Datos de conexión a BD
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
                "SELECT DISTINCT rut FROM turno WHERE fecha ='" + dateTimeFecha.Value.ToString("d") + "'";
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
    }
}
