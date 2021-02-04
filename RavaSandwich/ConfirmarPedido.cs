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

        // los sgtes datos son para almacenar las cantidades a descontar
        static int cantPromoS = 0;
        static int cantMini = 0;
        static float cantManso = 0;
        static int cantCompP = 0;
        static int cantCompM = 0;
        static int[] cantBebida1 = new int[10];
        static int[] cantBebida2 = new int[10];
        static int[] cantBebida3 = new int[10];
        static String[] nombBebidas1 = new string[10];
        static String[] nombBebidas2 = new string[10];
        static String[] nombBebidas3 = new string[10];
        static int cantVasos = 0;
        static double cantCarne1 = 0;
        static double cantCarne2 = 0;
        static int cantVienesas = 0;
        static int cantPro = 0;//La cantidad de promociones (del mismo)
        public ConfirmarPedido()
        {
            InitializeComponent();
            Login lo = new Login();
            Ventas ve = new Ventas();
            //
            String verP = ve.getPedidoCliente();
            contabilizarDescuentoInventario(verP);//Función nueva que contabiliza los productos a descontar en inventario, no borrar
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
            //Creo que hay que borrar lo que está comentado abajo
            //Envia la informacion de impresion a la funcion para contabilizar las cosas que se van a descontar del inventario
            /*String verP = ve.getPedidoCliente();
            contabilizarDescuentoInventario(verP);*/
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
                            //Mensaje de prueba, despues hay que borrar, si el error está acá no hay problema.
                            MessageBox.Show("Se descontaran lo siguientes elementos del inventario: \n cantPromos: "+cantPromoS+"\ncantMini: "+cantMini+"\ncantManso: "+cantManso+"\ncantCompP: "+cantCompP+"\ncantCompM: "+cantCompM+"\ncantBebida1: "+cantBebida1+"\ncantBebida2: "+cantBebida2+"\ncantBebida3: "+cantBebida3+"\ncantVasos: "+cantVasos+"\ncantCarne1: "+cantCarne1+"\ncantCarne2: "+cantCarne2+"\ncantVienesas: "+cantVienesas, "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            ve.Show();
                            this.Close();

                            //Crear impresion
                            printDocument1 = new PrintDocument();
                            PrinterSettings ps = new PrinterSettings();
                            printDocument1.PrinterSettings = ps;
                            printDocument1.PrintPage += Imprimir;
                            printDocument1.Print();
                            //descuentosEnInventario(ve.getPedidoCliente()); //COLOCAR LA NUEVA FUNCION DESCUENTOS
                            ve.vaciarLista();
                            //Restablece los contadores
                            cantPromoS = 0;
                            cantMini = 0;
                            cantManso = 0;
                            cantCompP = 0;
                            cantCompM = 0;
                            cantBebida1 = null;
                            cantBebida2 = null;
                            cantBebida3 = null;
                            nombBebidas1 = null;
                            nombBebidas2 = null;
                            nombBebidas3 = null;
                            cantVasos = 0;
                            cantCarne1 = 0;
                            cantCarne2 = 0;
                            cantVienesas = 0;
                            cantPro = 0;
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
                        //Mensaje de prueba, despues hay que borrar, si el error está acá no hay problema.
                        MessageBox.Show("Se descontaran lo siguientes elementos del inventario: \n cantPromos: " + cantPromoS + "\ncantMini: " + cantMini + "\ncantManso: " + cantManso + "\ncantCompP: " + cantCompP + "\ncantCompM: " + cantCompM + "\ncantBebida1: " + cantBebida1 + "\ncantBebida2: " + cantBebida2 + "\ncantBebida3: " + cantBebida3 + "\ncantVasos: " + cantVasos + "\ncantCarne1: " + cantCarne1 + "\ncantCarne2: " + cantCarne2 + "\ncantVienesas: " + cantVienesas, "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        ve.Show();
                        this.Close();

                        //Crear impresion
                        printDocument1 = new PrintDocument();
                        PrinterSettings ps = new PrinterSettings();
                        printDocument1.PrinterSettings = ps;
                        printDocument1.PrintPage += Imprimir;
                        printDocument1.Print();
                        //descuentosEnInventario(ve.getPedidoCliente()); //COLOCAR LA NUEVA FUNCION DE DESCUENTOS
                        ve.vaciarLista();
                        //Restablece los contadores
                        cantPromoS = 0;
                        cantMini = 0;
                        cantManso = 0;
                        cantCompP = 0;
                        cantCompM = 0;
                        cantBebida1 = null;
                        cantBebida2 = null;
                        cantBebida3 = null;
                        nombBebidas1 = null;
                        nombBebidas2 = null;
                        nombBebidas3 = null;
                        cantVasos = 0;
                        cantCarne1 = 0;
                        cantCarne2 = 0;
                        cantVienesas = 0;
                        cantPro = 0;
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
                    MessageBox.Show("Se ha registrado la venta de forma Exitosa", "Venta Hecha", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                    //Mensaje de prueba, despues hay que borrar, si el error está acá no hay problema.
                    MessageBox.Show("Se descontaran lo siguientes elementos del inventario: \n cantPromos: " + cantPromoS + "\ncantMini: " + cantMini + "\ncantManso: " + cantManso + "\ncantCompP: " + cantCompP + "\ncantCompM: " + cantCompM +"\nBebidas1: "+nombBebidas1[0]+", "+ nombBebidas1[1] + ", "+ nombBebidas1[2] + "\ncantBebida1: " + cantBebida1[0] + ", " + cantBebida1[1] + ", " + cantBebida1[2] + "\nBebidas2: " + nombBebidas2[0] + ", " + nombBebidas2[1] + ", " + nombBebidas2[2] + "\ncantBebida2: " + cantBebida2[0] + ", " + cantBebida2[1] + ", " + cantBebida2[2] + "\nBebidas3: " + nombBebidas3[0] + ", " + nombBebidas3[1] + ", " + nombBebidas3[2] + "\ncantBebida3: " + cantBebida3[0] + ", " + cantBebida3[1] + ", " + cantBebida3[2] + "\ncantVasos: " + cantVasos + "\ncantCarne1: " + cantCarne1 + "\ncantCarne2: " + cantCarne2 + "\ncantVienesas: " + cantVienesas, "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ve.Show();
                    this.Close();

                    //Crear impresion
                    printDocument1 = new PrintDocument();
                    PrinterSettings ps = new PrinterSettings();
                    printDocument1.PrinterSettings = ps;
                    printDocument1.PrintPage += Imprimir;
                    printDocument1.Print();
                    //descuentosEnInventario(ve.getPedidoCliente()); //COLOCAR LA NUEVA FUNCION DE DESCUENTOS ACÁ
                    ve.vaciarLista();
                    //Restablece los contadores
                    cantPromoS = 0;
                    cantMini = 0;
                    cantManso = 0;
                    cantCompP = 0;
                    cantCompM = 0;
                    cantBebida1 = null;
                    cantBebida2 = null;
                    cantBebida3 = null;
                    nombBebidas1 = null;
                    nombBebidas2 = null;
                    nombBebidas3 = null;
                    cantVasos = 0;
                    cantCarne1 = 0;
                    cantCarne2 = 0;
                    cantVienesas = 0;
                    cantPro = 0;
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
            //Restablece los contadores
            cantPromoS = 0;
            cantMini = 0;
            cantManso = 0;
            cantCompP = 0;
            cantCompM = 0;
            cantBebida1 = null;
            cantBebida2 = null;
            cantBebida3 = null;
            nombBebidas1 = null;
            nombBebidas2 = null;
            nombBebidas3 = null;
            cantVasos = 0;
            cantCarne1 = 0;
            cantCarne2 = 0;
            cantVienesas = 0;
            cantPro = 0;
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

        //A partir de acá hay que colocar el nuevo código de descuentos (Tommy) y fusionar con el contador
        /*
        public void descuentosEnInventario(String pedido)
        {
            Ventas v = new Ventas();
            String fecha = DateTime.Now.ToString("d");

            if (pedido.Contains("Promo Sandwich"))
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getPanSandwich() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Mini'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Mini'";
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
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getPanMini() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Mini'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Mini'";
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + (" + v.getPanManso() + " * 1.5 ), fecha = '" + fecha + "' WHERE nombre_prod ='Manso'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Manso'";
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getPanManso() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Manso'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Manso'";
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getPanCompleto() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Completo'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Completo'";
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getPanCompleto() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Completo'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Completo'";
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getPanPromoCompleto() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Completo'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Completo'";
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

            //*****************************************************************************************************************************************************************************************************************************+
            // Bebidas con getcant1()
            if (pedido.Contains("Bebida 0.5L") && v.getComboboxbeb1() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Bebida 0.5L'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Bebida 0.5L'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();

            }
            if (pedido.Contains("Bebida 1.5L") && v.getComboboxbeb1() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Bebida 1.5L'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Bebida 1.5L'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Nectar 1.5L") && v.getComboboxbeb1() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Nectar 1.5L'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Nectar 1.5L'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Bebida Express") && v.getComboboxbeb1() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Bebida Express'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Bebida Express'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Nectar Express") && v.getComboboxbeb1() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Nectar Express'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Nectar Express'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Nectar Boca Ancha") && v.getComboboxbeb1() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Nectar Boca Ancha'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Nectar Boca Ancha'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Cafe") && v.getComboboxbeb1() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Cafe'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Cafe'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Te") && v.getComboboxbeb1() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Te'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Te'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Milo") && v.getComboboxbeb1() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Milo'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Milo'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Monster") && v.getComboboxbeb1() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantB1() + ", fecha = '" + fecha + "' WHERE nombre_prod = 'Monster'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Monster'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Bebida Lata") && v.getComboboxbeb1() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Bebida Lata'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Bebida Lata'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            //***************************************************************************************************************************************************************************************************************************************************

            //*****************************************************************************************************************************************************************************************************************************
            // Bebidas con getcant2()
            if (pedido.Contains("Bebida 0.5L") && v.getComboboxbeb2() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB2() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Bebida 0.5L'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Bebida 0.5L'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();

            }
            if (pedido.Contains("Bebida 1.5L") && v.getComboboxbeb2() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB2() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Bebida 1.5L'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Bebida 1.5L'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Nectar 1.5L") && v.getComboboxbeb2() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB2() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Nectar 1.5L'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Nectar 1.5L'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Bebida Express") && v.getComboboxbeb2() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB2() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Bebida Express'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Bebida Express'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Nectar Express") && v.getComboboxbeb2() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB2() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Nectar Express'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Nectar Express'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Nectar Boca Ancha") && v.getComboboxbeb2() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB2() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Nectar Boca Ancha'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Nectar Boca Ancha'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Cafe") && v.getComboboxbeb2() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB2() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Cafe'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Cafe'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Te") && v.getComboboxbeb2() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB2() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Te'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Te'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Milo") && v.getComboboxbeb2() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB2() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Milo'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Milo'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Monster") && v.getComboboxbeb2() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantB2() + ", fecha = '" + fecha + "' WHERE nombre_prod = 'Monster'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Monster'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Bebida Lata") && v.getComboboxbeb2() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB2() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Bebida Lata'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Bebida Lata'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            //***************************************************************************************************************************************************************************************************************************************************

            //*****************************************************************************************************************************************************************************************************************************
            // Bebidas con getcant3()
            if (pedido.Contains("Bebida 0.5L") && v.getComboboxbeb3() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB3() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Bebida 0.5L'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Bebida 0.5L'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();

            }
            if (pedido.Contains("Bebida 1.5L") && v.getComboboxbeb3() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB3() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Bebida 1.5L'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Bebida 1.5L'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Nectar 1.5L") && v.getComboboxbeb3() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB3() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Nectar 1.5L'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Nectar 1.5L'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Bebida Express") && v.getComboboxbeb3() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB3() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Bebida Express'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Bebida Express'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Nectar Express") && v.getComboboxbeb3() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB3() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Nectar Express'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Nectar Express'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Nectar Boca Ancha") && v.getComboboxbeb3() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB3() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Nectar Boca Ancha'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Nectar Boca Ancha'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Cafe") && v.getComboboxbeb3() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB3() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Cafe'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Cafe'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Te") && v.getComboboxbeb3() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB3() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Te'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Te'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Milo") && v.getComboboxbeb3() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB3() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Milo'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Milo'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Monster") && v.getComboboxbeb3() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantB3() + ", fecha = '" + fecha + "' WHERE nombre_prod = 'Monster'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Monster'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            if (pedido.Contains("Bebida Lata") && v.getComboboxbeb3() != null)
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantB3() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Bebida Lata'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Bebida Lata'";
                //Leer BD
                NpgsqlDataReader dr = comm.ExecuteReader();
                //Cerrar comandos
                comm.Dispose();
                //Desconectar BD
                conn.Close();
            }
            //***************************************************************************************************************************************************************************************************************************************************


            // descuento de vasos
            if (pedido.Contains("Vaso"))
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
                //Consulta
                comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod +  " + v.getCantVasos() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Vaso'; " +
                    "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Vaso'";
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();

                    // para la segunda carne de la torre
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
                    comm1.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne2() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Ave'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Ave'";
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();

                    // para la segunda carne de la torre
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
                    comm1.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne2() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'";
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();

                    // para la segunda carne de la torre
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
                    comm1.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne2() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'";
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();

                    // para la segunda carne de la torre
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
                    comm1.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'";
                    //Leer BD
                    NpgsqlDataReader dr1 = comm1.ExecuteReader();
                    //Cerrar comandos
                    comm1.Dispose();
                    //Desconectar BD
                    conn1.Close();
                }
                if (pedido.Contains("MV"))
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
                    //Consulta
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();

                    // para la segunda carne de la torre
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
                    comm1.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne2() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'";
                    //Leer BD
                    NpgsqlDataReader dr1 = comm1.ExecuteReader();
                    //Cerrar comandos
                    comm1.Dispose();
                    //Desconectar BD
                    conn1.Close();
                }
                if (pedido.Contains("MG"))
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
                    //Consulta
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Ave'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Ave'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();

                    // para la segunda carne de la torre
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
                    comm1.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne2() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Ave'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Ave'";
                    //Leer BD
                    NpgsqlDataReader dr1 = comm1.ExecuteReader();
                    //Cerrar comandos
                    comm1.Dispose();
                    //Desconectar BD
                    conn1.Close();
                }
                if (pedido.Contains("MN"))
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
                    //Consulta
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();

                    // para la segunda carne de la torre
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
                    comm1.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne2() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'";
                    //Leer BD
                    NpgsqlDataReader dr1 = comm1.ExecuteReader();
                    //Cerrar comandos
                    comm1.Dispose();
                    //Desconectar BD
                    conn1.Close();
                }
                if (pedido.Contains("MC"))
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
                    //Consulta
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'";
                    //Leer BD
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();

                    // para la segunda carne de la torre
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
                    comm1.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne2() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'";
                    //Leer BD
                    NpgsqlDataReader dr1 = comm1.ExecuteReader();
                    //Cerrar comandos
                    comm1.Dispose();
                    //Desconectar BD
                    conn1.Close();
                }
                else
                {
                    if (pedido.Contains("Lomo"))
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
                        //Consulta
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'";
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Ave'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Ave'";
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'";
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'; " +
                            "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'";
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'; " +
                        "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'";
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Ave'; " +
                        "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Ave'";
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'; " +
                        "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'";
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'; " +
                        "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'";
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + (" + v.getCantCarne1() + " * 0.5), fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'; " +
                        "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Lomo'";
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + (" + v.getCantCarne1() + " * 0.5), fecha = '" + fecha + "' WHERE nombre_prod ='Ave'; " +
                        "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Ave'";
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + (" + v.getCantCarne1() + " * 0.5), fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'; " +
                        "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Churrasco'";
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + (" + v.getCantCarne1() + " * 0.5), fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'; " +
                        "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Mechada'";
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
                    comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantVienesas() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Vienesa'; " +
                        "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Vienesa'";
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
                        /*
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantCarne1() + ", fecha = '" + fecha + "' WHERE nombre_prod ='As'; " +
                        "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='As'";
                        //Leer BD
                        NpgsqlDataReader dr = comm.ExecuteReader();
                        //Cerrar comandos
                        comm.Dispose();
                        //Desconectar BD
                        conn.Close();
                        
                        descontarProducto("As");
                    }
                    else
                    {
                        //aqui el dcto de las vienesas de una promo
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
                        comm.CommandText = "UPDATE productos SET consumo_prod = consumo_prod + " + v.getCantVienesas() + ", fecha = '" + fecha + "' WHERE nombre_prod ='Vienesa'; " +
                        "UPDATE productos SET stock_final_prod = (stock_inicio_prod + ingreso_produc) - consumo_prod, fecha = '" + fecha + "' WHERE nombre_prod ='Vienesa'";
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
       */
        private void contabilizarDescuentoInventario(String pedidoA)
        {

            //Divide la cantidad de pedidos (Pedidos diferentes)
            String[] divPedido = pedidoA.Split("Pedido");
            int contP = 0;
            
            for (int i = 1; i < divPedido.Length; i++)
            {
                //Division del pedido para obtener la cantidad de promos (misma promo)
                String[] cantPromo = divPedido[i].Split("Cantidad promos:");
                String[] cantPromoPrecis = cantPromo[1].Split(": ");
                String[] cPromoPrec = cantPromoPrecis[0].Split(" ");
                cantPro = int.Parse(cPromoPrec[1]);

                String[] divPromo = divPedido[i].Split("Promo:");
                for (int j = 1; j < divPromo.Length; j++)
                {
                    //Division de los ingredientes del pedido
                    String[] divIng = divPromo[j].Split("Ingredientes: ");
                    String[] extIng = divIng[1].Split(", "); //con el extIng[0] podemos extraer el primer ingrediente que 
                    //siempre es la carne 1 y para la segunda carne se tendrá que recorrer el resto del arreglo
                    if (divPromo[j].Contains("Mini"))
                    {
                        cantMini = cantMini + cantPro;
                        if (divPromo[j].Contains("Min48"))
                        {
                         
                        }
                        else
                        {
                            if (extIng[0].Contains("Lomo"))
                            {
                                cantCarne1 = cantCarne1 + 1;

                            }
                            if (extIng[0].Contains("Ave"))
                            {
                                cantCarne1 = cantCarne1 + 1;

                            }
                            if (extIng[0].Contains("Churrasco"))
                            {
                                cantCarne1 = cantCarne1 + 1;

                            }
                            if (extIng[0].Contains("Mechada"))
                            {
                                cantCarne1 = cantCarne1 + 1;
                            }
                        }
                    }
                    if (divPromo[j].Contains("Mansos"))
                    {
                        if (divPromo[j].Contains("MT"))
                        {
                            cantManso = cantManso + (float)(cantPro);
                            if (extIng[0].Contains("Lomo"))
                            {
                                cantCarne1 = cantCarne1 + 1;
                                //Hace el recorrido del resto de los ingredientes para averiguar si hay una segunda carne
                                for(int k = 1; k < extIng.Length; k++) {
                                    if (extIng[k].Contains("Ave"))
                                    {
                                        cantCarne2 = cantCarne2 + 1;
                                    }
                                    else
                                    {
                                        if (extIng[k].Contains("Churrasco"))
                                        {
                                            cantCarne2 = cantCarne2 + 1;
                                        }
                                        else
                                        {
                                            if (extIng[k].Contains("Mechada"))
                                            {
                                                cantCarne2 = cantCarne2 + 1;
                                            }
                                        }
                                    }
                                }



                            }
                            if (extIng[0].Contains("Ave"))
                            {
                                cantCarne1 = cantCarne1 + 1;
                                //A partir de que encuentre lomo, busca la segunda carne para contabilizar
                                for (int k = 1; k < extIng.Length; k++)
                                {
                                    if (extIng[k].Contains("Lomo"))
                                    {
                                        cantCarne2 = cantCarne2 + 1;
                                    }
                                    else
                                    {
                                        if (extIng[k].Contains("Churrasco"))
                                        {
                                            cantCarne2 = cantCarne2 + 1;
                                        }
                                        else
                                        {
                                            if (extIng[k].Contains("Mechada"))
                                            {
                                                cantCarne2 = cantCarne2 + 1;
                                            }
                                        }
                                    }
                                }
                            }
                            if (extIng[0].Contains("Churrasco"))
                            {
                                cantCarne1 = cantCarne1 + 1;
                                //A partir de que encuentre lomo, busca la segunda carne para contabilizar
                                for (int k = 1; k < extIng.Length; k++)
                                {
                                    if (extIng[k].Contains("Ave"))
                                    {
                                        cantCarne2 = cantCarne2 + 1;
                                    }
                                    else
                                    {
                                        if (extIng[k].Contains("Lomo"))
                                        {
                                            cantCarne2 = cantCarne2 + 1;
                                        }
                                        else
                                        {
                                            if (extIng[k].Contains("Mechada"))
                                            {
                                                cantCarne2 = cantCarne2 + 1;
                                            }
                                        }
                                    }
                                }
                            }
                            if (extIng[0].Contains("Mechada"))
                            {
                                cantCarne1 = cantCarne1 + 1;
                                //A partir de que encuentre lomo, busca la segunda carne para contabilizar
                                for (int k = 1; k < extIng.Length; k++)
                                {
                                    if (extIng[k].Contains("Ave"))
                                    {
                                        cantCarne2 = cantCarne2 + 1;
                                    }
                                    else
                                    {
                                        if (extIng[k].Contains("Churrasco"))
                                        {
                                            cantCarne2 = cantCarne2 + 1;
                                        }
                                        else
                                        {
                                            if (extIng[k].Contains("Lomo"))
                                            {
                                                cantCarne2 = cantCarne2 + 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            cantManso = cantManso + (int)cantPro;
                            // aqui las carnes de los mansos
                            if (divPromo[j].Contains("M48") || divPromo[j].Contains("MH"))
                            {
                                cantCarne1 = cantCarne1 + 0;
                            }
                            else
                            {
                                if (extIng[0].Contains("Lomo"))
                                {
                                    cantCarne1 = cantCarne1 + 1;
                                    //A partir de que encuentre lomo, busca la segunda carne para contabilizar
                                    for (int k = 1; k < extIng.Length; k++)
                                    {
                                        if (extIng[k].Contains("Ave"))
                                        {
                                            cantCarne2 = cantCarne2 + 1;
                                        }
                                        else
                                        {
                                            if (extIng[k].Contains("Churrasco"))
                                            {
                                                cantCarne2 = cantCarne2 + 1;
                                            }
                                            else
                                            {
                                                if (extIng[k].Contains("Mechada"))
                                                {
                                                    cantCarne2 = cantCarne2 + 1;
                                                }
                                            }
                                        }
                                    }


                                }
                                if (extIng[0].Contains("Ave"))
                                {
                                    cantCarne1 = cantCarne1 + 1;
                                    //A partir de que encuentre lomo, busca la segunda carne para contabilizar
                                    for (int k = 1; k < extIng.Length; k++)
                                    {
                                        if (extIng[k].Contains("Lomo"))
                                        {
                                            cantCarne2 = cantCarne2 + 1;
                                        }
                                        else
                                        {
                                            if (extIng[k].Contains("Churrasco"))
                                            {
                                                cantCarne2 = cantCarne2 + 1;
                                            }
                                            else
                                            {
                                                if (extIng[k].Contains("Mechada"))
                                                {
                                                    cantCarne2 = cantCarne2 + 1;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (extIng[0].Contains("Churrasco"))
                                {
                                    cantCarne1 = cantCarne1 + 1;
                                    //A partir de que encuentre lomo, busca la segunda carne para contabilizar
                                    for (int k = 1; k < extIng.Length; k++)
                                    {
                                        if (extIng[k].Contains("Ave"))
                                        {
                                            cantCarne2 = cantCarne2 + 1;
                                        }
                                        else
                                        {
                                            if (extIng[k].Contains("Lomo"))
                                            {
                                                cantCarne2 = cantCarne2 + 1;
                                            }
                                            else
                                            {
                                                if (extIng[k].Contains("Mechada"))
                                                {
                                                    cantCarne2 = cantCarne2 + 1;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (extIng[0].Contains("Mechada"))
                                {
                                    cantCarne1 = cantCarne1 + 1;
                                    //A partir de que encuentre lomo, busca la segunda carne para contabilizar
                                    for (int k = 1; k < extIng.Length; k++)
                                    {
                                        if (extIng[k].Contains("Ave"))
                                        {
                                            cantCarne2 = cantCarne2 + 1;
                                        }
                                        else
                                        {
                                            if (extIng[k].Contains("Churrasco"))
                                            {
                                                cantCarne2 = cantCarne2 + 1;
                                            }
                                            else
                                            {
                                                if (extIng[k].Contains("Lomo"))
                                                {
                                                    cantCarne2 = cantCarne2 + 1;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (divPromo[j].Contains("Promo Sandwich"))
                    {
                        cantPromoS = cantPromoS + ((cantPro) * 2);
                        // aqui las carnes de las promos
                        if (divPromo[j].Contains("P48"))
                        {
                            cantCarne1 = cantCarne1 + 0;
                        }
                        else
                        {
                            String[] ing = divPromo[j].Split("Ingredientes: ");//Separa el apartado de los ingredientes
                            String[] ca1 = ing[1].Split(", ");//Separa los ingredientes  y el ca1[0] siempre muestra la primera carne

                            if (ca1[0].Contains("Lomo"))
                            {
                                cantCarne1 = cantCarne1 + 1;
                            }
                            if (ca1[0].Contains("Ave"))
                            {
                                cantCarne1 = cantCarne1 + 1;
                            }
                            if (ca1[0].Contains("Churrasco"))
                            {
                                cantCarne1 = cantCarne1 + 1;
                            }
                            if (ca1[0].Contains("Mechada"))
                            {
                                cantCarne1 = cantCarne1 + 1;
                            }
                        }
                    }
                    //Acá hay que arreglar porque me confundí por el tema de conteo, sé que acá cambia algo con las carnes
                    if (divPromo[j].Contains("Completo"))
                    {
                        if (divPromo[j].Contains("Minic"))
                        {
                            if (divPromo[j].Contains("Vienesa")) //WTF aiudaa
                            {
                                cantVienesas = cantVienesas + 1;
                                cantCompM = cantCompM + (int)(cantPro);
                            }
                        }
                        if (divPromo[j].Contains("Vienesa"))// WTF? esto triplica las vienesas
                        {
                            cantVienesas = cantVienesas + 2;
                            cantCompP = cantCompP + ((int)(cantPro) * 2);
                        }
                        if (divPromo[j].Contains("As"))//I can't understand
                        {
                            cantCarne1 = cantCarne1 + 1;
                            cantCompM = cantCompM + (int)(cantPro);
                        }
                    }
                    String[] divB = divPromo[j].Split("Bebidas:");//Separa el pedido en el apartado de las bebidas
                    String[] masB = divB[1].Split("\n");//Con esto podemos verificar si hay mas bebidas
                    String[] beb1 = masB[0].Split(" "); //Aca tenemos la cantidad de bebida mas la primera bebida
                    String[] beb2 = masB[1].Split(" ");//Bebida 2
                    String[] beb3 = masB[2].Split(" ");//Bebida 3
                    
                    if (beb1[1].Contains("1") || beb1[1].Contains("2") || beb1[1].Contains("3") || beb1[1].Contains("4") || beb1[1].Contains("5") || beb1[1].Contains("6") || beb1[1].Contains("7") || beb1[1].Contains("8") || beb1[1].Contains("9") || beb1[1].Contains("0"))
                    {
                        cantBebida1[contP] = int.Parse(beb1[1]);
                        nombBebidas1[contP] = beb1[2] + " " + beb1[3];

                    }
                    {

                    }
                    if ((beb2[0].Contains("1") || beb2[0].Contains("2") || beb2[0].Contains("3") || beb2[0].Contains("4") || beb2[0].Contains("5") || beb2[0].Contains("6") || beb2[0].Contains("7") || beb2[0].Contains("8") || beb2[0].Contains("9") || beb2[0].Contains("0")) && (!beb2[0].Contains("Vasos:")))
                    {
                        cantBebida2[contP] = int.Parse(beb2[0]);
                        nombBebidas2[contP] = beb2[1] + " " + beb2[2];
                    }
                    if ((beb3[0].Contains("1") || beb3[0].Contains("2") || beb3[0].Contains("3") || beb3[0].Contains("4") || beb3[0].Contains("5") || beb3[0].Contains("6") || beb3[0].Contains("7") || beb3[0].Contains("8") || beb3[0].Contains("9") || beb3[0].Contains("0")) && (!beb3[0].Contains("Vasos:")))
                    {
                        cantBebida3[contP] = int.Parse(beb3[0]);
                        nombBebidas3[contP] = beb3[1] + " " + beb3[2];
                    }
                    contP++;
                    String[] divV = divPromo[j].Split("Vasos: ");//Separa el pedido en el apartado de los vasos
                    String[] numV = divV[1].Split('\n');
                    if ((numV[0].Contains("1") || numV[0].Contains("2") || numV[0].Contains("3") || numV[0].Contains("4") || numV[0].Contains("5") || numV[0].Contains("6") || numV[0].Contains("7") || numV[0].Contains("8") || numV[0].Contains("9") || numV[0].Contains("0")))
                    {
                        cantVasos = cantVasos + int.Parse(numV[0]);
                    }
                }
            }
        }
        //Estas son las funciones que estaban en ventas y que se usan acá, ahora se pueden llamar
        //de forma local :) (sin el v.llamarFuncion())
        //lo mismo que estaba en ventas
        public int getPanMini()
        {
            return cantMini;
        }
        public float getPanManso()
        {
            return cantManso;
        }
        public int getPanSandwich()
        {
            return cantPromoS;
        }
        public int getPanCompleto()
        {
            return cantCompM;
        }
        public int getPanPromoCompleto()
        {
            return cantCompP;
        }
        //Acá hay que jugar con el numero de pedido que es recibido como parametro 
        //ya que se está manipulando un arreglo
        public int getCantB1(int pos)
        {
            return cantBebida1[pos];
        }
        public int getCantB2(int pos)
        {
            return cantBebida2[pos];
        }
        public int getCantB3(int pos)
        {
            return cantBebida3[pos];
        }
        //Aca antes usabas un combobox para obtener el nombre de las bebidas
        //ahora están almacenados en un arreglo de String, misma recomendacion de arriba
        public String getNombreB1(int pos)
        {
            return nombBebidas1[pos];
        }
        public String getNombreB2(int pos)
        {
            return nombBebidas2[pos];
        }
        public String getNombreB3(int pos)
        {
            return nombBebidas3[pos];
        }
        //lo mismo que estaba en ventas
        public int getCantVasos()
        {
            return cantVasos;
        }
        public double getCantCarne1()
        {
            return cantCarne1;
        }
        public double getCantCarne2()
        {
            return cantCarne2;
        }
        public int getCantVienesas()
        {
            return cantVienesas;
        }
    }


}
