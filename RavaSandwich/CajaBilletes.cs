using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RavaSandwich
{
    public partial class CajaBilletes : Form
    {
        //variable global para guardar el total
        static int total;
        public CajaBilletes()
        {
            InitializeComponent();
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Almacena estos valores para calcular el total y guardarlo en la variable global
            int veintemil = (int)(numeric20K.Value * 20000);
            int diezmil = (int)(numeric10K.Value * 10000);
            int cincomil = (int)(numeric5K.Value * 5000);
            int dosmil = (int)(numeric2K.Value * 2000);
            int mil = (int)(numeric1K.Value * 1000);
            int quiniento = (int)(numeric500.Value * 500);
            int cien = (int)(numeric100.Value * 100);
            int cincuenta = (int)(numeric50.Value * 50);
            int diez = (int)(numeric10.Value * 10);
            total = veintemil + diezmil + cincomil + dosmil + mil + quiniento + cien + cincuenta + diez;
            this.Close();

        }

        private void txt20K_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt10K_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txt5K_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt2K_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt1K_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt500_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt100_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt50_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt10_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void numeric20K_ValueChanged(object sender, EventArgs e)
        {
            //Calcula el total del dinero por el momento y muestra el total al instante
            int veintemil = (int)(numeric20K.Value * 20000);
            int diezmil = (int)(numeric10K.Value * 10000);
            int cincomil = (int)(numeric5K.Value * 5000);
            int dosmil = (int)(numeric2K.Value * 2000);
            int mil = (int)(numeric1K.Value * 1000);
            int quiniento = (int)(numeric500.Value * 500);
            int cien = (int)(numeric100.Value * 100);
            int cincuenta = (int)(numeric50.Value * 50);
            int diez = (int)(numeric10.Value * 10);
            txt20K.Text = veintemil + "";
            txt10K.Text = diezmil + "";
            txt5K.Text = cincomil + "";
            txt2K.Text = dosmil + "";
            txt1K.Text = mil + "";
            txt500.Text = quiniento + "";
            txt100.Text = cien + "";
            txt50.Text =  cincuenta+ "";
            txt10.Text = diez + "";
            total = veintemil + diezmil + cincomil + dosmil + mil + quiniento + cien + cincuenta+diez;
            txtTotal.Text = total + "";

        }

        private void numeric10K_ValueChanged(object sender, EventArgs e)
        {
            //Calcula el total del dinero por el momento y muestra el total al instante
            int veintemil = (int)(numeric20K.Value * 20000);
            int diezmil = (int)(numeric10K.Value * 10000);
            int cincomil = (int)(numeric5K.Value * 5000);
            int dosmil = (int)(numeric2K.Value * 2000);
            int mil = (int)(numeric1K.Value * 1000);
            int quiniento = (int)(numeric500.Value * 500);
            int cien = (int)(numeric100.Value * 100);
            int cincuenta = (int)(numeric50.Value * 50);
            int diez = (int)(numeric10.Value * 10);
            txt20K.Text = veintemil + "";
            txt10K.Text = diezmil + "";
            txt5K.Text = cincomil + "";
            txt2K.Text = dosmil + "";
            txt1K.Text = mil + "";
            txt500.Text = quiniento + "";
            txt100.Text = cien + "";
            txt50.Text = cincuenta + "";
            txt10.Text = diez + "";
            total = veintemil + diezmil + cincomil + dosmil + mil + quiniento + cien + cincuenta + diez;
            txtTotal.Text = total + "";
        }

        private void numeric5K_ValueChanged(object sender, EventArgs e)
        {
            //Calcula el total del dinero por el momento y muestra el total al instante
            int veintemil = (int)(numeric20K.Value * 20000);
            int diezmil = (int)(numeric10K.Value * 10000);
            int cincomil = (int)(numeric5K.Value * 5000);
            int dosmil = (int)(numeric2K.Value * 2000);
            int mil = (int)(numeric1K.Value * 1000);
            int quiniento = (int)(numeric500.Value * 500);
            int cien = (int)(numeric100.Value * 100);
            int cincuenta = (int)(numeric50.Value * 50);
            int diez = (int)(numeric10.Value * 10);
            txt20K.Text = veintemil + "";
            txt10K.Text = diezmil + "";
            txt5K.Text = cincomil + "";
            txt2K.Text = dosmil + "";
            txt1K.Text = mil + "";
            txt500.Text = quiniento + "";
            txt100.Text = cien + "";
            txt50.Text = cincuenta + "";
            txt10.Text = diez + "";
            total = veintemil + diezmil + cincomil + dosmil + mil + quiniento + cien + cincuenta + diez;
            txtTotal.Text = total + "";
        }

        private void numeric2K_ValueChanged(object sender, EventArgs e)
        {
            //Calcula el total del dinero por el momento y muestra el total al instante
            int veintemil = (int)(numeric20K.Value * 20000);
            int diezmil = (int)(numeric10K.Value * 10000);
            int cincomil = (int)(numeric5K.Value * 5000);
            int dosmil = (int)(numeric2K.Value * 2000);
            int mil = (int)(numeric1K.Value * 1000);
            int quiniento = (int)(numeric500.Value * 500);
            int cien = (int)(numeric100.Value * 100);
            int cincuenta = (int)(numeric50.Value * 50);
            int diez = (int)(numeric10.Value * 10);
            txt20K.Text = veintemil + "";
            txt10K.Text = diezmil + "";
            txt5K.Text = cincomil + "";
            txt2K.Text = dosmil + "";
            txt1K.Text = mil + "";
            txt500.Text = quiniento + "";
            txt100.Text = cien + "";
            txt50.Text = cincuenta + "";
            txt10.Text = diez + "";
            total = veintemil + diezmil + cincomil + dosmil + mil + quiniento + cien + cincuenta + diez;
            txtTotal.Text = total + "";
        }

        private void numeric1K_ValueChanged(object sender, EventArgs e)
        {
            //Calcula el total del dinero por el momento y muestra el total al instante
            int veintemil = (int)(numeric20K.Value * 20000);
            int diezmil = (int)(numeric10K.Value * 10000);
            int cincomil = (int)(numeric5K.Value * 5000);
            int dosmil = (int)(numeric2K.Value * 2000);
            int mil = (int)(numeric1K.Value * 1000);
            int quiniento = (int)(numeric500.Value * 500);
            int cien = (int)(numeric100.Value * 100);
            int cincuenta = (int)(numeric50.Value * 50);
            int diez = (int)(numeric10.Value * 10);
            txt20K.Text = veintemil + "";
            txt10K.Text = diezmil + "";
            txt5K.Text = cincomil + "";
            txt2K.Text = dosmil + "";
            txt1K.Text = mil + "";
            txt500.Text = quiniento + "";
            txt100.Text = cien + "";
            txt50.Text = cincuenta + "";
            txt10.Text = diez + "";
            total = veintemil + diezmil + cincomil + dosmil + mil + quiniento + cien + cincuenta + diez;
            txtTotal.Text = total + "";
        }

        private void numeric500_ValueChanged(object sender, EventArgs e)
        {
            //Calcula el total del dinero por el momento y muestra el total al instante
            int veintemil = (int)(numeric20K.Value * 20000);
            int diezmil = (int)(numeric10K.Value * 10000);
            int cincomil = (int)(numeric5K.Value * 5000);
            int dosmil = (int)(numeric2K.Value * 2000);
            int mil = (int)(numeric1K.Value * 1000);
            int quiniento = (int)(numeric500.Value * 500);
            int cien = (int)(numeric100.Value * 100);
            int cincuenta = (int)(numeric50.Value * 50);
            int diez = (int)(numeric10.Value * 10);
            txt20K.Text = veintemil + "";
            txt10K.Text = diezmil + "";
            txt5K.Text = cincomil + "";
            txt2K.Text = dosmil + "";
            txt1K.Text = mil + "";
            txt500.Text = quiniento + "";
            txt100.Text = cien + "";
            txt50.Text = cincuenta + "";
            txt10.Text = diez + "";
            total = veintemil + diezmil + cincomil + dosmil + mil + quiniento + cien + cincuenta + diez;
            txtTotal.Text = total + "";
        }

        private void numeric100_ValueChanged(object sender, EventArgs e)
        {
            //Calcula el total del dinero por el momento y muestra el total al instante
            int veintemil = (int)(numeric20K.Value * 20000);
            int diezmil = (int)(numeric10K.Value * 10000);
            int cincomil = (int)(numeric5K.Value * 5000);
            int dosmil = (int)(numeric2K.Value * 2000);
            int mil = (int)(numeric1K.Value * 1000);
            int quiniento = (int)(numeric500.Value * 500);
            int cien = (int)(numeric100.Value * 100);
            int cincuenta = (int)(numeric50.Value * 50);
            int diez = (int)(numeric10.Value * 10);
            txt20K.Text = veintemil + "";
            txt10K.Text = diezmil + "";
            txt5K.Text = cincomil + "";
            txt2K.Text = dosmil + "";
            txt1K.Text = mil + "";
            txt500.Text = quiniento + "";
            txt100.Text = cien + "";
            txt50.Text = cincuenta + "";
            txt10.Text = diez + "";
            total = veintemil + diezmil + cincomil + dosmil + mil + quiniento + cien + cincuenta + diez;
            txtTotal.Text = total + "";
        }

        private void numeric50_ValueChanged(object sender, EventArgs e)
        {
            //Calcula el total del dinero por el momento y muestra el total al instante
            int veintemil = (int)(numeric20K.Value * 20000);
            int diezmil = (int)(numeric10K.Value * 10000);
            int cincomil = (int)(numeric5K.Value * 5000);
            int dosmil = (int)(numeric2K.Value * 2000);
            int mil = (int)(numeric1K.Value * 1000);
            int quiniento = (int)(numeric500.Value * 500);
            int cien = (int)(numeric100.Value * 100);
            int cincuenta = (int)(numeric50.Value * 50);
            int diez = (int)(numeric10.Value * 10);
            txt20K.Text = veintemil + "";
            txt10K.Text = diezmil + "";
            txt5K.Text = cincomil + "";
            txt2K.Text = dosmil + "";
            txt1K.Text = mil + "";
            txt500.Text = quiniento + "";
            txt100.Text = cien + "";
            txt50.Text = cincuenta + "";
            txt10.Text = diez + "";
            total = veintemil + diezmil + cincomil + dosmil + mil + quiniento + cien + cincuenta + diez;
            txtTotal.Text = total + "";
        }

        private void numeric10_ValueChanged(object sender, EventArgs e)
        {
            //Calcula el total del dinero por el momento y muestra el total al instante
            int veintemil = (int)(numeric20K.Value * 20000);
            int diezmil = (int)(numeric10K.Value * 10000);
            int cincomil = (int)(numeric5K.Value * 5000);
            int dosmil = (int)(numeric2K.Value * 2000);
            int mil = (int)(numeric1K.Value * 1000);
            int quiniento = (int)(numeric500.Value * 500);
            int cien = (int)(numeric100.Value * 100);
            int cincuenta = (int)(numeric50.Value * 50);
            int diez = (int)(numeric10.Value * 10);
            txt20K.Text = veintemil + "";
            txt10K.Text = diezmil + "";
            txt5K.Text = cincomil + "";
            txt2K.Text = dosmil + "";
            txt1K.Text = mil + "";
            txt500.Text = quiniento + "";
            txt100.Text = cien + "";
            txt50.Text = cincuenta + "";
            txt10.Text = diez + "";
            total = veintemil + diezmil + cincomil + dosmil + mil + quiniento + cien + cincuenta + diez;
            txtTotal.Text = total + "";
        }
        //Obtiene el total del dinero para que pueda ser usado en las otras clases
        public int getTotal()
        {
            return total;
        }
    }
}
