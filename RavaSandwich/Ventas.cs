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
    public partial class Ventas : Form
    {
        static int precioB1 = 0;//Precio de la bebida1
        static int precioB2 = 0;//Precio de la bebida2
        static int precioB3 = 0;//Precio de la bebida3
        static int precioP = 0;//Precio de la promo
        static int precioV = 0;//Precio de los vasos
        static int cantB = 1;//Cantidad de bebidas a llevar
        static String extras1 = "";//Indica los extras1 que va a llevar
        static String extras2 = "";//Indica los extras1 que va a llevar
        static int cantExtras1 = 0;
        static int cantExtras2 = 0;
        static int totalExtra1 = 0;
        static int totalextra2 = 0;
        static String salsas = "";
        static List<Promo> promos = new List<Promo>();

        // los sgtes datos son para almacenar las cantidades a descontar
        static int cantPromoS = 0;
        static int cantMini = 0;
        static float cantManso = 0;
        static int cantCompP = 0;
        static int cantCompM = 0;
        static int cantBebida1 = 0;
        static int cantBebida2 = 0;
        static int cantBebida3 = 0;
        static int cantVasos = 0;
        static double cantCarne1 = 0;
        static double cantCarne2 = 0;
        static int cantVienesas = 0;
        public Ventas()
        {
            InitializeComponent();
            txtPrecio.Text = "$ 0";
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
            comm.CommandText = "SELECT id_promo, categoria from promo ORDER BY id_promo ASC";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())//Si la tabla tiene 1 o más filas...
            {
                //Rellena la lista desplegable
                comboPromos.Items.Add(dr.GetString(1) + " - " + dr.GetString(0));
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();

            //Llenar los agregados
            String[] agregados = new String[] { "Aceituna", "Aji Verde", "Cebolla", "Champiñon", "Choclo", "Chucrut", "Huevo", "Morron", "Palta", "Pepinillo", "Poroto Verde", "Queso", "Tocino", "Tomate", " " };
            for (int i = 0; i < agregados.Length; i++)
            {
                comboAgregado1.Items.Add(agregados[i]);
                comboAgregado2.Items.Add(agregados[i]);
                comboAgregado3.Items.Add(agregados[i]);
                comboAgregado4.Items.Add(agregados[i]);
                comboAgregado5.Items.Add(agregados[i]);
                comboAgregado6.Items.Add(agregados[i]);
                comboAgregado7.Items.Add(agregados[i]);
                comboAgregado8.Items.Add(agregados[i]);
                comboExtraS1.Items.Add(agregados[i]);
                comboExtraS2.Items.Add(agregados[i]);
            }
            //Llenar las carnes
            String[] carnes = new String[] { "Ave", "Churrasco", "Lomo", "Mechada", "Vienesa", "As", " " };
            for (int i = 0; i < carnes.Length; i++)
            {
                comboCarne1.Items.Add(carnes[i]);
                comboCarne2.Items.Add(carnes[i]);
            }
            //-- LLENAR LAS BEBIDAS --

            //Datos de conexión a BD
            NpgsqlConnection conn1 = new NpgsqlConnection("Server = localhost; Port = 5432; User Id = postgres; Password = TomiMati2005; Database = Rava");
            //Abrir BD
            conn1.Open();
            //Crear objeto de comandos
            NpgsqlCommand comm1 = new NpgsqlCommand();
            //Crear objeto conexión
            comm1.Connection = conn1;
            //No se que hace xd
            comm1.CommandType = CommandType.Text;
            //Consulta
            comm1.CommandText = "SELECT nombre from bebidas";
            //Leer BD
            NpgsqlDataReader dr1 = comm1.ExecuteReader();
            while (dr1.Read())//Si la tabla tiene 1 o más filas...
            {
                //Rellena la lista desplegable
                comboBebidas1.Items.Add(dr1.GetString(0));
                comboBebidas2.Items.Add(dr1.GetString(0));
                comboBebidas3.Items.Add(dr1.GetString(0));
            }
            //Cerrar comandos
            comm1.Dispose();
            //Desconectar BD
            conn1.Close();
            //Oculta las bebidas 2 y 3, se activaran en el caso de pulsar el botón +
            numericCantBebidas2.Visible = false;
            labelcantB2.Visible = false;
            labelCantB3.Visible = false;
            labelSelecB2.Visible = false;
            labelSelectB3.Visible = false;
            comboBebidas2.Visible = false;
            numericCantBebidas3.Visible = false;
            comboBebidas3.Visible = false;
        }

        private void Ventas_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            //Se restablece los valores al salir de ventas
            precioB1 = 0;
            precioB2 = 0;
            precioB3 = 0;
            precioP = 0;
            precioV = 0;
            cantB = 1;
            extras1 = "";//Indica los extras1 que va a llevar
            extras2 = "";//Indica los extras1 que va a llevar
            cantExtras1 = 0;
            cantExtras2 = 0;
            totalExtra1 = 0;
            totalextra2 = 0;
            salsas = "";
            //Se crea un objeto login para obtener el rol
            Login l = new Login();
            //Si la persona que inició sesión es un usuario, se despliega el menú principal del usuario, en caso de que sea administrador, se desplegará el menú principal del administrador.
            if (l.getRol() == "usuario")
            {
                MenuUsuario mu = new MenuUsuario();
                mu.Show();
                this.Close();
            }
            else if (l.getRol() == "administrador")
            {
                MenuAdmin ma = new MenuAdmin();
                ma.Show();
                this.Close();
            }


        }

        private void comboPromos_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericCantPromo.Value = 1;
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
            //Separa el contenido del comboBox que viene como "categoria - id" a un arreglo
            String[] promocion = comboPromos.SelectedItem.ToString().Split(' ');
            comm.CommandText = "SELECT tipo_carne1, agregado1, agregado2, agregado3, agregado4, tipo_carne2, agregado5, agregado6, agregado7, agregado8, precio from promo where id_promo ='" + promocion[promocion.Length - 1] + "'";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())//Si la tabla tiene 1 o más filas...
            {
                //Llena los combobox con los ingredientes que corresponden a cada promo
                comboCarne1.Text = dr.GetString(0);
                comboAgregado1.Text = dr.GetString(1);
                comboAgregado2.Text = dr.GetString(2);
                comboAgregado3.Text = dr.GetString(3);
                comboAgregado4.Text = dr.GetString(4);
                comboCarne2.Text = dr.GetString(5);
                comboAgregado5.Text = dr.GetString(6);
                comboAgregado6.Text = dr.GetString(7);
                comboAgregado7.Text = dr.GetString(8);
                comboAgregado8.Text = dr.GetString(9);
                precioP = dr.GetInt16(10);//Extrae el precio de la promo de la DB
                int precioConB = totalExtra1 + totalextra2 + (precioP * int.Parse(numericCantPromo.Value.ToString())) + (precioB1 * int.Parse(numericCantBebida.Value.ToString())) + (precioB2 * int.Parse(numericCantBebidas2.Value.ToString())) + (precioB3 * int.Parse(numericCantBebidas3.Value.ToString())) + precioV;
                //Muestra el total con bebida incluida en el textbox
                txtPrecio.Text = "$ " + precioConB;
                //Consulta si los combobox están vacíos para ocultarlos, en caso contrario se muestran.
                if (comboCarne1.Text == "")
                {
                    comboCarne1.Visible = false;
                    labelCarne1.Visible = false;
                }
                else
                {
                    comboCarne1.Visible = true;
                    labelCarne1.Visible = true;
                }
                if (comboCarne2.Text == "")
                {
                    comboCarne2.Visible = false;
                    labelCarne2.Visible = false;
                }
                else
                {
                    comboCarne2.Visible = true;
                    labelCarne2.Visible = true;
                }
                if (comboAgregado1.Text == "")
                {
                    comboAgregado1.Visible = false;
                    labelAgregado1.Visible = false;
                }
                else
                {
                    comboAgregado1.Visible = true;
                    labelAgregado1.Visible = true;
                }
                if (comboAgregado2.Text == "")
                {
                    comboAgregado2.Visible = false;
                    labelAgregado2.Visible = false;
                }
                else
                {
                    comboAgregado2.Visible = true;
                    labelAgregado2.Visible = true;
                }
                if (comboAgregado3.Text == "")
                {
                    comboAgregado3.Visible = false;
                    labelAgregado3.Visible = false;
                }
                else
                {
                    comboAgregado3.Visible = true;
                    labelAgregado3.Visible = true;
                }
                if (comboAgregado4.Text == "")
                {
                    comboAgregado4.Visible = false;
                    labelAgregado4.Visible = false;
                }
                else
                {
                    comboAgregado4.Visible = true;
                    labelAgregado4.Visible = true;
                }
                if (comboAgregado5.Text == "")
                {
                    comboAgregado5.Visible = false;
                    labelAgregado5.Visible = false;
                }
                else
                {
                    comboAgregado5.Visible = true;
                    labelAgregado5.Visible = true;
                }
                if (comboAgregado6.Text == "")
                {
                    comboAgregado6.Visible = false;
                    labelAgregado6.Visible = false;
                }
                else
                {
                    comboAgregado6.Visible = true;
                    labelAgregado6.Visible = true;
                }
                if (comboAgregado7.Text == "")
                {
                    comboAgregado7.Visible = false;
                    labelAgregado7.Visible = false;
                }
                else
                {
                    comboAgregado7.Visible = true;
                    labelAgregado7.Visible = true;
                }
                if (comboAgregado8.Text == "")
                {
                    comboAgregado8.Visible = false;
                    labelAgregado8.Visible = false;
                }
                else
                {
                    comboAgregado8.Visible = true;
                    labelAgregado8.Visible = true;
                }

            }

            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
        }

        private void comboBebidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericCantBebida.Value = 1;
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
            comm.CommandText = "SELECT nombre, precio from bebidas";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())//Si la tabla tiene 1 o más filas...
            {
                //Busca el precio de la bebida
                if (comboBebidas1.SelectedItem.ToString() == dr.GetString(0))
                {
                    precioB1 = dr.GetInt16(1);
                }
            }
            int precioConB = 0;
            if (comboBebidas1.SelectedItem.ToString().Contains("Bebida Lata"))
            {
                precioConB =
                precioV +
                (precioP * int.Parse(numericCantBebida.Value.ToString())) +
                totalExtra1 + totalextra2;
                txtPrecio.Text = "$ " + precioConB;
            }
            else
            {
                precioConB =
                precioV +
                (precioP * int.Parse(numericCantPromo.Value.ToString())) +
                (precioB1 * int.Parse(numericCantBebida.Value.ToString())) +
                (precioB2 * int.Parse(numericCantBebidas2.Value.ToString())) +
                (precioB3 * int.Parse(numericCantBebidas3.Value.ToString())) +
                totalExtra1 +
                totalextra2;
                txtPrecio.Text = "$ " + precioConB;
            }
            //Muestra el total con bebida incluida en el textbox
            txtPrecio.Text = "$ " + precioConB;
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();

        }

        private void numericCantVasos_ValueChanged(object sender, EventArgs e)
        {
            precioV = 100 * int.Parse(numericCantVasos.Value.ToString());
            int precioConB = totalExtra1 + totalextra2 + (precioP * int.Parse(numericCantPromo.Value.ToString())) + (precioB1 * int.Parse(numericCantBebida.Value.ToString())) + (precioB2 * int.Parse(numericCantBebidas2.Value.ToString())) + (precioB3 * int.Parse(numericCantBebidas3.Value.ToString())) + precioV;
            //Muestra el total con bebida incluida en el textbox
            txtPrecio.Text = "$ " + precioConB;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBebidas2_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericCantBebidas2.Value = 1;
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
            comm.CommandText = "SELECT nombre, precio from bebidas";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())//Si la tabla tiene 1 o más filas...
            {
                //Busca el precio de la bebida
                if (comboBebidas2.SelectedItem.ToString() == dr.GetString(0))
                {
                    precioB2 = dr.GetInt16(1);
                }
            }
            int precioConB = 0;
            if (comboBebidas1.SelectedItem.ToString().Contains("Bebida Lata"))
            {
                precioConB =
                precioV +
                (precioP * int.Parse(numericCantBebida.Value.ToString())) +
                totalExtra1 + totalextra2;
                txtPrecio.Text = "$ " + precioConB;
            }
            else
            {
                precioConB =
                precioV +
                (precioP * int.Parse(numericCantPromo.Value.ToString())) +
                (precioB1 * int.Parse(numericCantBebida.Value.ToString())) +
                (precioB2 * int.Parse(numericCantBebidas2.Value.ToString())) +
                (precioB3 * int.Parse(numericCantBebidas3.Value.ToString())) +
                totalExtra1 +
                totalextra2;
                txtPrecio.Text = "$ " + precioConB;
            }
            //Muestra el total con bebida incluida en el textbox
            txtPrecio.Text = "$ " + precioConB;
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
        }

        private void comboBebidas3_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericCantBebidas3.Value = 1;
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
            comm.CommandText = "SELECT nombre, precio from bebidas";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())//Si la tabla tiene 1 o más filas...
            {
                //Busca el precio de la bebida
                if (comboBebidas3.SelectedItem.ToString() == dr.GetString(0))
                {
                    precioB3 = dr.GetInt16(1);
                }
            }
            int precioConB = 0;
            if (comboBebidas1.SelectedItem.ToString().Contains("Bebida Lata"))
            {
                precioConB =
                precioV +
                (precioP * int.Parse(numericCantBebida.Value.ToString())) +
                totalExtra1 + totalextra2;
                txtPrecio.Text = "$ " + precioConB;
            }
            else
            {
                precioConB =
                precioV +
                (precioP * int.Parse(numericCantPromo.Value.ToString())) +
                (precioB1 * int.Parse(numericCantBebida.Value.ToString())) +
                (precioB2 * int.Parse(numericCantBebidas2.Value.ToString())) +
                (precioB3 * int.Parse(numericCantBebidas3.Value.ToString())) +
                totalExtra1 +
                totalextra2;
                txtPrecio.Text = "$ " + precioConB;
            }
            //Muestra el total con bebida incluida en el textbox
            txtPrecio.Text = "$ " + precioConB;
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
        }

        private void numericCantBebida_ValueChanged(object sender, EventArgs e)
        {

            int precioConB = 0;
            if (comboBebidas1.SelectedItem.ToString().Contains("Bebida Lata"))
            {
                precioConB =
                precioV +
                (precioP * int.Parse(numericCantBebida.Value.ToString())) +
                totalExtra1 + totalextra2;
                txtPrecio.Text = "$ " + precioConB;
            }
            else
            {
                precioConB =
                precioV +
                (precioP * int.Parse(numericCantPromo.Value.ToString())) +
                (precioB1 * int.Parse(numericCantBebida.Value.ToString())) +
                (precioB2 * int.Parse(numericCantBebidas2.Value.ToString())) +
                (precioB3 * int.Parse(numericCantBebidas3.Value.ToString())) +
                totalExtra1 +
                totalextra2;
                txtPrecio.Text = "$ " + precioConB;
            }
            //Muestra el total con bebida incluida en el textbox
            txtPrecio.Text = "$ " + precioConB;
        }

        private void numericCantBebidas2_ValueChanged(object sender, EventArgs e)
        {
            int precioConB = 0;
            if (comboBebidas1.SelectedItem.ToString().Contains("Bebida Lata"))
            {
                precioConB =
                precioV +
                (precioP * int.Parse(numericCantBebida.Value.ToString())) +
                totalExtra1 + totalextra2;
                txtPrecio.Text = "$ " + precioConB;
            }
            else
            {
                precioConB =
                precioV +
                (precioP * int.Parse(numericCantPromo.Value.ToString())) +
                (precioB1 * int.Parse(numericCantBebida.Value.ToString())) +
                (precioB2 * int.Parse(numericCantBebidas2.Value.ToString())) +
                (precioB3 * int.Parse(numericCantBebidas3.Value.ToString())) +
                totalExtra1 +
                totalextra2;
                txtPrecio.Text = "$ " + precioConB;
            }
            //Muestra el total con bebida incluida en el textbox
            txtPrecio.Text = "$ " + precioConB;
        }

        private void numericCantBebidas3_ValueChanged(object sender, EventArgs e)
        {
            int precioConB = 0;
            if (comboBebidas1.SelectedItem.ToString().Contains("Bebida Lata"))
            {
                precioConB =
                precioV +
                (precioP * int.Parse(numericCantBebida.Value.ToString())) +
                totalExtra1 + totalextra2;
                txtPrecio.Text = "$ " + precioConB;
            }
            else
            {
                precioConB =
                precioV +
                (precioP * int.Parse(numericCantPromo.Value.ToString())) +
                (precioB1 * int.Parse(numericCantBebida.Value.ToString())) +
                (precioB2 * int.Parse(numericCantBebidas2.Value.ToString())) +
                (precioB3 * int.Parse(numericCantBebidas3.Value.ToString())) +
                totalExtra1 +
                totalextra2;
                txtPrecio.Text = "$ " + precioConB;
            }
            //Muestra el total con bebida incluida en el textbox
            txtPrecio.Text = "$ " + precioConB;
        }

        private void btnAgregarBebida_Click(object sender, EventArgs e)
        {
            cantB++;//Contador de bebidas a comprar, en esta caso se incrementa por pulsar el boton +
            if (cantB == 2)
            {
                numericCantBebidas2.Visible = true;
                comboBebidas2.Visible = true;
                labelcantB2.Visible = true;
                labelSelecB2.Visible = true;


            }
            else if (cantB == 3)
            {
                numericCantBebidas2.Visible = true;
                comboBebidas2.Visible = true;
                numericCantBebidas3.Visible = true;
                comboBebidas3.Visible = true;
                labelcantB2.Visible = true;
                labelCantB3.Visible = true;
                labelSelecB2.Visible = true;
                labelSelectB3.Visible = true;
            }
        }

        private void btnAgregarE1_Click(object sender, EventArgs e)
        {
            if (comboExtraS1.SelectedItem != null)
            {
                cantExtras1++;
                totalExtra1 = cantExtras1 * 500;
                extras1 = extras1 + " " + comboExtraS1.SelectedItem.ToString();
                if (cantExtras2 == 0)
                {
                    textBoxExtras.Text = "Extras Sandwich 1: \n" + extras1;
                }
                else
                {
                    textBoxExtras.Text = "Extras Sandwich 1: \n" + extras1 + "\r\nExtras Sandwich 2: " + extras2;
                }
                textBoxExtras.Text = "Extras Sandwich 1: \n" + extras1;
                int precioConB = totalExtra1 + totalextra2 + (precioP * int.Parse(numericCantPromo.Value.ToString())) + (precioB1 * int.Parse(numericCantBebida.Value.ToString())) + (precioB2 * int.Parse(numericCantBebidas2.Value.ToString())) + (precioB3 * int.Parse(numericCantBebidas3.Value.ToString())) + precioV;
                //Muestra el total con bebida incluida en el textbox
                txtPrecio.Text = "$ " + precioConB;
            }
            else
            {
                MessageBox.Show("Por favor, Seleccione un extra ", "Casillero extra vacío", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }


        }

        private void btnAgregarE2_Click(object sender, EventArgs e)
        {
            if (comboExtraS2.SelectedItem != null)
            {
                cantExtras2++;
                totalextra2 = cantExtras2 * 500;
                extras2 = extras2 + " " + comboExtraS2.SelectedItem.ToString();
                textBoxExtras.Text = "Extras Sandwich 1: \n" + extras1 + "\r\nExtras Sandwich 2: " + extras2;
                int precioConB = totalExtra1 + totalextra2 + (precioP * int.Parse(numericCantPromo.Value.ToString())) + (precioB1 * int.Parse(numericCantBebida.Value.ToString())) + (precioB2 * int.Parse(numericCantBebidas2.Value.ToString())) + (precioB3 * int.Parse(numericCantBebidas3.Value.ToString())) + precioV;
                //Muestra el total con bebida incluida en el textbox
                txtPrecio.Text = "$ " + precioConB;
            }
            else
            {
                MessageBox.Show("Por favor, Seleccione un extra ", "Casillero extra vacío", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAgregarPromo_Click(object sender, EventArgs e)
        {
            //Corregir si no hay promo seleccionada
            if (comboPromos.SelectedItem != null)
            {
                String[] t = txtPrecio.Text.Split("$ ");
                int subTotal = int.Parse(t[t.Length - 1]);
                String ingred = "";//Contiene los ingredientes
                                   //Empieza a concatenar los igredientes para evitar los null
                if (comboCarne1.SelectedItem != null)
                {
                    ingred = ingred + comboCarne1.SelectedItem.ToString() + ", ";
                }
                if (comboAgregado1.SelectedItem != null)
                {
                    ingred = ingred + comboAgregado1.SelectedItem.ToString() + ", ";
                }
                if (comboAgregado2.SelectedItem != null)
                {
                    ingred = ingred + comboAgregado2.SelectedItem.ToString() + ", ";
                }
                if (comboAgregado3.SelectedItem != null)
                {
                    ingred = ingred + comboAgregado3.SelectedItem.ToString() + ", ";
                }
                if (comboAgregado4.SelectedItem != null)
                {
                    ingred = ingred + comboAgregado4.SelectedItem.ToString() + ", ";
                }
                if (comboCarne2.SelectedItem != null)
                {
                    ingred = ingred + comboCarne2.SelectedItem.ToString() + ", ";
                }
                if (comboAgregado5.SelectedItem != null)
                {
                    ingred = ingred + comboAgregado5.SelectedItem.ToString() + ", ";
                }
                if (comboAgregado6.SelectedItem != null)
                {
                    ingred = ingred + comboAgregado6.SelectedItem.ToString() + ", ";
                }
                if (comboAgregado7.SelectedItem != null)
                {
                    ingred = ingred + comboAgregado7.SelectedItem.ToString() + ", ";
                }
                if (comboAgregado8.SelectedItem != null)
                {
                    ingred = ingred + comboAgregado8.SelectedItem.ToString() + ", ";
                }
                String beb = "";//Contiene las bebidas
                                //Empieza a concatenar las bebidas, evitando los null
                if (comboBebidas1.SelectedItem != null)
                {
                    beb = beb + numericCantBebida.Value.ToString() + " " + comboBebidas1.SelectedItem.ToString() + " \n";
                }
                if (comboBebidas2.SelectedItem != null)
                {
                    beb = beb + numericCantBebidas2.Value.ToString() + " " + comboBebidas2.SelectedItem.ToString() + " \n";
                }
                if (comboBebidas3.SelectedItem != null)
                {
                    beb = beb + numericCantBebidas3.Value.ToString() + " " + comboBebidas3.SelectedItem.ToString() + " \n";
                }
                if (comboPromos.SelectedItem == null)
                {
                    comboPromos.Items.Add("Ninguna");
                    comboPromos.SelectedItem = "Ninguna";
                }
                if (subTotal != 0)
                {
                    promos.Add(new Promo(int.Parse(numericCantPromo.Value.ToString()), comboPromos.SelectedItem.ToString(), ingred, beb, int.Parse(numericCantVasos.Value.ToString()), "Extras S1: " + extras1 + " \nExtras S2: " + extras2, textBoxComentarios.Text, salsas, subTotal));
                   
                }

                foreach (Promo aPromo in promos)
                {
                    MessageBox.Show(aPromo.toString(), "Revision", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);//Para comprobar si se guardaron los datos
                }
                //Después de agregar una promo, se deben vaciar los casilleros
                precioB1 = 0;
                precioB2 = 0;
                precioB3 = 0;
                precioP = 0;
                precioV = 0;
                cantB = 1;
                extras1 = "";
                extras2 = "";
                cantExtras1 = 0;
                cantExtras2 = 0;
                totalExtra1 = 0;
                totalextra2 = 0;
                salsas = "";
                comboAgregado1.Text = "";
                comboAgregado2.Text = "";
                comboAgregado3.Text = "";
                comboAgregado4.Text = "";
                comboAgregado5.Text = "";
                comboAgregado6.Text = "";
                comboAgregado7.Text = "";
                comboAgregado8.Text = "";
                comboCarne1.Text = "";
                comboCarne2.Text = "";
                comboExtraS1.Text = "";
                comboExtraS2.Text = "";
                comboBebidas1.Text = "";
                comboBebidas2.Text = "";
                numericCantBebida.Value = 0;
                numericCantBebidas2.Value = 0;
                numericCantBebidas3.Value = 0;
                numericCantPromo.Value = 0;
                numericCantVasos.Value = 0;
                textBoxComentarios.Text = "";
                textBoxExtras.Text = "";
                comboPromos.Text = "";
                checkBoxMayonesa1.Checked = false;
                checkBoxKetchup1.Checked = false;
                checkBoxMostaza1.Checked = false;
                checkBoxAji1.Checked = false;
                checkBoxMayonesa2.Checked = false;
                checkBoxKetchup2.Checked = false;
                checkBoxMostaza2.Checked = false;
                checkBoxAji2.Checked = false;
            }
        }

        private void numericCantPromo_ValueChanged(object sender, EventArgs e)
        {
            int precioConB = totalExtra1 + totalextra2 + (precioP * int.Parse(numericCantPromo.Value.ToString())) + (precioB1 * int.Parse(numericCantBebida.Value.ToString())) + (precioB2 * int.Parse(numericCantBebidas2.Value.ToString())) + (precioB3 * int.Parse(numericCantBebidas3.Value.ToString())) + precioV;
            //Muestra el total con bebida incluida en el textbox
            txtPrecio.Text = "$ " + precioConB;
        }

        private void checkBoxMayonesa1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMayonesa1.Checked)
            {
                salsas = salsas + " Mayonesa S1, ";
            }
        }

        private void checkBoxKetchup1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxKetchup1.Checked)
            {
                salsas = salsas + " Ketchup S1, ";
            }
        }

        private void checkBoxMostaza1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMostaza1.Checked)
            {
                salsas = salsas + " Mostaza S1, ";
            }
        }

        private void checkBoxAji1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAji1.Checked)
            {
                salsas = salsas + " Aji S1, ";
            }
        }

        private void checkBoxMayonesa2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMayonesa2.Checked)
            {
                salsas = salsas + " Mayonesa S2, ";
            }
        }

        private void checkBoxKetchup2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxKetchup2.Checked)
            {
                salsas = salsas + " Ketchup S2, ";
            }
        }

        private void checkBoxMostaza2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMostaza2.Checked)
            {
                salsas = salsas + " Mostaza S2, ";
            }
        }

        private void checkBoxAji2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAji2.Checked)
            {
                salsas = salsas + " Aji S2, ";
            }
        }
        //Acá va todo el/los pedido(s) del cliente para enviar a otra clase 
        public String getPedidoCliente()
        {
            String pedidoFinal = "";
            int i = 0;//Cuenta las promos
            foreach (Promo aPromo in promos)
            {
                i++;//Para contar la cantidad de pedidos
                pedidoFinal = pedidoFinal + "\nPedido " + i + ": \n" + aPromo.toString() + "\n"; //Concatena el contenido de los pedidos y los separa segun la cantidad de promos distintos que ha pedido
            }
            return pedidoFinal;
        }
        //Acá va todo el total a pagar para enviar a otra clase 
        public int getTotal()
        {
            int totalAPagar = 0;
            foreach (Promo aPromo in promos)
            {
                totalAPagar = totalAPagar + aPromo.getTotal(); //Suma el total de los pedidos
            }
            return totalAPagar;

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            String[] t = txtPrecio.Text.Split("$ ");
            int subTotal = int.Parse(t[t.Length - 1]);
            String ingred = "";//Contiene los ingredientes
                               //Empieza a concatenar los igredientes para evitar los null
            if (comboCarne1.SelectedItem != null)
            {
                ingred = ingred + comboCarne1.SelectedItem.ToString() + ", ";
            }
            if (comboAgregado1.SelectedItem != null)
            {
                ingred = ingred + comboAgregado1.SelectedItem.ToString() + ", ";
            }
            if (comboAgregado2.SelectedItem != null)
            {
                ingred = ingred + comboAgregado2.SelectedItem.ToString() + ", ";
            }
            if (comboAgregado3.SelectedItem != null)
            {
                ingred = ingred + comboAgregado3.SelectedItem.ToString() + ", ";
            }
            if (comboAgregado4.SelectedItem != null)
            {
                ingred = ingred + comboAgregado4.SelectedItem.ToString() + ", ";
            }
            if (comboCarne2.SelectedItem != null)
            {
                ingred = ingred + comboCarne2.SelectedItem.ToString() + ", ";
            }
            if (comboAgregado5.SelectedItem != null)
            {
                ingred = ingred + comboAgregado5.SelectedItem.ToString() + ", ";
            }
            if (comboAgregado6.SelectedItem != null)
            {
                ingred = ingred + comboAgregado6.SelectedItem.ToString() + ", ";
            }
            if (comboAgregado7.SelectedItem != null)
            {
                ingred = ingred + comboAgregado7.SelectedItem.ToString() + ", ";
            }
            if (comboAgregado8.SelectedItem != null)
            {
                ingred = ingred + comboAgregado8.SelectedItem.ToString() + ", ";
            }
            String beb = "";//Contiene las bebidas
                            //Empieza a concatenar las bebidas, evitando los null
            if (comboBebidas1.SelectedItem != null)
            {
                beb = beb + numericCantBebida.Value.ToString() + " " + comboBebidas1.SelectedItem.ToString() + " \n";
            }
            if (comboBebidas2.SelectedItem != null)
            {
                beb = beb + numericCantBebidas2.Value.ToString() + " " + comboBebidas2.SelectedItem.ToString() + " \n";
            }
            if (comboBebidas3.SelectedItem != null)
            {
                beb = beb + numericCantBebidas3.Value.ToString() + " " + comboBebidas3.SelectedItem.ToString() + " \n";
            }
            if (comboPromos.SelectedItem == null)
            {
                comboPromos.Items.Add("Ninguna");
                comboPromos.SelectedItem = "Ninguna";
            }
            if (subTotal != 0)
            {
                promos.Add(new Promo(int.Parse(numericCantPromo.Value.ToString()), comboPromos.SelectedItem.ToString(), ingred, beb, int.Parse(numericCantVasos.Value.ToString()), "Extras S1: " + extras1 + " \nExtras S2: " + extras2, textBoxComentarios.Text, salsas, subTotal));
              
            }

            //Después de agregar una promo, se deben vaciar los casilleros
            precioB1 = 0;
            precioB2 = 0;
            precioB3 = 0;
            precioP = 0;
            precioV = 0;
            cantB = 1;
            extras1 = "";
            extras2 = "";
            cantExtras1 = 0;
            cantExtras2 = 0;
            totalExtra1 = 0;
            totalextra2 = 0;
            salsas = "";
            comboAgregado1.Text = "";
            comboAgregado2.Text = "";
            comboAgregado3.Text = "";
            comboAgregado4.Text = "";
            comboAgregado5.Text = "";
            comboAgregado6.Text = "";
            comboAgregado7.Text = "";
            comboAgregado8.Text = "";
            comboCarne1.Text = "";
            comboCarne2.Text = "";
            comboExtraS1.Text = "";
            comboExtraS2.Text = "";
            comboBebidas1.Text = "";
            comboBebidas2.Text = "";
            numericCantBebida.Value = 0;
            numericCantBebidas2.Value = 0;
            numericCantBebidas3.Value = 0;
            numericCantPromo.Value = 0;
            numericCantVasos.Value = 0;
            textBoxComentarios.Text = "";
            textBoxExtras.Text = "";
            comboPromos.Text = "";
            checkBoxMayonesa1.Checked = false;
            checkBoxKetchup1.Checked = false;
            checkBoxMostaza1.Checked = false;
            checkBoxAji1.Checked = false;
            checkBoxMayonesa2.Checked = false;
            checkBoxKetchup2.Checked = false;
            checkBoxMostaza2.Checked = false;
            checkBoxAji2.Checked = false;

            // hacer 0 los contadores de dcto a la bd

            ConfirmarPedido cp = new ConfirmarPedido();
            cp.Show();
            this.Close();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            HistorialVentas hv = new HistorialVentas();
            hv.Show();
        }
        public void vaciarLista()
        {
            promos.Clear();
            precioB1 = 0;
            precioB2 = 0;
            precioB3 = 0;
            precioP = 0;
            precioV = 0;
            cantB = 1;
            extras1 = "";
            extras2 = "";
            cantExtras1 = 0;
            cantExtras2 = 0;
            totalExtra1 = 0;
            totalextra2 = 0;
            salsas = "";
            comboAgregado1.Text = "";
            comboAgregado2.Text = "";
            comboAgregado3.Text = "";
            comboAgregado4.Text = "";
            comboAgregado5.Text = "";
            comboAgregado6.Text = "";
            comboAgregado7.Text = "";
            comboAgregado8.Text = "";
            comboCarne1.Text = "";
            comboCarne2.Text = "";
            comboExtraS1.Text = "";
            comboExtraS2.Text = "";
            comboBebidas1.Text = "";
            comboBebidas2.Text = "";
            numericCantBebida.Value = 0;
            numericCantBebidas2.Value = 0;
            numericCantBebidas3.Value = 0;
            numericCantPromo.Value = 0;
            numericCantVasos.Value = 0;
            textBoxComentarios.Text = "";
            textBoxExtras.Text = "";
            comboPromos.Text = "";
            checkBoxMayonesa1.Checked = false;
            checkBoxKetchup1.Checked = false;
            checkBoxMostaza1.Checked = false;
            checkBoxAji1.Checked = false;
            checkBoxMayonesa2.Checked = false;
            checkBoxKetchup2.Checked = false;
            checkBoxMostaza2.Checked = false;
            checkBoxAji2.Checked = false;

            //variables contadoras para el dcto vuelven a 0
            cantPromoS = 0;
            cantMini = 0;
            cantManso = 0;
            cantCompP = 0;
            cantCompM = 0;
            cantBebida1 = 0;
            cantBebida2 = 0;
            cantBebida3 = 0;
            cantVasos = 0;
            cantCarne1 = 0;
            cantCarne2 = 0;
            cantVienesas = 0;


        }
        public String getImpresionC()
        {
            String imp = "";
            foreach (Promo aPromo in promos)
            {
                imp += aPromo.impresion() + "\n***********************\n";
            }
            return imp;
        }

        private void btnEliminarVenta_Click(object sender, EventArgs e)
        {
            Eliminar_venta ev = new Eliminar_venta();
            //Para evitar que se abran múltiples formularios del mismo tipo
            if (Application.OpenForms[ev.Name] == null)
            {
                ev.Show();
            }
            else
            {
                Application.OpenForms[ev.Name].Activate();
            }
        }
    }
}
