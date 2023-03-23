using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Quark.model
{
    internal class Cotizacion
    {
        public float precio;
        public int id_cot;
        public DateTime date_cot;
        public String cod_vend;
        public int cant_prendas;
        public float calc_cot;

        public Cotizacion(int id_cot, DateTime date_cot,String cod_vend, int cat_predas,float precio)
        {
            this.id_cot = id_cot; 
            this.date_cot = date_cot;
            this.cod_vend = cod_vend;
            this.cant_prendas = cat_predas;
            this.precio = precio;
        }

        public String getCotizacionTipoC(Camisa camisa)
        {       
            return camisa.tipo;
        }
        public String getCotizacionTipoP(Pantalon pantalon)
        {
            return pantalon.tipo;
        }
        public float getCotizacionPrecioCamisa(Camisa camisa)
        {
            
            this.calc_cot = camisa.getPrecio(this.cant_prendas, this.precio);
            return calc_cot;
        }
        public float getCotizacionPrecioPantalon(Pantalon pantalon)
        {

            this.calc_cot = pantalon.getPrecio(this.cant_prendas, this.precio);
            return calc_cot;
        }



    }

}
