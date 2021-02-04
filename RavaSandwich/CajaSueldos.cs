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
        //Variables globales
        String fecha = DateTime.Now.ToString("d");
        public static int sueldoCajere = 0;
        public static int sueldoPlanchere = 0;
        static String nombreC = "";
        static String nombreP = "";
        static String rutC = "";
        static String rutP = "";
        public CajaSueldos()
        {
            InitializeComponent();

            //Carga el combobox con los cajeros y plancheros del dia

            //Datos de conexión a BD
            NpgsqlConnection conn1 = new NpgsqlConnection("Server = localhost; Port = 5432; User Id = postgres; Password = TomiMati2005; Database = Rava");
            //Abrir BD
            conn1.Open();
            //Crear objeto de comandos
            NpgsqlCommand comm1 = new NpgsqlCommand();
            //Crear objeto conexión
            comm1.Connection = conn1;
            comm1.CommandType = CommandType.Text;
            //Consulta 
            comm1.CommandText="SELECT rut, puesto FROM turno WHERE fecha = '"+fecha+"'";
            NpgsqlDataReader dr1 = comm1.ExecuteReader();
            while (dr1.Read())
            {
                if (dr1.GetString(1).Equals("Caja"))//Equals equivale a == 
                {
                    //Llena el combobox de los cajeros con los rut de las personas que trabajaron en caja
                    cBoxRutCajero.Items.Add(dr1.GetString(0));
                }
                if (dr1.GetString(1) == "Plancha")
                {
                    //Llena el combobox de los plancheros con los rut de las personas que trabajaron en la plancha
                    cBoxRutPlanchero.Items.Add(dr1.GetString(0));
                }
            }
            //Cerrar comandos
            comm1.Dispose();
            //Desconectar BD
            conn1.Close();
            //Carga los casilleros de valor hora con los valores por hora determinados, se pueden modificar en caso de que cambie el valor
            txtValorHoraC.Text = "1500";
            txtValorHoraP.Text = "1700";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Calcula los sueldos y los guarda en las variables globales, además el trycatch evita que muestre un error de formato
            try
            {
                sueldoPlanchere = (int)(float.Parse(txtTotalHorasP.Text) * int.Parse(txtValorHoraP.Text));
                txtTotalP.Text = sueldoPlanchere + "";
                sueldoCajere = (int)((float.Parse(txtTotalHorasC.Text) * int.Parse(txtValorHoraC.Text)));
                txtTotalC.Text = sueldoCajere + "";
                if (cBoxRutPlanchero.SelectedItem != null)
                {
                    rutP = cBoxRutPlanchero.SelectedItem.ToString();
                }
                if (cBoxRutCajero.SelectedItem != null) { 
                rutC = cBoxRutCajero.SelectedItem.ToString();
                }
                nombreC = labelNombreCajero.Text;
                nombreP = labelNombrePlanchero.Text;
            }
            catch (FormatException)
            {
                MessageBox.Show("Falta un dato importante!!!\nPor favor, revise las casillas ", "Falta datos!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cBoxRutCajero_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Al seleccionar un rut del combobox del cajero debería cargar sus datos como nombre, hora ingreso, hora salida

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
            comm.CommandText = "SELECT hora_ingreso, hora_salida, puesto, rut, fecha FROM turno WHERE rut ='" + cBoxRutCajero.SelectedItem.ToString() + "' and puesto = 'Caja'";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                if (dr.GetString(4) ==fecha)
                {
                    txtHoraIngresoC.Text = dr.GetString(0);
                    txtHoraSalidaC.Text = dr.GetString(1);
                    labelNombreCajero.Text = getNombrePersona(dr.GetString(3));
                }
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();

            //Convierte las horas en el formato hora de Date
            String fechaH1 = fecha + ' ' + txtHoraIngresoC.Text;
            String fechaH2 = fecha + ' ' + txtHoraSalidaC.Text;
            try
            {
                DateTime horaInicioCaja = DateTime.Parse(fechaH1);
                DateTime horaFinalCaja = DateTime.Parse(fechaH2);
            }
            catch (FormatException)
            {
                MessageBox.Show("Esta persona no ha cerrado su turno!!!\nPor favor, cierre su turno ", "No se sabe la hora de salida", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }

            
        }

        private void cBoxRutPlanchero_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Al seleccionar un rut del combobox del planchero debería cargar sus datos como nombre, hora ingreso, hora salida

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
            comm.CommandText=("SELECT hora_ingreso, hora_salida, puesto, rut, fecha FROM turno WHERE rut ='" + cBoxRutPlanchero.SelectedItem.ToString() + "'AND puesto = 'Plancha'");
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                if (dr.GetString(4) == fecha)
                {
                    txtHoraIngresoP.Text = dr.GetString(0);
                    txtHoraSalidaP.Text = dr.GetString(1);
                    labelNombrePlanchero.Text = getNombrePersona(dr.GetString(3));
                }
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
            //Convierte las horas en el formato hora de Date
            String fechaH1 = fecha + ' ' + txtHoraIngresoP.Text;
            String fechaH2 = fecha + ' ' + txtHoraSalidaP.Text;
            try
            {
                DateTime horaInicioPlancha = DateTime.Parse(fechaH1);
                DateTime horaFinalPlancha = DateTime.Parse(fechaH2);
           
            }
            catch(FormatException)
            {
                MessageBox.Show("Esta persona no ha cerrado su turno!!!\nPor favor, cierre su turno ","No se sabe la hora de salida", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            

        }
        //Obtiene el total de los sueldos de cajero en el día y se puede usar en las otras clases
        public int getSueldoCajero()
        {
            return sueldoCajere;
        }
        //Obtiene el total de los sueldos de planchero en el día y se puede usar en las otras clases
        public int getSueldoPlanchero()
        {
            return sueldoPlanchere;
        }
        //Método que sirve para obtener el nombre de una persona a través del rut
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
            comm.CommandText = ("SELECT nombre FROM usuarios WHERE  rut = '" + rut + "'");
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
        //Obtiene el rut del planchero para pueda ser usado en las otras clases
        public String getRutPlanchero()
        {
            return rutP;
        }

        //Obtiene el nombre del planchero para pueda ser usado en las otras clases
        public String getNombrePlanchero()
        {
            return nombreP;
        }

        //Obtiene el rut del cajero para pueda ser usado en las otras clases
        public String getRutCajero()
        {
            return rutC;
        }

        //Obtiene el nombre del cajero para pueda ser usado en las otras clases
        public String getNombreCajero()
        {
            return nombreC;
        }
    }
}
