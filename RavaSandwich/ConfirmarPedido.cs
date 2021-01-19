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
        public ConfirmarPedido()
        {
            InitializeComponent();
            Login lo = new Login();
            Ventas ve = new Ventas();
            labelNombreCajero.Text = lo.getNombre();
            textBoxTotalAPagar.Text = ve.getTotal()+"";
            checkBoxPYEfectivo.Visible = false;
            checkBoxPYDescuentos.Visible = false;
            checkBoxPYOnline.Visible = false;
            textBoxDescuento.Visible = false;
            labelIndicarDescto.Visible = false;
            String[] pedido = ve.getPedidoCliente().Split("\n");
            for(int i = 0; i<pedido.Length-1; i++)
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
            if (textBoxNombreCliente.Text!="" && (checkBoxEfectivo.Checked == true || checkBoxConsumoLocal.Checked == true || checkBoxPedidosYa.Checked == true || checkBoxTansbank.Checked == true))
            {
                if (checkBoxPedidosYa.Checked == true)
                {
                    if(checkBoxPYDescuentos.Checked == true)
                    {
                        if (textBoxDescuento.Text == "")
                        {
                            MessageBox.Show("Por favor, ingrese el descuento ", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        }
                        else
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
                        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; Port = 5432; User Id = postgres; Password = censurado; Database = Rava_Sandwich");
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
                    NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; Port = 5432; User Id = postgres; Password = censurado; Database = Rava_Sandwich");
                    //Abrir BD
                    conn.Open();
                    //Crear objeto de comandos
                    NpgsqlCommand comm = new NpgsqlCommand();
                    //Crear objeto conexión
                    comm.Connection = conn;
                    //No se que hace xd
                    comm.CommandType = CommandType.Text;
                    //Envía la venta a la BD --Provisorio
                    comm.CommandText = "INSERT into ventas(nombre_cliente, nombre_cajero, pedido, total_pago, tipo_pago, fecha, subtotal, descuento) VALUES ('" + textBoxNombreCliente.Text + "','" + lo.getNombre() + "', '" + ve.getPedidoCliente() + "'," + totalVenta() + ",'" + metodosPago + "', '" + fechaHora + "', "+ve.getTotal()+","+textBoxDescuento.Text+")";
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
            if(checkBoxPYDescuentos.Checked == true)
            {
                if (textBoxDescuento.Text!="")//Si hay algo en descuento, se hace en descuento
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
            
            if (pedido.Contains("Promo Sandwich"))
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
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getPanSandwich() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" +fecha+"' WHERE nombre_prod ='Mini'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
                DctoCarneBD();
            }
            
            if (pedido.Contains("Mini"))
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
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getPanMini() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Mini'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
                DctoCarneBD();
            }
            
            if (pedido.Contains("Mansos"))
            {
                if (pedido.Contains("MT"))
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + (" + v.getPanManso() + " * 1.5 ), stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Manso'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                    DctoCarneBD();
                }
                else
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getPanManso() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Manso'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                    DctoCarneBD();
                }
            }
            
            if (pedido.Contains("Completo"))
            {
                if (pedido.Contains("Minic"))
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getPanCompleto() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Completo'";
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                    DctoCarneBD();
                }
                else
                {
                    if (pedido.Contains("AS"))
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getPanCompleto() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Completo'";
                        //Leer BD
                        NpgsqlDataReader dr = comm.ExecuteReader();
                        //Cerrar comandos
                        comm.Dispose();
                        //Desconectar BD
                        conn.Close();
                        DctoCarneBD();
                    }
                    else
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getPanPromoCompleto() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Completo'";
                        //Leer BD
                        NpgsqlDataReader dr = comm.ExecuteReader();
                        //Cerrar comandos
                        comm.Dispose();
                        //Desconectar BD
                        conn.Close();
                        DctoCarneBD();
                    }
                }   
            }
            // Bebidas
            if (pedido.Contains("Bebida 0.5L"))
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
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantB1() + "+" + v.getCantB2() + "+" + v.getCantB3() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Bebida 0.5L'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();

            }
            if (pedido.Contains("Bebida 1.5L"))
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
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + "+" + v.getCantB2() + "+" + v.getCantB3() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Bebida 1.5L'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Nectar 1.5L"))
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
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + "+" + v.getCantB2() + "+" + v.getCantB3() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Nectar 1.5L'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Bebida Express"))
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
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + "+" + v.getCantB2() + "+" + v.getCantB3() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Bebida Express'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Nectar Express"))
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
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + "+" + v.getCantB2() + "+" + v.getCantB3() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Nectar Express'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Nectar Boca Ancha"))
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
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + "+" + v.getCantB2() + "+" + v.getCantB3() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Nectar Boca Ancha'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Cafe"))
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
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + "+" + v.getCantB2() + "+" + v.getCantB3() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Cafe'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Te"))
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
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + "+" + v.getCantB2() + "+" + v.getCantB3() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Te'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Milo"))
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
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + "+" + v.getCantB2() + "+" + v.getCantB3() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Milo'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Monster"))
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
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantB1() +"+"+ v.getCantB2() +"+"+ v.getCantB3() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Monster'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Bebida Lata"))
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
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + "+" + v.getCantB2() + "+" + v.getCantB3() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Bebida Lata'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            // descuento de vasos
            if (pedido.Contains("Vaso"))
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
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantVasos()+ ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Vaso Plastico'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
        }

        private void DctoCarneBD()
        {
            Ventas v = new Ventas();
            String fecha = DateTime.Now.ToString("d");
            String pedido = "" + v.getPedidoCliente();
            if (pedido.Contains("MT"))
            {
                if (pedido.Contains("1"))
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();

                    // para la segunda carne de la torre
                    //Datos de conexión a BD
                    NpgsqlConnection conn1 = new NpgsqlConnection("Server = localhost; Port = 5432; User Id = postgres; Password = censurado; Database = Rava_Sandwich");
                    //Abrir BD
                    conn1.Open();
                    //Crear objeto de comandos
                    NpgsqlCommand comm1 = new NpgsqlCommand();
                    //Crear objeto conexión
                    comm1.Connection = conn1;
                    //No se que hace xd
                    comm1.CommandType = CommandType.Text;
                    //Consulta
                    comm1.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne2() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Ave'";
                    //Leer BD
                    NpgsqlDataReader dr1 = comm1.ExecuteReader();
                    //Cerrar comandos
                    comm1.Dispose();
                    //Desconectar BD
                    conn1.Close();
                }
                if (pedido.Contains("2"))
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();

                    // para la segunda carne de la torre
                    //Datos de conexión a BD
                    NpgsqlConnection conn1 = new NpgsqlConnection("Server = localhost; Port = 5432; User Id = postgres; Password = censurado; Database = Rava_Sandwich");
                    //Abrir BD
                    conn1.Open();
                    //Crear objeto de comandos
                    NpgsqlCommand comm1 = new NpgsqlCommand();
                    //Crear objeto conexión
                    comm1.Connection = conn1;
                    //No se que hace xd
                    comm1.CommandType = CommandType.Text;
                    //Consulta
                    comm1.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne2() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'";
                    //Leer BD
                    NpgsqlDataReader dr1 = comm1.ExecuteReader();
                    //Cerrar comandos
                    comm1.Dispose();
                    //Desconectar BD
                    conn1.Close();
                }
                if (pedido.Contains("3"))
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();

                    // para la segunda carne de la torre
                    //Datos de conexión a BD
                    NpgsqlConnection conn1 = new NpgsqlConnection("Server = localhost; Port = 5432; User Id = postgres; Password = censurado; Database = Rava_Sandwich");
                    //Abrir BD
                    conn1.Open();
                    //Crear objeto de comandos
                    NpgsqlCommand comm1 = new NpgsqlCommand();
                    //Crear objeto conexión
                    comm1.Connection = conn1;
                    //No se que hace xd
                    comm1.CommandType = CommandType.Text;
                    //Consulta
                    comm1.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne2() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'";
                    //Leer BD
                    NpgsqlDataReader dr1 = comm1.ExecuteReader();
                    //Cerrar comandos
                    comm1.Dispose();
                    //Desconectar BD
                    conn1.Close();
                }
                if (pedido.Contains("5"))
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();

                    // para la segunda carne de la torre
                    //Datos de conexión a BD
                    NpgsqlConnection conn1 = new NpgsqlConnection("Server = localhost; Port = 5432; User Id = postgres; Password = censurado; Database = Rava_Sandwich");
                    //Abrir BD
                    conn1.Open();
                    //Crear objeto de comandos
                    NpgsqlCommand comm1 = new NpgsqlCommand();
                    //Crear objeto conexión
                    comm1.Connection = conn1;
                    //No se que hace xd
                    comm1.CommandType = CommandType.Text;
                    //Consulta
                    comm1.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne2() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'";
                    //Leer BD
                    NpgsqlDataReader dr1 = comm1.ExecuteReader();
                    //Cerrar comandos
                    comm1.Dispose();
                    //Desconectar BD
                    conn1.Close();
                }
                if (pedido.Contains("MV") || pedido.Contains("MG") || pedido.Contains("MN") || pedido.Contains("MC"))
                {
                    if (pedido.Contains("Lomo"))
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + v.getCantCarne2() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'";
                        //Leer BD
                        NpgsqlDataReader dr = comm.ExecuteReader();
                        //Cerrar comandos
                        comm.Dispose();
                        //Desconectar BD
                        conn.Close();
                    }
                    if (pedido.Contains("Ave"))
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + v.getCantCarne2() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Ave'";
                        //Leer BD
                        NpgsqlDataReader dr = comm.ExecuteReader();
                        //Cerrar comandos
                        comm.Dispose();
                        //Desconectar BD
                        conn.Close();
                    }
                    if (pedido.Contains("Churrasco"))
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + v.getCantCarne2() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'";
                        //Leer BD
                        NpgsqlDataReader dr = comm.ExecuteReader();
                        //Cerrar comandos
                        comm.Dispose();
                        //Desconectar BD
                        conn.Close();
                    }
                    if (pedido.Contains("Mechada"))
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + v.getCantCarne2() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'";
                        //Leer BD
                        NpgsqlDataReader dr = comm.ExecuteReader();
                        //Cerrar comandos
                        comm.Dispose();
                        //Desconectar BD
                        conn.Close();
                    }
                }
                else
                {
                    if (pedido.Contains("Lomo"))
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'";
                        //Leer BD
                        NpgsqlDataReader dr = comm.ExecuteReader();
                        //Cerrar comandos
                        comm.Dispose();
                        //Desconectar BD
                        conn.Close();
                    }
                    if (pedido.Contains("Ave"))
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Ave'";
                        //Leer BD
                        NpgsqlDataReader dr = comm.ExecuteReader();
                        //Cerrar comandos
                        comm.Dispose();
                        //Desconectar BD
                        conn.Close();
                    }
                    if (pedido.Contains("Churrasco"))
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'";
                        //Leer BD
                        NpgsqlDataReader dr = comm.ExecuteReader();
                        //Cerrar comandos
                        comm.Dispose();
                        //Desconectar BD
                        conn.Close();
                    }
                    if (pedido.Contains("Mechada"))
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'";
                        //Leer BD
                        NpgsqlDataReader dr = comm.ExecuteReader();
                        //Cerrar comandos
                        comm.Dispose();
                        //Desconectar BD
                        conn.Close();
                    }
                }
            }
            if (pedido.Contains("Promo Sandwich"))
            {
                if (pedido.Contains("Lomo"))
                {
                    //Datos de conexión a BD
                    NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; Port = 5432; User Id = postgres; Password = Password = censurado; Database = Rava_Sandwich");
                    //Abrir BD
                    conn.Open();
                    //Crear objeto de comandos
                    NpgsqlCommand comm = new NpgsqlCommand();
                    //Crear objeto conexión
                    comm.Connection = conn;
                    //No se que hace xd
                    comm.CommandType = CommandType.Text;
                    //Consulta
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                }
                if (pedido.Contains("Ave"))
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Ave'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                }
                if (pedido.Contains("Churrasco"))
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                }
                if (pedido.Contains("Mechada"))
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                }
            }
            if (pedido.Contains("Mini"))
            {
                if (pedido.Contains("Lomo"))
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + (" + v.getCantCarne1() + " * 0.5 ), stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                }
                if (pedido.Contains("Ave"))
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + (" + v.getCantCarne1() + " * 0.5 ), stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Ave'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                }
                if (pedido.Contains("Churrasco"))
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + (" + v.getCantCarne1() + " * 0.5 ), stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                }
                if (pedido.Contains("Mechada"))
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + (" + v.getCantCarne1() + " * 0.5 ), stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                }
            }
            if (pedido.Contains("Completo"))
            {
                if (pedido.Contains("Minic"))
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantVienesas() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Vienesa'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                }
                else
                {
                    if (pedido.Contains("As"))
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='As'";
                        //Leer BD
                        NpgsqlDataReader dr = comm.ExecuteReader();
                        //Cerrar comandos
                        comm.Dispose();
                        //Desconectar BD
                        conn.Close();
                    }
                    else
                    {
                        //aqui el dcto de las vienesas de una promo
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantVienesas() + ", stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Vienesa'";
                        //Leer BD
                        NpgsqlDataReader dr = comm.ExecuteReader();
                        //Cerrar comandos
                        comm.Dispose();
                        //Desconectar BD
                        conn.Close();
                    }
                }
            }
        }
    }
}
