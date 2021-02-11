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
        static int contP = 0;
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
            contabilizarDescuentoInventario(ve.getPedidoCliente());
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
                            MessageBox.Show("Se descontaran lo siguientes elementos del inventario: \n cantPromos: " + cantPromoS + "\ncantMini: " + cantMini + "\ncantManso: " + cantManso + "\ncantCompP: " + cantCompP + "\ncantCompM: " + cantCompM + "\nBebidas1: " + nombBebidas1[0] + ", " + nombBebidas1[1] + ", " + nombBebidas1[2] + "\ncantBebida1: " + cantBebida1[0] + ", " + cantBebida1[1] + ", " + cantBebida1[2] + "\nBebidas2: " + nombBebidas2[0] + ", " + nombBebidas2[1] + ", " + nombBebidas2[2] + "\ncantBebida2: " + cantBebida2[0] + ", " + cantBebida2[1] + ", " + cantBebida2[2] + "\nBebidas3: " + nombBebidas3[0] + ", " + nombBebidas3[1] + ", " + nombBebidas3[2] + "\ncantBebida3: " + cantBebida3[0] + ", " + cantBebida3[1] + ", " + cantBebida3[2] + "\ncantVasos: " + cantVasos + "\ncantCarne1: " + cantCarne1 + "\ncantCarne2: " + cantCarne2 + "\ncantVienesas: " + cantVienesas, "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            ve.Show();
                            this.Close();

                            //Crear impresion
                            printDocument1 = new PrintDocument();
                            PrinterSettings ps = new PrinterSettings();
                            printDocument1.PrinterSettings = ps;
                            printDocument1.PrintPage += Imprimir;
                            printDocument1.Print();
                            descuentosEnInventario(ve.getPedidoCliente());
                            DctoCarneBD();
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
                        MessageBox.Show("Se descontaran lo siguientes elementos del inventario: \n cantPromos: " + cantPromoS + "\ncantMini: " + cantMini + "\ncantManso: " + cantManso + "\ncantCompP: " + cantCompP + "\ncantCompM: " + cantCompM + "\nBebidas1: " + nombBebidas1[0] + ", " + nombBebidas1[1] + ", " + nombBebidas1[2] + "\ncantBebida1: " + cantBebida1[0] + ", " + cantBebida1[1] + ", " + cantBebida1[2] + "\nBebidas2: " + nombBebidas2[0] + ", " + nombBebidas2[1] + ", " + nombBebidas2[2] + "\ncantBebida2: " + cantBebida2[0] + ", " + cantBebida2[1] + ", " + cantBebida2[2] + "\nBebidas3: " + nombBebidas3[0] + ", " + nombBebidas3[1] + ", " + nombBebidas3[2] + "\ncantBebida3: " + cantBebida3[0] + ", " + cantBebida3[1] + ", " + cantBebida3[2] + "\ncantVasos: " + cantVasos + "\ncantCarne1: " + cantCarne1 + "\ncantCarne2: " + cantCarne2 + "\ncantVienesas: " + cantVienesas, "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        ve.Show();
                        this.Close();

                        //Crear impresion
                        printDocument1 = new PrintDocument();
                        PrinterSettings ps = new PrinterSettings();
                        printDocument1.PrinterSettings = ps;
                        printDocument1.PrintPage += Imprimir;
                        printDocument1.Print();
                        descuentosEnInventario(ve.getPedidoCliente());
                        DctoCarneBD();
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
                    MessageBox.Show("Se ha registrado la venta de manera Exitosa", "Venta Hecha", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    //Cerrar comandos
                    comm.Dispose();
                    //Desconectar BD
                    conn.Close();
                    //Mensaje de prueba, despues hay que borrar, si el error está acá no hay problema.
                   // MessageBox.Show("Se descontaran lo siguientes elementos del inventario: \n cantPromos: " + cantPromoS + "\ncantMini: " + cantMini + "\ncantManso: " + cantManso + "\ncantCompP: " + cantCompP + "\ncantCompM: " + cantCompM + "\nBebidas1: " + nombBebidas1[0] + ", " + nombBebidas1[1] + ", " + nombBebidas1[2] + "\ncantBebida1: " + cantBebida1[0] + ", " + cantBebida1[1] + ", " + cantBebida1[2] + "\nBebidas2: " + nombBebidas2[0] + ", " + nombBebidas2[1] + ", " + nombBebidas2[2] + "\ncantBebida2: " + cantBebida2[0] + ", " + cantBebida2[1] + ", " + cantBebida2[2] + "\nBebidas3: " + nombBebidas3[0] + ", " + nombBebidas3[1] + ", " + nombBebidas3[2] + "\ncantBebida3: " + cantBebida3[0] + ", " + cantBebida3[1] + ", " + cantBebida3[2] + "\ncantVasos: " + cantVasos + "\ncantCarne1: " + cantCarne1 + "\ncantCarne2: " + cantCarne2 + "\ncantVienesas: " + cantVienesas, "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); 
                    ve.Show();
                    this.Close();

                    //Crear impresion
                    printDocument1 = new PrintDocument();
                    PrinterSettings ps = new PrinterSettings();
                    printDocument1.PrinterSettings = ps;
                    printDocument1.PrintPage += Imprimir;
                    printDocument1.Print();
                    descuentosEnInventario(ve.getPedidoCliente());
                    DctoCarneBD();
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
            ve.Show();
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

        private void contabilizarDescuentoInventario(String pedidoA)
        {

            //Divide la cantidad de pedidos (Pedidos diferentes)
            String[] divPedido = pedidoA.Split("Pedido");
            

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
                    if (divPromo[j].Contains("Mini") && !divPromo[j].Contains("Minic"))
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
                        else
                        {
                            cantManso = cantManso + (int)cantPro;
                            // aqui las carnes de los mansos
                            if (divPromo[j].Contains("M48") || divPromo[j].Contains("MH"))
                            {
                                
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
                        cantPromoS = cantPromoS + cantPro;
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
                    if (divPromo[j].Contains("Comp"))
                    {
                        if (divPromo[j].Contains("Minic"))
                        {
                            if (divPromo[j].Contains("Vienesa"))
                            {
                                cantVienesas = cantVienesas + 1;
                                cantCompM = cantCompM + (int)(cantPro);
                            }
                        }
                        else if (!divPromo[j].Contains("Minic"))
                        {
                            if (divPromo[j].Contains("Vienesa"))
                            {
                                cantVienesas = cantVienesas + 1;
                                cantCompP = cantCompP + (int)(cantPro);
                            }
                        }
                    }
                    if (divPromo[j].Contains("As Italiano"))
                    {
                        cantCarne1 = cantCarne1 + 1;
                        cantCompM = cantCompM + (int)(cantPro);
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

        public void descuentosEnInventario(String pedido)
        {
            Ventas v = new Ventas();
            String fecha = DateTime.Now.ToString("d");


            if (pedido.Contains("Promo Sandwich"))
            {

                descontarProducto("Promo Sandwich", getPanSandwich());
            }

            if (pedido.Contains("Mini"))
            {
                descontarProducto("Mini", getPanMini());
            }

            if (pedido.Contains("Mansos"))
            {
                if (pedido.Contains("MT"))
                {
                    descontarProducto("MT", getPanManso());
                }
                else
                {
                    descontarProducto("Mansos", getPanManso());
                }
            }

            if (pedido.Contains("Comp"))
            {
                if (pedido.Contains("Minic"))
                {
                    descontarProducto("Minic", getPanCompleto());
                }
                else
                {
                    descontarProducto("Promo Completo", getPanPromoCompleto());
                }
            }

            if (pedido.Contains("As"))
            {
                descontarProducto("As", getPanCompleto());
            }

            //*****************************************************************************************************************************************************************************************************************************+
            // Bebidas con getcant1()
            for (int i = 0; i < contP; i++)
            {
                if (pedido.Contains("Bebida 0.5L") && getNombreB1(i) != null)
                {
                    descontarProducto("Bebida 0.5L", getCantB1(i));
                }
                if (pedido.Contains("Bebida 1.5L") && getNombreB1(i) != null)
                {
                    descontarProducto("Bebida 1.5L", getCantB1(i));
                }
                if (pedido.Contains("Nectar 1.5L") && getNombreB1(i) != null)
                {
                    descontarProducto("Nectar 1.5L", getCantB1(i));
                }
                if (pedido.Contains("Bebida Express") && getNombreB1(i) != null)
                {
                    descontarProducto("Bebida Express", getCantB1(i));
                }
                if (pedido.Contains("Nectar Express") && getNombreB1(i) != null)
                {
                    descontarProducto("Nectar Express", getCantB1(i));
                }
                if (pedido.Contains("Nectar Boca Ancha") && getNombreB1(i) != null)
                {
                    descontarProducto("Nectar Boca Ancha", getCantB1(i));
                }
                if (pedido.Contains("Cafe") && getNombreB1(i) != null)
                {
                    descontarProducto("Cafe", getCantB1(i));
                }
                if (pedido.Contains("Te") && getNombreB1(i) != null)
                {
                    descontarProducto("Te", getCantB1(i));
                }
                if (pedido.Contains("Milo") && getNombreB1(i) != null)
                {
                    descontarProducto("Milo", getCantB1(i));
                }
                if (pedido.Contains("Monster") && getNombreB1(i) != null)
                {
                    descontarProducto("Monster", getCantB1(i));
                }
                if (pedido.Contains("Bebida Lata") && getNombreB1(i) != null)
                {
                    descontarProducto("Bebida Lata", getCantB1(i));
                }
            }

            //***************************************************************************************************************************************************************************************************************************************************

            //*****************************************************************************************************************************************************************************************************************************
            // Bebidas con getcant2()
            for (int i = 0; i < contP; i++)
            {
                if (pedido.Contains("Bebida 0.5L") && getNombreB2(i) != null)
                {
                    descontarProducto("Bebida 0.5L", getCantB2(i));
                }
                if (pedido.Contains("Bebida 1.5L") && getNombreB2(i) != null)
                {
                    descontarProducto("Bebida 1.5L", getCantB2(i));
                }
                if (pedido.Contains("Nectar 1.5L") && getNombreB2(i) != null)
                {
                    descontarProducto("Nectar 1.5L", getCantB2(i));
                }
                if (pedido.Contains("Bebida Express") && getNombreB2(i) != null)
                {
                    descontarProducto("Bebida Express", getCantB2(i));
                }
                if (pedido.Contains("Nectar Express") && getNombreB2(i) != null)
                {
                    descontarProducto("Nectar Express", getCantB2(i));
                }
                if (pedido.Contains("Nectar Boca Ancha") && getNombreB2(i) != null)
                {
                    descontarProducto("Nectar Boca Ancha", getCantB2(i));
                }
                if (pedido.Contains("Cafe") && getNombreB2(i) != null)
                {
                    descontarProducto("Cafe", getCantB2(i));
                }
                if (pedido.Contains("Te") && getNombreB2(i) != null)
                {
                    descontarProducto("Te", getCantB2(i));
                }
                if (pedido.Contains("Milo") && getNombreB2(i) != null)
                {
                    descontarProducto("Milo", getCantB2(i));
                }
                if (pedido.Contains("Monster") && getNombreB2(i) != null)
                {
                    descontarProducto("Monster", getCantB2(i));
                }
                if (pedido.Contains("Bebida Lata") && getNombreB2(i) != null)
                {
                    descontarProducto("Bebida Lata", getCantB2(i));
                }
            }

            //***************************************************************************************************************************************************************************************************************************************************

            //*****************************************************************************************************************************************************************************************************************************
            // Bebidas con getcant3()
            for (int i = 0; i < contP; i++)
            {
                if (pedido.Contains("Bebida 0.5L") && getNombreB3(i) != null)
                {
                    descontarProducto("Bebida 0.5L", getCantB3(i));
                }
                if (pedido.Contains("Bebida 1.5L") && getNombreB3(i) != null)
                {
                    descontarProducto("Bebida 1.5L", getCantB3(i));
                }
                if (pedido.Contains("Nectar 1.5L") && getNombreB3(i) != null)
                {
                    descontarProducto("Nectar 1.5L", getCantB3(i));
                }
                if (pedido.Contains("Bebida Express") && getNombreB3(i) != null)
                {
                    descontarProducto("Bebida Express", getCantB3(i));
                }
                if (pedido.Contains("Nectar Express") && getNombreB3(i) != null)
                {
                    descontarProducto("Nectar Express", getCantB3(i));
                }
                if (pedido.Contains("Nectar Boca Ancha") && getNombreB3(i) != null)
                {
                    descontarProducto("Nectar Boca Ancha", getCantB3(i));
                }
                if (pedido.Contains("Cafe") && getNombreB3(i) != null)
                {
                    descontarProducto("Cafe", getCantB3(i));
                }
                if (pedido.Contains("Te") && getNombreB3(i) != null)
                {
                    descontarProducto("Te", getCantB3(i));
                }
                if (pedido.Contains("Milo") && getNombreB3(i) != null)
                {
                    descontarProducto("Milo", getCantB3(i));
                }
                if (pedido.Contains("Monster") && getNombreB3(i) != null)
                {
                    descontarProducto("Monster", getCantB3(i));
                }
                if (pedido.Contains("Bebida Lata") && getNombreB3(i) != null)
                {
                    descontarProducto("Bebida Lata", getCantB3(i));
                }
            }
            //***************************************************************************************************************************************************************************************************************************************************
            // descuento de vasos
            if (pedido.Contains("Vaso"))
            {
                descontarProducto("Vasos", getCantVasos());
            }
        }

        private void DctoCarneBD()
        {
            Ventas v = new Ventas();

            String pedido = "" + v.getPedidoCliente();

            if (pedido.Contains("Mansos"))
            {
                if (pedido.Contains("MT")) // Descuentos de carne es las torres
                {
                    if (pedido.Contains("1"))
                    {
                        descontarProducto("Churrasco", getCantCarne1());
                        descontarProducto("Ave", getCantCarne2());
                    }
                    if (pedido.Contains("2"))
                    {
                        descontarProducto("Mechada", getCantCarne1());
                        descontarProducto("Lomo", getCantCarne2());
                    }
                    if (pedido.Contains("3"))
                    {
                        descontarProducto("Churrasco", getCantCarne1());
                        descontarProducto("Lomo", getCantCarne2());
                    }
                    if (pedido.Contains("5"))
                    {
                        descontarProducto("Churrasco", getCantCarne1());
                        descontarProducto("Mechada", getCantCarne2());
                    }
                }
                else
                {
                    if (pedido.Contains("MV")) // descuentos en las carnes de mansos dobles
                    {
                        if (pedido.Contains("1"))
                        {
                            descontarProducto("DobleLomo", getCantCarne1());
                        }
                        if (pedido.Contains("2"))
                        {
                            descontarProducto("DobleChurrasco", getCantCarne1());
                        }
                    }
                    if (pedido.Contains("MG"))
                    {
                        descontarProducto("DobleAve", getCantCarne1());
                    }
                    if (pedido.Contains("MN"))
                    {
                        descontarProducto("DobleMechada", getCantCarne1());
                    }
                    if (pedido.Contains("MC"))
                    {
                        descontarProducto("DobleChurrasco", getCantCarne1());
                    }

                    if (!pedido.Contains("MV") && !pedido.Contains("MC") && !pedido.Contains("MN") && !pedido.Contains("MG") && !pedido.Contains("MT"))
                    {
                        if (pedido.Contains("Lomo")) // descuento en carnes de mansos normales
                        {
                            descontarProducto("Lomo", getCantCarne1());
                        }
                        if (pedido.Contains("Ave"))
                        {
                            descontarProducto("Ave", getCantCarne1());
                        }
                        if (pedido.Contains("Churrasco"))
                        {
                            descontarProducto("Churrasco", getCantCarne1());
                        }
                        if (pedido.Contains("Mechada"))
                        {
                            descontarProducto("Mechada", getCantCarne1());
                        }
                    }
                    
                }
            }
            if (pedido.Contains("Promo Sandwich")) // descuento de carne de promos
            {
                if (pedido.Contains("Lomo"))
                {
                    descontarProducto("Lomo", getCantCarne1());
                }
                if (pedido.Contains("Ave"))
                {
                    descontarProducto("Ave", getCantCarne1());
                }
                if (pedido.Contains("Churrasco"))
                {
                    descontarProducto("Churrasco", getCantCarne1());
                }
                if (pedido.Contains("Mechada"))
                {
                    descontarProducto("Mechada", getCantCarne1());
                }
            }
            if (pedido.Contains("Mini")) // descuento en carnes de sandwich minis
            {
                if (pedido.Contains("Lomo"))
                {
                    descontarProducto("MinLomo", getCantCarne1());
                }
                if (pedido.Contains("Ave"))
                {
                    descontarProducto("MinAve", getCantCarne1());
                }
                if (pedido.Contains("Churrasco"))
                {
                    descontarProducto("MinChurrasco", getCantCarne1());
                }
                if (pedido.Contains("Mechada"))
                {
                    descontarProducto("MinMechada", getCantCarne1());
                }
            }
            if (pedido.Contains("Comp"))
            {
                if (pedido.Contains("Minic"))
                {
                    descontarProducto("VMinic", getCantVienesas());
                }
                else
                {
                    descontarProducto("VPromo", getCantVienesas());
                }
            }
            if (pedido.Contains("As"))
            {
                descontarProducto("MechAS", getCantCarne1());
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
                tipoProducto = "Manso";
            }

            if (producto == "MT")
            {
                formula = "consumo_prod + (" + cantidad + ") * 1.5";
                tipoProducto = "Manso";
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
            comm.CommandText = "UPDATE productos SET consumo_prod =" + formula + ", fecha = '" + fecha + "' WHERE nombre_prod ='" + tipoProducto + "'; " +
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