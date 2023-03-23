using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Quark.model
{
    internal class Pantalon:Prenda
    {

        public Boolean chupin { get; set; }
        public String tipo;
        public Pantalon(String tipo ,bool calidad, int cant, bool chupin) : base( cant, calidad)
        {
            this.tipo = tipo;
            this.chupin = chupin;
        }

        public override float getPrecio(int cantidad,float precio)
        {
            Console.WriteLine("precio" + precio);
            Console.WriteLine("Cantidad" + cantidad);
            Console.WriteLine("Stock" + this.cant);
            if (cantidad <= this.cant && cantidad>0)
            {
                float precioB = precio;
                if (chupin == true && calidad_premium == true)
                {
                    Console.WriteLine("Pantalon chupin, calidad premium");
                    precioB += (float)(-precioB * 0.12 + precioB * 0.30);
                }
                else if (chupin == true && calidad_premium == false)
                {
                    Console.WriteLine("Pantalon chupin,  calidad comun");
                    precioB += (float)(-precioB * 0.12 );
                }
                else if (chupin == false&& calidad_premium == false)
                {
                    Console.WriteLine("Pantalon comun,  calidad comun");
                    
                }
                else if (chupin == false && calidad_premium == true)
                {
                    Console.WriteLine("Pantalon comun,  calidad premium");
                    precioB += (float)(precioB * 0.30);
                }
                Console.WriteLine("Precio und=" + precio);
                Console.WriteLine("Precio undTotal=" + precioB);
                //Console.WriteLine(this.cant + "*" + precioB + "=" + this.cant * precioB);
                Console.WriteLine("Consulta");
                Console.WriteLine(cantidad + "*" + precioB + "=" + cantidad * precioB);

                return cantidad*precioB;
            }
            else
            {
                return 0;
            }

        }
    }
}

