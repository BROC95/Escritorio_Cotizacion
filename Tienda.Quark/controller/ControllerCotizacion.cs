using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Quark.model;

namespace Tienda.Quark.controller
{
    internal class ControllerCotizacion
    {

        Vendedor vendedor;
        Camisa camisa;
        Pantalon pantalon;
        public ControllerCotizacion(Vendedor vendedor,Camisa camisa) {
            this.vendedor = vendedor;
            this.camisa = camisa;
            //cotizacion = new Cotizacion(id_cot, date_cot, cod_vend, cat_predas);
        }
        public ControllerCotizacion(Vendedor vendedor, Pantalon pantalon)
        {
            this.vendedor = vendedor;
            this.pantalon = pantalon;
            //cotizacion = new Cotizacion(id_cot, date_cot, cod_vend, cat_predas);
        }
        public String getTipoC()
        {
            return vendedor.cotizacion.getCotizacionTipoC(this.camisa);
        }
        public String getTipoP()
        {
            return vendedor.cotizacion.getCotizacionTipoP(this.pantalon);
        }
        public float getCotizacionCamisa(int id_cot,int cant, float precio, DateTime date_cot)
        {
            vendedor.createCotizacion(id_cot, cant, precio, date_cot);

            return vendedor.getCalcCotCa(this.camisa);

            
        }
        public float getCotizacionPant(int id_cot, int cant, float precio, DateTime date_cot)
        {
            vendedor.createCotizacion(id_cot, cant, precio, date_cot);

            return vendedor.getCalcCotPa(this.pantalon);


        }



    }
}
