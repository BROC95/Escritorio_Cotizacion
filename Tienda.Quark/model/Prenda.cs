using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Quark.model
{
    public abstract class Prenda
    {
        public int cant;
        public Boolean calidad_premium;

        public Prenda( int cant, bool calidad_premium)
        {
            
            this.cant = cant;
            this.calidad_premium = calidad_premium;
        }

        public abstract float getPrecio(int cantidad,float precio);
    }
}
