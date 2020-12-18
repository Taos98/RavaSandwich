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
            return "Cantidad promos: " + cantPromos + "  Promo: " + promo + "\nIngredientes: " + ingredientes + "\nBebidas: " + bebidas + "\nVasos: " + vasos + "\nExtras: " + extras + "\nComentarios: " + comentario + "\nSalsas Agregadas: " + salsas + "\n\nTOTAL: " + total;
        }
        public String impresion()
        {
            String agregados = "";
            int contCarnes = 0;
            int contAgreg = 0;
            String[] ingred = ingredientes.Split(", ");
            for(int i=0; i<ingred.Length-1; i++)
            {
                if(ingred[i]=="Ave" || ingred[i]=="Churrasco" || ingred[i] == "Mechada" || ingred[i] == "Lomito" || ingred[i] == "Lomo")
                {
                    contCarnes++;
                    agregados = agregados + "Carne " + contCarnes + ": " + ingred[i] + "\n";
                }
                else
                {
                    contAgreg++;
                    agregados = agregados + "Agregado" + contAgreg + ": " + ingred[i] + "\n";
                }
                
            }
            String sals1 = "";
            String sals2 = "";
            String[] sa = salsas.Split(", ");
            for (int j=0; j<sa.Length-1; j++)
            {
                if (sa[j].Contains("S1"))
                {
                    String []s = sa[j].Split("S1");
                    sals1 = sals1 + s[0] +", " ;
                }
                if (sa[j].Contains("S2"))
                {
                    String []s = sa[j].Split("S2");
                    sals2 = sals2 + s[0] + ", ";
                }
            }

            return promo + "\r\n" + agregados +extras+"\r\nSalsas S1: "+sals1+"\r\nSalsas S2: "+sals2+"\nComentarios: "+comentario;
        }

    }
}
