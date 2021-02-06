using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace RavaSandwich
{
    public partial class ConfirmarPedido : Form
    {
        static String metodosPago = "";
        String cliente = "";
        String fecha = DateTime.Now.ToString("d");
        public ConfirmarPedido()
        {
            InitializeComponent();
            Login lo = new Login();
            Ventas ve = new Ventas();
            labelNombreCajero.Text = lo.getNombre();
            textBoxTotalAPagar.Text = ve.getTotal() + "";
            checkBoxPYEfectivo.Visible = false;
            checkBoxPYDescuentos.Visible = false;
            checkBoxPYOnline.Visible = false;
            textBoxDescuento.Visible = false;
            labelIndicarDescto.Visible = false;
            String[] pedido = ve.getPedidoCliente().Split("\n");
            for (int i = 0; i < pedido.Length - 1; i++)
            {
                listBoxPedido.Items.Add(pedido[i]);
            }
            textBoxDescuento.Text = "0";
        }

        private void checkBoxPedidosYa_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPedidosYa.Checked == true)
            {
                checkBoxPYEfectivo.Visible = true;
                checkBoxPYDescuentos.Visible = true;
                checkBoxPYOnline.Visible = true;
                checkBoxTansbank.Checked = false;
                checkBoxConsumoLocal.Checked = false;
                checkBoxEfectivo.Checked = false;
                checkBoxPYDescuentos.Checked = false;
                checkBoxPYEfectivo.Checked = false;
                checkBoxPYOnline.Checked = false;
            }
            else
            {
                checkBoxPYEfectivo.Visible = false;
                checkBoxPYDescuentos.Visible = false;
                checkBoxPYOnline.Visible = false;
                textBoxDescuento.Visible = false;
                labelIndicarDescto.Visible = false;
            }
        }

        private void checkBoxPYDescuentos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPYDescuentos.Checked == true)
            {
                textBoxDescuento.Visible = true;
                labelIndicarDescto.Visible = true;

            }
            else
            {
                textBoxDescuento.Visible = false;
                labelIndicarDescto.Visible = false;
            }
            if (checkBoxPYDescuentos.Checked == true)
            {
                metodosPago = "Pedidos Ya, con descuento";
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            Ventas ve = new Ventas();
            Login lo = new Login();
            cliente = "Cliente: " + textBoxNombreCliente.Text;//Aqui guarda el nombre del cliente, si se pone más abajo no lo guarda xd
            //Fecha y hora actual:
            String fechaHora = DateTime.Now.ToString("G");
            //Pregunta si no hay datos nulos en los datos solicitados (Lista de productos) o si no hay algun metodo de pago seleccionado
            if (textBoxNombreCliente.Text != "" && (checkBoxEfectivo.Checked == true || checkBoxConsumoLocal.Checked == true || checkBoxPedidosYa.Checked == true || checkBoxTansbank.Checked == true))
            {
                if (checkBoxPedidosYa.Checked == true)
                {
                    if (checkBoxPYDescuentos.Checked == true)
                    {
                        if (textBoxDescuento.Text == "")
                        {
                            MessageBox.Show("Por favor, ingrese el descuento ", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
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
                            //Envía la venta a la BD --Provisorio
                            comm.CommandText = "INSERT into ventas(nombre_cliente, nombre_cajero, pedido, total_a_pagar, metodo_pago, fecha_venta, subtotal, descuentos) VALUES ('" + textBoxNombreCliente.Text + "','" + lo.getNombre() + "', '" + ve.getPedidoCliente() + "'," + totalVenta() + ",'" + metodosPago + "', '" + fechaHora + "', " + ve.getTotal() + "," + textBoxDescuento.Text + ")";
                            //Leer BD
                            NpgsqlDataReader dr = comm.ExecuteReader();
                            MessageBox.Show("Se ha registrado la venta de manera Exitosa", "Venta Hecha", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            //Cerrar comandos
                            comm.Dispose();
                            //Desconectar BD
                            conn.Close();
                            ve.Show();
                            this.Close();

                            //Crear impresion
                            printDocument1 = new PrintDocument();
                            PrinterSettings ps = new PrinterSettings();
                            printDocument1.PrinterSettings = ps;
                            printDocument1.PrintPage += Imprimir;
                            printDocument1.Print();
                            descuentosEnInventario(ve.getPedidoCliente());
                            ve.vaciarLista();
                        }

                    }
                    else
                    {
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
                        //Envía la venta a la BD --Provisorio
                        comm.CommandText = "INSERT into ventas(nombre_cliente, nombre_cajero, pedido, total_a_pagar, metodo_pago, fecha_venta, subtotal, descuentos) VALUES ('" + textBoxNombreCliente.Text + "','" + lo.getNombre() + "', '" + ve.getPedidoCliente() + "'," + totalVenta() + ",'" + metodosPago + "', '" + fechaHora + "', " + ve.getTotal() + "," + textBoxDescuento.Text + ")";
                        //Leer BD
                        NpgsqlDataReader dr = comm.ExecuteReader();
                        MessageBox.Show("Se ha registrado la venta de manera Exitosa", "Venta Hecha", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        //Cerrar comandos
                        comm.Dispose();
                        //Desconectar BD
                        conn.Close();
                        ve.Show();
                        this.Close();

                        //Crear impresion
                        printDocument1 = new PrintDocument();
                        PrinterSettings ps = new PrinterSettings();
                        printDocument1.PrinterSettings = ps;
                        printDocument1.PrintPage += Imprimir;
                        printDocument1.Print();
                        descuentosEnInventario(ve.getPedidoCliente());
                        ve.vaciarLista();
                    }
                }
                else
                {
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
                    //Envía la venta a la BD --Provisorio
                    comm.CommandText = "INSERT into ventas(nombre_cliente, nombre_cajero, pedido, total_pago, tipo_pago, fecha, subtotal, descuento) VALUES ('" + textBoxNombreCliente.Text + "','" + lo.getNombre() + "', '" + ve.getPedidoCliente() + "'," + totalVenta() + ",'" + metodosPago + "', '" + fechaHora + "', " + ve.getTotal() + "," + textBoxDescuento.Text + ")";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    MessageBox.Show("Se ha registrado la venta de manera Exitosa", "Venta Hecha", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                    ve.Show();
                    this.Close();

                    //Crear impresion
                    printDocument1 = new PrintDocument();
                    PrinterSettings ps = new PrinterSettings();
                    printDocument1.PrinterSettings = ps;
                    printDocument1.PrintPage += Imprimir;
                    printDocument1.Print();
                    descuentosEnInventario(ve.getPedidoCliente());
                    ve.vaciarLista();
                }



            }
            else //En caso de que esté seleccionado un valor nulo
            {
                MessageBox.Show("Por favor, llene los campos solicitados ", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }

        }

        private void buttonAtras_Click(object sender, EventArgs e)
        {

            this.Close();
            Ventas ve = new Ventas();
            ve.vaciarLista();
            ve.Show();
        }

        private void checkBoxEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEfectivo.Checked == true)
            {
                metodosPago = "Efectivo";
                checkBoxTansbank.Checked = false;
                checkBoxConsumoLocal.Checked = false;
                checkBoxPedidosYa.Checked = false;
            }

        }

        private void checkBoxTansbank_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTansbank.Checked == true)
            {
                metodosPago = "Transbank";
                checkBoxEfectivo.Checked = false;
                checkBoxConsumoLocal.Checked = false;
                checkBoxPedidosYa.Checked = false;
            }
        }

        private void checkBoxConsumoLocal_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxConsumoLocal.Checked == true)
            {
                metodosPago = "Consumo Local";
                checkBoxTansbank.Checked = false;
                checkBoxEfectivo.Checked = false;
                checkBoxPedidosYa.Checked = false;
            }
        }

        private void checkBoxPYEfectivo_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxPYEfectivo.Checked == true)
            {
                metodosPago = "Pedidos Ya, efectivo";
                checkBoxPYOnline.Checked = false;

            }
        }

        private void checkBoxPYOnline_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPYOnline.Checked == true)
            {
                metodosPago = "Pedidos Ya, online";
                checkBoxPYDescuentos.Checked = false;
                checkBoxPYEfectivo.Checked = false;
            }
        }
        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            Font fuente = new Font("Times New Roman", 11, FontStyle.Regular, GraphicsUnit.Point);
            int ancho = 200;
            int salto = 20;
            String hora = DateTime.Now.ToString("t"); ;
            Ventas v = new Ventas();
            String ticket = "\tRAVA SANDWICH\n" + cliente + "\n" + v.getImpresionC() + "\n\t" + hora;

            //Formato rectangulo =  (posicion x(horizontal) , posicion y(vertical), ancho, alto)
            e.Graphics.DrawString(ticket, fuente, Brushes.Black, new RectangleF(0, salto += 20, ancho, 99999999));
        }
        //funcion que calcula el total con o sin descuento
        private int totalVenta()
        {
            Ventas v = new Ventas();
            int total = v.getTotal();
            if (checkBoxPYDescuentos.Checked == true)
            {
                if (textBoxDescuento.Text != "")//Si hay algo en descuento, se hace en descuento
                {
                    total = total - int.Parse(textBoxDescuento.Text);
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese el descuento ", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }

            }
            return total;
        }

        public void descuentosEnInventario(String pedido)
        {
            Ventas v = new Ventas();
            String fecha = DateTime.Now.ToString("d");
            double REEMPLAZAR = 1;

            if (pedido.Contains("Promo Sandwich"))
            {
                
                descontarProducto("Promo Sandwich", REEMPLAZAR);
            }

            if (pedido.Contains("Mini"))
            {
                descontarProducto("Mini", REEMPLAZAR);
            }

            if (pedido.Contains("Mansos"))
            {
                if (pedido.Contains("MT"))
                {
                    descontarProducto("MT", REEMPLAZAR);
                }
                else
                {
                    descontarProducto("Mansos", REEMPLAZAR);
                }
            }

            if (pedido.Contains("Completo"))
            {
                if (pedido.Contains("Minic"))
                {
                    descontarProducto("Minic", REEMPLAZAR);
                }
                else
                {
                    if (pedido.Contains("AS"))
                    {
                        descontarProducto("As", REEMPLAZAR);
                    }
                    else
                    {
                        descontarProducto("Promo Completo", REEMPLAZAR);
                    }
                }
            }

            //*****************************************************************************************************************************************************************************************************************************+
            // Bebidas con getcant1()
            if (pedido.Contains("Bebida 0.5L") && v.getComboboxbeb1() != null)
            {
                descontarProducto("Bebida 0.5L", REEMPLAZAR);
            }
            if (pedido.Contains("Bebida 1.5L") && v.getComboboxbeb1() != null)
            {
                descontarProducto("Bebida 1.5L", REEMPLAZAR);
            }
            if (pedido.Contains("Nectar 1.5L") && v.getComboboxbeb1() != null)
            {
                descontarProducto("Nectar 1.5L", REEMPLAZAR);
            }
            if (pedido.Contains("Bebida Express") && v.getComboboxbeb1() != null)
            {
                descontarProducto("Bebida Express", REEMPLAZAR);
            }
            if (pedido.Contains("Nectar Express") && v.getComboboxbeb1() != null)
            {
                descontarProducto("Nectar Express", REEMPLAZAR);
            }
            if (pedido.Contains("Nectar Boca Ancha") && v.getComboboxbeb1() != null)
            {
                descontarProducto("Nectar Boca Ancha", REEMPLAZAR);
            }
            if (pedido.Contains("Cafe") && v.getComboboxbeb1() != null)
            {
                descontarProducto("Cafe", REEMPLAZAR);
            }
            if (pedido.Contains("Te") && v.getComboboxbeb1() != null)
            {
                descontarProducto("Te", REEMPLAZAR);
            }
            if (pedido.Contains("Milo") && v.getComboboxbeb1() != null)
            {
                descontarProducto("Milo", REEMPLAZAR);
            }
            if (pedido.Contains("Monster") && v.getComboboxbeb1() != null)
            {
                descontarProducto("Monster", REEMPLAZAR);
            }
            if (pedido.Contains("Bebida Lata") && v.getComboboxbeb1() != null)
            {
                descontarProducto("Bebida Lata", REEMPLAZAR);
            }
            //***************************************************************************************************************************************************************************************************************************************************

            //*****************************************************************************************************************************************************************************************************************************
            // Bebidas con getcant2()
            if (pedido.Contains("Bebida 0.5L") && v.getComboboxbeb2() != null)
            {
                descontarProducto("Bebida 0.5L", REEMPLAZAR);
            }
            if (pedido.Contains("Bebida 1.5L") && v.getComboboxbeb2() != null)
            {
                descontarProducto("Bebida 1.5L", REEMPLAZAR);
            }
            if (pedido.Contains("Nectar 1.5L") && v.getComboboxbeb2() != null)
            {
                descontarProducto("Nectar 1.5L", REEMPLAZAR);
            }
            if (pedido.Contains("Bebida Express") && v.getComboboxbeb2() != null)
            {
                descontarProducto("Bebida Express", REEMPLAZAR);
            }
            if (pedido.Contains("Nectar Express") && v.getComboboxbeb2() != null)
            {
                descontarProducto("Nectar Express", REEMPLAZAR);
            }
            if (pedido.Contains("Nectar Boca Ancha") && v.getComboboxbeb2() != null)
            {
                descontarProducto("Nectar Boca Ancha", REEMPLAZAR);
            }
            if (pedido.Contains("Cafe") && v.getComboboxbeb2() != null)
            {
                descontarProducto("Cafe", REEMPLAZAR);
            }
            if (pedido.Contains("Te") && v.getComboboxbeb2() != null)
            {
                descontarProducto("Te", REEMPLAZAR);
            }
            if (pedido.Contains("Milo") && v.getComboboxbeb2() != null)
            {
                descontarProducto("Milo", REEMPLAZAR);
            }
            if (pedido.Contains("Monster") && v.getComboboxbeb2() != null)
            {
                descontarProducto("Monster", REEMPLAZAR);
            }
            if (pedido.Contains("Bebida Lata") && v.getComboboxbeb2() != null)
            {
                descontarProducto("Bebida Lata", REEMPLAZAR);
            }
            //***************************************************************************************************************************************************************************************************************************************************

            //*****************************************************************************************************************************************************************************************************************************
            // Bebidas con getcant3()
            if (pedido.Contains("Bebida 0.5L") && v.getComboboxbeb3() != null)
            {
                descontarProducto("Bebida 0.5L", REEMPLAZAR);
            }
            if (pedido.Contains("Bebida 1.5L") && v.getComboboxbeb3() != null)
            {
                descontarProducto("Bebida 1.5L", REEMPLAZAR);
            }
            if (pedido.Contains("Nectar 1.5L") && v.getComboboxbeb3() != null)
            {
                descontarProducto("Nectar 1.5L", REEMPLAZAR);
            }
            if (pedido.Contains("Bebida Express") && v.getComboboxbeb3() != null)
            {
                descontarProducto("Bebida Express", REEMPLAZAR);
            }
            if (pedido.Contains("Nectar Express") && v.getComboboxbeb3() != null)
            {
                descontarProducto("Nectar Express", REEMPLAZAR);
            }
            if (pedido.Contains("Nectar Boca Ancha") && v.getComboboxbeb3() != null)
            {
                descontarProducto("Nectar Boca Ancha", REEMPLAZAR);
            }
            if (pedido.Contains("Cafe") && v.getComboboxbeb3() != null)
            {
                descontarProducto("Cafe", REEMPLAZAR);
            }
            if (pedido.Contains("Te") && v.getComboboxbeb3() != null)
            {
                descontarProducto("Te", REEMPLAZAR);
            }
            if (pedido.Contains("Milo") && v.getComboboxbeb3() != null)
            {
                descontarProducto("Milo", REEMPLAZAR);
            }
            if (pedido.Contains("Monster") && v.getComboboxbeb3() != null)
            {
                descontarProducto("Monster", REEMPLAZAR);
            }
            if (pedido.Contains("Bebida Lata") && v.getComboboxbeb3() != null)
            {
                descontarProducto("Bebida Lata", REEMPLAZAR);
            }
            //***************************************************************************************************************************************************************************************************************************************************


            // descuento de vasos
            if (pedido.Contains("Vaso"))
            {
                descontarProducto("Vasos", REEMPLAZAR);
            }
        }

        private void DctoCarneBD()
        {
            Ventas v = new Ventas();
          
            String pedido = "" + v.getPedidoCliente();
            double REEMPLAZAR = 1;
            if (pedido.Contains("MT")) // Descuentos de carne es las torres
            {
                if (pedido.Contains("1"))
                {
                    descontarProducto("Churrasco", REEMPLAZAR);
                    descontarProducto("Ave", REEMPLAZAR);
                }
                if (pedido.Contains("2"))
                {
                    descontarProducto("Mechada", REEMPLAZAR);
                    descontarProducto("Lomo", REEMPLAZAR);
                }
                if (pedido.Contains("3"))
                {
                    descontarProducto("Churrasco", REEMPLAZAR);
                    descontarProducto("Lomo", REEMPLAZAR);
                }
                if (pedido.Contains("5"))
                {
                    descontarProducto("Churrasco", REEMPLAZAR);
                    descontarProducto("Mechada", REEMPLAZAR);
                }
                if (pedido.Contains("MV")) // descuentos en las carnes de mansos dobles
                {
                    if (pedido.Contains("1"))
                    {
                        descontarProducto("DobleLomo", REEMPLAZAR);
                    }
                    if (pedido.Contains("2"))
                    {
                        descontarProducto("DobleChurrasco", REEMPLAZAR);
                    }
                }
                if (pedido.Contains("MG"))
                {
                    descontarProducto("DobleAve", REEMPLAZAR);
                }
                if (pedido.Contains("MN"))
                {
                    descontarProducto("DobleMechada", REEMPLAZAR);
                }
                if (pedido.Contains("MC"))
                {
                    descontarProducto("DobleChurrasco", REEMPLAZAR);
                }
                else
                {
                    if (pedido.Contains("Lomo")) // descuento en carnes de mansos normales
                    {
                        descontarProducto("Lomo", REEMPLAZAR);
                    }
                    if (pedido.Contains("Ave"))
                    {
                        descontarProducto("Ave", REEMPLAZAR);
                    }
                    if (pedido.Contains("Churrasco"))
                    {
                        descontarProducto("Churrasco", REEMPLAZAR);
                    }
                    if (pedido.Contains("Mechada"))
                    {
                        descontarProducto("Mechada", REEMPLAZAR);
                    }
                }
            }
            if (pedido.Contains("Promo Sandwich")) // descuento de carne de promos
            {
                if (pedido.Contains("Lomo"))
                {
                    descontarProducto("Lomo", REEMPLAZAR);
                }
                if (pedido.Contains("Ave"))
                {
                    descontarProducto("Ave", REEMPLAZAR);
                }
                if (pedido.Contains("Churrasco"))
                {
                    descontarProducto("Churrasco", REEMPLAZAR);
                }
                if (pedido.Contains("Mechada"))
                {
                    descontarProducto("Mechada", REEMPLAZAR);
                }
            }
            if (pedido.Contains("Mini")) // descuento en carnes de sandwich minis
            {
                if (pedido.Contains("Lomo")) 
                {
                    descontarProducto("MinLomo", REEMPLAZAR);
                }
                if (pedido.Contains("Ave"))
                {
                    descontarProducto("MinAve", REEMPLAZAR);
                }
                if (pedido.Contains("Churrasco"))
                {
                    descontarProducto("MinChurrasco", REEMPLAZAR);
                }
                if (pedido.Contains("Mechada"))
                {
                    descontarProducto("MinMechada", REEMPLAZAR);
                }
            }
            if (pedido.Contains("Comp"))
            {
                if (pedido.Contains("Minic"))
                {
                    descontarProducto("VMinic", REEMPLAZAR);
                }
                else
                {
                    if (pedido.Contains("As"))
                    {
                        descontarProducto("MechAS", REEMPLAZAR);
                    }
                    else
                    {
                        descontarProducto("VPromo", REEMPLAZAR);
                    }
                }
            }
        }
        private void descontarProducto(String producto, double cantidad)
        {
            String formula = "";
            String tipoProducto = "";

            // Consumo de pan
            if (producto == "Promo Sandwich")
            {
                formula = "consumo_prod + (" + cantidad + ") * 2";
                tipoProducto = "Mini";
            }
            
            if (producto == "Mini")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Mini";
            }
            
            if (producto == "Mansos")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Mansos";
            }

            if (producto == "MT")
            {
                formula = "consumo_prod + (" + cantidad + ") * 1.5";
                tipoProducto = "Mansos";
            }
            
            if (producto == "Promo Completo")
            {
                formula = "consumo_prod + (" + cantidad + ") * 2";
                tipoProducto = "Completo";
            }

            if (producto == "Minic")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Completo";
            }

            if (producto == "As")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Completo";
            }
            
            //CONSUMO DE BEBIDAS
            if (producto == "Bebida 0.5L")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Bebida 0.5L";
            }

            if (producto == "Bebida 1.5L")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Bebida 1.5L";
            }

            if (producto == "Nectar 1.5L")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Nectar 1.5L";
            }

            if (producto == "Nectar Express")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Nectar Express";
            }

            if (producto == "Bebida Express")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Bebida Express";
            }

            if (producto == "Monster")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Monster";
            }

            if (producto == "Nectar Boca Ancha")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Nectar Boca Ancha";
            }

            if (producto == "Cafe")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Cafe";
            }

            if (producto == "Te")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Te";
            }

            if (producto == "Milo")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Milo";
            }

            if (producto == "Lata")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Bebida Lata";
            }

            if (producto == "Vasos")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Vaso Plastico";
            }


            //CONSUMO DE CARNES
            if (producto == "Churrasco")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Churrasco";
            }

            if (producto == "Mechada")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Mechada";
            }

            if (producto == "Lomo")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Lomo";
            }

            if (producto == "Ave")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Ave";
            }
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            if (producto == "MinChurrasco")
            {
                formula = "consumo_prod + (" + cantidad + ") * 0.5";
                tipoProducto = "Churrasco";
            }

            if (producto == "MinMechada")
            {
                formula = "consumo_prod + (" + cantidad + ") * 0.5";
                tipoProducto = "Mechada";
            }

            if (producto == "MinLomo")
            {
                formula = "consumo_prod + (" + cantidad + ") * 0.5";
                tipoProducto = "Lomo";
            }

            if (producto == "MinAve")
            {
                formula = "consumo_prod + (" + cantidad + ") * 0.5";
                tipoProducto = "Ave";
            }

            //*********************************************************************************
            if (producto == "DobleChurrasco")
            {
                formula = "consumo_prod + (" + cantidad + ") * 2";
                tipoProducto = "Churrasco";
            }

            if (producto == "DobleMechada")
            {
                formula = "consumo_prod + (" + cantidad + ") * 2";
                tipoProducto = "Mechada";
            }

            if (producto == "DobleLomo")
            {
                formula = "consumo_prod + (" + cantidad + ") * 2";
                tipoProducto = "Lomo";
            }

            if (producto == "DobleAve")
            {
                formula = "consumo_prod + (" + cantidad + ") * 2";
                tipoProducto = "Ave";
            }

            if (producto == "VPromo")
            {
                formula = "consumo_prod + (" + cantidad + ") * 2";
                tipoProducto = "Vienesa";
            }

            if (producto == "VMinic")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "Vienesa";
            }

            if (producto == "MechAS")
            {
                formula = "consumo_prod + " + cantidad + "";
                tipoProducto = "As";
            }

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
            comm.CommandText = "UPDATE productos SET consumo_prod =" + formula + ", fecha = '" + fecha + "' WHERE nombre_prod ='"+ tipoProducto +"'; " +
            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='" + tipoProducto + "'";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();
        }
    }
}
