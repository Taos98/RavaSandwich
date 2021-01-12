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
                    comm.CommandText = "INSERT into ventas(nombre_cliente, nombre_cajero, pedido, total_a_pagar, metodo_pago, fecha_venta, subtotal, descuentos) VALUES ('" + textBoxNombreCliente.Text + "','" + lo.getNombre() + "', '" + ve.getPedidoCliente() + "'," + totalVenta() + ",'" + metodosPago + "', '" + fechaHora + "', "+ve.getTotal()+","+textBoxDescuento.Text+")";
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
    }
}
