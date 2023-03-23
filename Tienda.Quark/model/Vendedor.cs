using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda.Quark.model
{
    internal  class Vendedor
    {
        public String nombre { get; set; }
        public String lastname;
        public String id_code;
        public Cotizacion cotizacion;

        public Vendedor(String name,String lastname,String id_code)
        {
            this.nombre = name;
            this.lastname = lastname;   
            this.id_code = id_code; 
        }

  //      public  abstract  Vendedor createVendedor();

        public override String ToString()
        {
            return base.ToString() + ": " + nombre + ", "+lastname + ", "+ id_code;
        }

        public void createCotizacion(int id_cot,int cant,float precio,DateTime date_cot)
        {
            this.cotizacion = new Cotizacion(id_cot, date_cot, this.id_code, cant,precio);

        }
        public DateTime getDateCot()
        {
            return this.cotizacion.date_cot;
        }
        public int getCantCot()
        {
            return this.cotizacion.cant_prendas;
        }
        public float getCalcCotCa(Camisa camisa)
        {
            return cotizacion.getCotizacionPrecioCamisa(camisa);
        }
     
        public float getCalcCotPa(Pantalon pantalon)
        {
            return cotizacion.getCotizacionPrecioPantalon(pantalon);
        }


    }


    
}
