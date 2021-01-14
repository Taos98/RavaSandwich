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
    public partial class CajaSueldos : Form
    {
        String fecha = DateTime.Now.ToString("d");
        public static int sueldoCajere = 0;
        public static int sueldoPlanchere = 0;
        public CajaSueldos()
        {
            InitializeComponent();

            //Datos de conexión a BD
            NpgsqlConnection conn1 = new NpgsqlConnection("Server = localhost; Port = 5432; User Id = postgres; Password = censurado; Database = Rava_Sandwich");
            //Abrir BD
            conn1.Open();
            //Crear objeto de comandos
            NpgsqlCommand comm1 = new NpgsqlCommand();
            //Crear objeto conexión
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.Text;
            //Consulta 
            comm1.CommandText="SELECT nombre, rut FROM usuarios";
            NpgsqlDataReader dr1 = comm1.ExecuteReader();
            while (dr1.Read())
            {
                cBoxRutCajero.Items.Add(dr1.GetString(1));
                cBoxRutPlanchero.Items.Add(dr1.GetString(1));
        
            }
            //Cerrar comandos
            comm1.Dispose();
            //Desconectar BD
            conn1.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void cBoxRutCajero_SelectedIndexChanged(object sender, EventArgs e)
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
            //Realiza la consulta si los datos ingresados por el textbox son iguales a las que están en la BD
            comm.CommandText = "SELECT hora_ingreso, hora_salida, puesto, rut, fecha FROM turno WHERE rut ='" + cBoxRutCajero.SelectedItem.ToString() + "' and puesto = 'Caja'";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                if (dr.GetString(4) ==fecha)
                {
                    txtHoraIngresoC.Text = dr.GetString(0);
                    txtHoraSalidaC.Text = dr.GetString(1);
                }
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();

            String fechaH1 = fecha + ' ' + txtHoraIngresoC.Text;
            String fechaH2 = fecha + ' ' + txtHoraSalidaC.Text;
            DateTime horaInicioCaja = DateTime.Parse(fechaH1);
            DateTime horaFinalCaja = DateTime.Parse(fechaH2);
            TimeSpan span = horaFinalCaja.Subtract(horaInicioCaja);
            int difHorasCaja = span.Minutes;
            txtTotalHorasC.Text = difHorasCaja + "";
            sueldoCajere = ((difHorasCaja * int.Parse(txtValorHoraC.Text)));
            txtTotalC.Text = sueldoCajere + "";
        }

        private void cBoxRutPlanchero_SelectedIndexChanged(object sender, EventArgs e)
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
            comm.CommandText=("SELECT hora_ingreso, hora_salida, puesto, rut, fecha FROM turno WHERE rut ='" + cBoxRutPlanchero.SelectedItem.ToString() + "'AND puesto = 'Plancha'");
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                if (dr.GetString(4) == fecha)
                {
                    txtHoraIngresoP.Text = dr.GetString(0);
                    txtHoraSalidaP.Text = dr.GetString(1);
                }
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();

            String fechaH1 = fecha + ' ' + txtHoraIngresoP.Text;
            String fechaH2 = fecha + ' ' + txtHoraSalidaP.Text;
            DateTime horaInicioPlancha = DateTime.Parse(fechaH1);
            DateTime horaFinalPlancha = DateTime.Parse(fechaH2);
            TimeSpan span = horaFinalPlancha.Subtract(horaInicioPlancha);
            int difHorasPlancha = span.Minutes;
            txtTotalHorasP.Text = difHorasPlancha + "";
            sueldoPlanchere = (difHorasPlancha * int.Parse(txtValorHoraP.Text));
            txtTotalP.Text = sueldoPlanchere + "";
        }
        public int getSueldoCajero()
        {
            return sueldoCajere;
        }
        public int getSueldoPlanchero()
        {
            return sueldoPlanchere;
        }
    }
}
