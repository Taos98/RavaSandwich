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
        Login lg = new Login();
        public Ventas()
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
            comm.CommandText = "SELECT id, categoria from promo ORDER BY id ASC";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())//Si la tabla tiene 1 o más filas...
            {
                //Rellena la lista desplegable
                comboPromos.Items.Add(dr.GetString(1)+" - "+dr.GetString(0));
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();

            //Llenar los agregados
            String [] agregados = new String[] { "Aceituna","Aji Verde","Cebolla", "Champiñon", "Choclo", "Chucrut", "Huevo", "Morron", "Palta", "Pepinillo",  "Poroto Verde",  "Queso", "Tocino", "Tomate", " " };
            for (int i = 0; i<agregados.Length; i++)
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
            String[] carnes = new String[] { "Ave", "Churrasco", "Lomo", "Mechada", " " };
            for (int i = 0; i < carnes.Length; i++)
            {
                comboCarne1.Items.Add(carnes[i]);
                comboCarne2.Items.Add(carnes[i]);
            }
            //Llenar las bebidas
            String[] bebidas = new String[] {"Bebida 0,5L", "Bebida 1,5L", "Bebida mini", "Café", "Express", "Milo","Nectar", "Nectar 1,5L","Nectar Express", "Te" };
            for (int i = 0; i < bebidas.Length; i++)
            {
                comboBebidas.Items.Add(bebidas[i]);
                
            }
        }

        private void Ventas_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            //Despues separar los menus segun rol
            MenuAdmin ma = new MenuAdmin();
            ma.Show();
            this.Close();

        }

        private void comboPromos_SelectedIndexChanged(object sender, EventArgs e)
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
            //Separa el contenido del comboBox que viene como "categoria - id" a un arreglo
            String[] promocion = comboPromos.SelectedItem.ToString().Split(' ');
            comm.CommandText = "SELECT tipo_carne1, agregado1, agregado2, agregado3, agregado4, tipo_carne2, agregado5, agregado6, agregado7, agregado8, precio from promo where id ='"+promocion[promocion.Length-1]+"'";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())//Si la tabla tiene 1 o más filas...
            {
                //Rellena la lista desplegable
                /*comboCarne1.Items.Add(dr.GetString(0));
                comboAgregado1.Items.Add("Chucrut));
                comboAgregado2.Items.Add(dr.GetString(2));
                comboAgregado3.Items.Add(dr.GetString(3));
                comboAgregado4.Items.Add(dr.GetString(4));
                comboCarne2.Items.Add(dr.GetString(5));
                comboAgregado5.Items.Add(dr.GetString(6));
                comboAgregado6.Items.Add(dr.GetString(7));
                comboAgregado7.Items.Add(dr.GetString(8));
                comboAgregado8.Items.Add(dr.GetString(9));*/
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
                txtPrecio.Text = "$ "+dr.GetInt32(10);

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

  
    }
}
