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
        static int contC = 0;//para contar los cajeros en turno
        static int contP = 0;//para contar los plancheros en turno
        public Gestionar_Turno()
        {
            InitializeComponent();
            //al inicio si no hay turno, no debería mostrar la tabla y sólo debería decir que no hay turnos registrados
            labelDisponible.Visible = true;//label que dice que no hay turnos
            //se ocultan los datos de la tabla
            labelPuesto.Visible = false;
            labelPlanchero.Visible = false;
            labelCajero.Visible = false;
            labelNombre.Visible = false;
            labelNombreCajero.Visible = false;
            labelNombrePlanchero.Visible = false;
            labelHora.Visible = false;
            labelHoraCajero.Visible = false;
            labelHoraPlanchero.Visible = false;

            //llena los datos del turno actual
            
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
            //Realiza la consulta si hay personas en turno
            comm.CommandText = ("SELECT rut, puesto, hora_ingreso FROM turno WHERE  hora_salida = ' - '");
            NpgsqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                //si hay planchero
                if (dr.GetString(1) == "Plancha")
                {
                    contP++;
                    labelDisponible.Visible = false;
                    labelPlanchero.Visible = true;
                    labelPuesto.Visible = true;
                    labelHora.Visible = true;
                    labelHoraPlanchero.Visible = true;
                    labelHoraPlanchero.Text = dr.GetString(2);
                    labelNombre.Visible = true;
                    labelNombrePlanchero.Visible = true;
                    labelNombrePlanchero.Text = getNombrePersona(dr.GetString(0));
                    labelNombreCajero.Visible = true;
                }
                if (dr.GetString(1) == "Caja")
                {
                    contC++;
                    labelNombre.Visible = true;
                    labelHora.Visible = true;
                    labelDisponible.Visible = false;
                    labelCajero.Visible = true;
                    labelPuesto.Visible = true;
                    labelHoraCajero.Visible = true;
                    labelHoraCajero.Text = dr.GetString(2);
                    labelNombreCajero.Visible = true;
                    labelNombreCajero.Text = getNombrePersona(dr.GetString(0));
                    labelNombrePlanchero.Visible = true;
                }
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();

        }

        private void btnIniciarTurno_Click(object sender, EventArgs e)
        {
            IniciarTurno i = new IniciarTurno();
            i.Show();
            this.Close();
           
        }

        private void btnCerrarTurno_Click(object sender, EventArgs e)
        {
            CerrarTurno t = new CerrarTurno();
            t.Show();
            this.Close();
            
        }
        
        private String getNombrePersona(String rut)
        {
            String nombre = "";
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
            //Realiza la consulta si los datos ingresados por el textbox son iguales a las que están en la BD
            comm.CommandText = ("SELECT nombre FROM usuarios WHERE  rut = '"+rut+"'");
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                nombre = dr.GetString(0); 
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
            return nombre;
        }


    }
}
