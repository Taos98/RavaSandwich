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
        int sueldoCajere;
        int sueldoPlanchere;
        public CajaSueldos()
        {
            InitializeComponent();

            //conexion para extraer el rut del usuario
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=TomiMati2005;Database=Rava");//Datos de conexion a la BD
            conn1.Open();// Abre la BD
            //Realiza la consulta si los datos ingresados por el textbox son iguales a las que están en la BD
            NpgsqlCommand cmd1 = new NpgsqlCommand("SELECT (nombre, rut) FROM usuarios");
            NpgsqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                cBoxRutCajero.Items.Add(dr1.GetString(1));
                labelNombreCajero.Text = dr1.GetString(0);

                cBoxRutPlanchero.Items.Add(dr1.GetString(1));
                labelNombrePlanchero.Text = dr1.GetString(0);
            }
            //Cerrar comandos
            cmd1.Dispose();
            //Desconectar BD
            conn1.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void cBoxRutCajero_SelectedIndexChanged(object sender, EventArgs e)
        {

            //conexion para rellenar los datos en sueldo
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=TomiMati2005;Database=Rava");//Datos de conexion a la BD
            conn.Open();// Abre la BD
            //Realiza la consulta si los datos ingresados por el textbox son iguales a las que están en la BD
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT (hora_ingreso, hora_salida, puesto, rut, fecha) FROM turno WHERE rut ='" + cBoxRutPlanchero.SelectedItem.ToString() + "', puesto = 'cajero'");
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.GetString(4) == fecha)
                {
                    txtHoraIngresoC.Text = dr.GetString(0);
                    txtHoraSalidaC.Text = dr.GetString(1);
                }
            }
            //Cerrar comandos
            cmd.Dispose();
            //Desconectar BD
            conn.Close();


            DateTime horaInicioCaja = DateTime.Parse(txtHoraIngresoC.Text);
            DateTime horaFinalCaja = DateTime.Parse(txtHoraSalidaC.Text);
            float difHorasCaja = (horaInicioCaja.Minute - horaFinalCaja.Minute) / 60;
            txtTotalHorasC.Text = difHorasCaja + "";
            sueldoCajere = (int)(float.Parse(txtTotalHorasC.Text) * float.Parse(txtValorHoraC.Text));
            txtTotalC.Text = sueldoCajere + "";
        }

        private void cBoxRutPlanchero_SelectedIndexChanged(object sender, EventArgs e)
        {
            //conexion para rellenar los datos en sueldo
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=TomiMati2005;Database=Rava");//Datos de conexion a la BD
            conn.Open();// Abre la BD
            //Realiza la consulta si los datos ingresados por el textbox son iguales a las que están en la BD
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT (hora_ingreso, hora_salida, puesto, rut, fecha) FROM turno WHERE rut ='" + cBoxRutPlanchero.SelectedItem.ToString() + "', puesto = 'planchero'");
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.GetString(4) == fecha)
                {
                    txtHoraIngresoP.Text = dr.GetString(0);
                    txtHoraSalidaP.Text = dr.GetString(1);
                }
            }
            //Cerrar comandos
            cmd.Dispose();
            //Desconectar BD
            conn.Close();
            DateTime horaInicioPlancha = DateTime.Parse(txtHoraIngresoP.Text);
            DateTime horaFinalPlancha = DateTime.Parse(txtHoraSalidaP.Text);
            float difHorasPlancha = (horaInicioPlancha.Minute - horaFinalPlancha.Minute) / 60;
            txtTotalHorasP.Text = difHorasPlancha + "";
            sueldoPlanchere = (int)(float.Parse(txtTotalHorasP.Text) * float.Parse(txtValorHoraP.Text));
            txtTotalP.Text = sueldoPlanchere + "";
        }
    }
}
