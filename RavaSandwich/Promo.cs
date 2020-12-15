using System;
using System.Collections.Generic;
using System.Text;

namespace RavaSandwich
{
    class Promo
    {
        private int cantPromos;
        private String promo;
        private String ingredientes;
        private String bebidas;
        private int vasos;
        private String extras;
        private String comentario;
        private String salsas;
        private int total;

        public Promo(int cantPromos, String promo, String ingredientes, String bebidas, int vasos, String extras, String comentario, String salsas, int total)
        {
            this.cantPromos = cantPromos;
            this.promo = promo;
            this.ingredientes = ingredientes;
            this.bebidas = bebidas;
            this.vasos = vasos;
            this.extras = extras;
            this.comentario = comentario;
            this.salsas = salsas;
            this.total = total;
        }

        public int getCantPromos()
        {
            return cantPromos;
        }

        public void setCantPromos(int cantPromos)
        {
            this.cantPromos = cantPromos;
        }

        public String getPromo()
        {
            return promo;
        }

        public void setPromo(String promo)
        {
            this.promo = promo;
        }

        public String getIngredientes()
        {
            return ingredientes;
        }

        public void setIngredientes(String ingredientes)
        {
            this.ingredientes = ingredientes;
        }

        public String getBebidas()
        {
            return bebidas;
        }

        public void setBebidas(String bebidas)
        {
            this.bebidas = bebidas;
        }

        public int getVasos()
        {
            return vasos;
        }

        public void setVasos(int vasos)
        {
            this.vasos = vasos;
        }

        public String getExtras()
        {
            return extras;
        }

        public void setExtras(String extras)
        {
            this.extras = extras;
        }

        public String getComentario()
        {
            return comentario;
        }

        public void setComentario(String comentario)
        {
            this.comentario = comentario;
        }

        public String getSalsas()
        {
            return salsas;
        }

        public void setSalsas(String salsas)
        {
            this.salsas = salsas;
        }

        public int getTotal()
        {
            return total;
        }

        public void setTotal(int total)
        {
            this.total = total;
        }
        
        public String toString()
        {
            return "Cantidad promos: " + cantPromos + " || Promo: " + promo + "\nIngredientes: " + ingredientes + "\nBebidas: " + bebidas + " || Vasos: " + vasos + "\nExtras: " + extras + "\nComentarios: " + comentario + "\nSalsas Agregadas: " + salsas + "\n\nTOTAL A PAGAR: " + total;
        }

    }
}
