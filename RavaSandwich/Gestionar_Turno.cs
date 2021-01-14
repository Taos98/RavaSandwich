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
    public partial class Gestionar_Turno : Form
    {
        public Gestionar_Turno()
        {
            InitializeComponent();
            
        }

        private void btnIniciarTurno_Click(object sender, EventArgs e)
        {
            IniciarTurno i = new IniciarTurno();
           
            if (Application.OpenForms[i.Name] == null)
            {
                i.Show();
            }
            else
            {
                Application.OpenForms[i.Name].Activate();
            }
        }

        private void btnCerrarTurno_Click(object sender, EventArgs e)
        {
            CerrarTurno t = new CerrarTurno();

            if (Application.OpenForms[t.Name] == null)
            {
                t.Show();
            }
            else
            {
                Application.OpenForms[t.Name].Activate();
            }
        }
        public String getRutPlanchero()
        {
            String fecha = DateTime.Now.ToString("d");
            String rutP = "";
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
            //Realiza la consulta si los datos ingresados por el textbox son iguales a las que están en la BD
            comm.CommandText = ("SELECT rut, fecha) FROM turno WHERE  puesto = 'Plancha'");
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.GetString(1) == fecha)
                {
                    rutP = dr.GetString(0);
                }
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
            return rutP;
        }

        public String getNombrePlanchero()
        {
            String nombreP = "";
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
            //Realiza la consulta si los datos ingresados por el textbox son iguales a las que están en la BD
            comm.CommandText = ("SELECT nombre FROM usuarios WHERE rut = '"+getRutPlanchero()+"'");
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                nombreP = dr.GetString(0);
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
            return nombreP;
        }

        public String getRutCajero()
        {
            String fecha = DateTime.Now.ToString("d");
            String rutP = "";
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
            //Realiza la consulta si los datos ingresados por el textbox son iguales a las que están en la BD
            comm.CommandText = ("SELECT rut, fecha) FROM turno WHERE  puesto = 'Caja'");
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.GetString(1) == fecha)
                {
                    rutP = dr.GetString(0);
                }
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
            return rutP;
        }

        public String getNombreCajero()
        {
            String nombreP = "";
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
            //Realiza la consulta si los datos ingresados por el textbox son iguales a las que están en la BD
            comm.CommandText = ("SELECT nombre FROM usuarios WHERE rut = '" + getRutCajero() + "'");
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                nombreP = dr.GetString(0);
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
            return nombreP;
        }


    }
}
