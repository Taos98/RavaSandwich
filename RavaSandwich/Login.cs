using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace RavaSandwich
{
    public partial class Login : Form
    {
        public static String nombre = "";
        public static String rol = "";
        public static String rut = "";
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            bool blnfound = false;//Booleano que indica la existencia de datos, por default es falso
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=TomiMati2005;Database=Rava");//Datos de conexion a la BD
            conn.Open();// Abre la BD
            //Realiza la consulta si los datos ingresados por el textbox son iguales a las que están en la BD
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM usuarios WHERE rut='" + txtRut.Text + "' and pass = '" + txtPass.Text + "' and rol = 'administrador'", conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();//Guarda los resultados de la consulta

            if (dr.Read())//Si hay datos
            {
                nombre = dr.GetString(1);
                rut = dr.GetString(0);
                rol = dr.GetString(3);
                blnfound = true;//la existencia de datos es verdadera
                MenuAdmin ma = new MenuAdmin(); //Crea un objeto del menú
                ma.Show();// invoca la ventana del menú
                this.Hide();//Oculta la ventana del login
                
               
            }

            if (blnfound == false)//si no se encuentra datos o no coinciden
            {
                //muestra un lindo mensajito
                //MessageBox.Show("Error en los datos!! Revise e intente nuevamente", "Datos de inicio de sesión incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                dr.Close(); // Cierra el registro de la consulta
                conn.Close();// Cierra la consulta
            }

            bool blnfound1 = false;//Booleano que indica la existencia de datos, por default es falso
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=TomiMati2005;Database=Rava");//Datos de conexion a la BD
            conn1.Open();// Abre la BD
            //Realiza la consulta si los datos ingresados por el textbox son iguales a las que están en la BD
            NpgsqlCommand cmd1 = new NpgsqlCommand("SELECT * FROM usuarios WHERE rut='" + txtRut.Text + "' and pass = '" + txtPass.Text + "' and rol = 'usuario'", conn1);
            NpgsqlDataReader dr1 = cmd1.ExecuteReader();//Guarda los resultados de la consulta

            if (dr1.Read())//Si hay datos
            {
                nombre = dr.GetString(1);
                rut = dr.GetString(0);
                rol = dr.GetString(3);
                blnfound1 = true;//la existencia de datos es verdadera
                MenuUsuario mu = new MenuUsuario(); //Crea un objeto del menú
                mu.Show();// invoca la ventana del menú
                this.Hide();//Oculta la ventana del login
                

            }

            if ((blnfound1 == false) && (blnfound == false))//si no se encuentra datos o no coinciden
            {
                //muestra un lindo mensajito
                MessageBox.Show("Error en los datos!! Revise e intente nuevamente", "Datos de inicio de sesión incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                dr1.Close(); // Cierra el registro de la consulta
                conn1.Close();// Cierra la consulta
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        
        
       //Metodos get para mostrar nombre, rut y rol de la persona que inició sesión para ser mostrado en las otras ventanas, cuando se necesite
        public string getNombre()
        {
            return nombre;
        }
        public string getRut()
        {
            return rut;
        }
        public string getRol()
        {
            return rol;
        }
    }
}
