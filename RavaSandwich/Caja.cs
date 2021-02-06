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
    public partial class Caja : Form
    {
        int totalEfectivo = 0;
        int totalTransbank = 0;
        int totalCreditos = 0;
        int totalPedidosYa = 0;
        int totaldescuentos = 0;
        int totalSobre = 0;
        int totalPYOnline = 0;
        int subTotalPedidosYa = 0;
        static int tv = 0;
        public Caja()
        {
            InitializeComponent();

            //Fecha actual:
            String fecha = DateTime.Now.ToString("d");

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
            comm.CommandText = "SELECT tipo_pago, subtotal, fecha, descuento, pedido from ventas";
            //Leer BD
            NpgsqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())//Si la tabla tiene 1 o más filas...
            {
                if (dr.GetString(2).Contains(fecha))
                {
                    listVentas.Items.Add("-" + dr.GetString(0) + "  " + dr.GetInt16(1));
                    //Clasifica las cuentas para calcular el total de cada una
                    if (dr.GetString(0) == "Efectivo")
                    {
                        totalEfectivo = totalEfectivo + dr.GetInt16(1);
                    }
                    if (dr.GetString(0) == "Transbank")
                    {
                        totalTransbank = totalTransbank + dr.GetInt16(1);
                    }
                    if (dr.GetString(0) == "Consumo Local")
                    {
                        totalCreditos = totalCreditos + dr.GetInt16(1);
                    }
                    if (dr.GetString(0).Contains("Pedidos Ya"))
                    {
                        totalPedidosYa = totalPedidosYa + dr.GetInt16(1);

                        if(dr.GetString(4).Contains("Sandwich"))
                        {
                            totalSobre = totalSobre + 1510;
                            subTotalPedidosYa = subTotalPedidosYa + 1510 + dr.GetInt32(1);
                        }
                        if (dr.GetString(4).Contains("Manso"))
                        {
                            if (dr.GetString(4).Contains("MS"))
                            {
                                totalSobre = totalSobre + 1610;
                                subTotalPedidosYa = subTotalPedidosYa + 1610 + dr.GetInt32(1);


                            }
                            if (dr.GetString(4).Contains("MT1") || dr.GetString(4).Contains("MT2") || dr.GetString(4).Contains("MT3"))
                            {
                                totalSobre = totalSobre + 1710;
                                subTotalPedidosYa = subTotalPedidosYa + 1710 + dr.GetInt32(1);
                            }
                            if (dr.GetString(4).Contains("MT5"))
                            {
                                totalSobre = totalSobre + 1810;
                                subTotalPedidosYa = subTotalPedidosYa + 1710 + dr.GetInt32(1);
                            }
                            if (dr.GetString(4).Contains("EG") || dr.GetString(4).Contains("MV") || dr.GetString(4).Contains("MC") || dr.GetString(4).Contains("MN"))
                            {
                                totalSobre = totalSobre + 1710;
                                subTotalPedidosYa = subTotalPedidosYa + 1710 + dr.GetInt32(1);
                            }
                            else
                            {
                                totalSobre = totalSobre + 1510;
                                subTotalPedidosYa = subTotalPedidosYa + 1510 + dr.GetInt32(1);
                            }

                        }
                        if(dr.GetString(0).Equals("Pedidos Ya, efectivo") || (dr.GetString(0).Equals("Pedidos Ya, con descuento")))
                        {
                            totaldescuentos = totaldescuentos + dr.GetInt32(3);
                        }
                        if (dr.GetString(0).Equals("Pedidos Ya, online"))
                        {
                            totalPYOnline = totalPYOnline + dr.GetInt32(1);
                        }
                    }
                    
                   
                    
                }
                
            }
            //Cerrar comandos
            comm.Dispose();
            //Desconectar BD
            conn.Close();

            //Muestra los totales calculados en los textbox que corresponden
            txtVtasEfec.Text = totalEfectivo + "";
            txtVtasTransbank.Text = totalTransbank + "";
            txtVtasCredito.Text = totalCreditos + "";
            txtVtasPedidosYa.Text = subTotalPedidosYa + "";
            tv = totalCreditos + totalEfectivo + totalTransbank+totalPedidosYa; //total vtas = efectivo + transbank + pedidosya
            listVentas.Items.Add("\nTotal Ventas: \n" + tv);
            txtSobre.Text = totalSobre + "";
            txtDescuentos.Text = (totaldescuentos + totalPYOnline)+ "";

            CajaGastos g = new CajaGastos();
            CajaSueldos s = new CajaSueldos();
            txtGastosSueldos.Text = (g.getTotalGastos() + s.getSueldoCajero() + s.getSueldoPlanchero()) + "";
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
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

        private void btnBillete_Click(object sender, EventArgs e)
        {
            CajaBilletes cb = new CajaBilletes();
            cb.Show();
            
        }

        private void btnSueldos_Click(object sender, EventArgs e)
        {
            CajaSueldos cs = new CajaSueldos();
            cs.Show();
            
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            CajaGastos cg = new CajaGastos();
            cg.Show();
            this.Close();
           
        }

        private void btnCerrarTurno_Click(object sender, EventArgs e)
        {
            CerrarCaja ct = new CerrarCaja();
            ct.Show();
            this.Close();
        }
        public int getDineroEnCaja()
        {
            // sub total de dinero en caja para luego hacer el cuadre
            int subtotalDC = tv - int.Parse(txtVtasTransbank.Text) - int.Parse(txtVtasCredito.Text) - int.Parse(txtGastosSueldos.Text) - int.Parse(txtDescuentos.Text);

            return subtotalDC;
        }

        public int getDineroFisico()
        {
            //metodo para tener el dinero fisico
            CajaBilletes b = new CajaBilletes();
            int subtotalDF = b.getTotal() - int.Parse(txtSobre.Text);
            return subtotalDF;
        }
        public int getTotalVenta()
        {
            return tv;
        }
    }
}
