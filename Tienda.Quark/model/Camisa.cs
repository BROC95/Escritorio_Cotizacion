using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Quark.model
{
    public class Camisa : Prenda
    {
        public Boolean manga { get; set; }
        public Boolean cuello { get; set; }

        public String tipo;
        public Camisa( String tipo,bool calidad, int cant, bool manga, bool cuello) : base(cant, calidad)
        {
            this.tipo = tipo;
            this.manga = manga;
            this.cuello = cuello;
        }

        public override float getPrecio(int cantidad,float precio)
        {
            Console.WriteLine("precio"+precio);
            Console.WriteLine("Cantidad"+cantidad);
            Console.WriteLine("Stock"+this.cant);
            if (cantidad <= this.cant && cantidad>0)
            {
                float precioB = precio;


                 if (manga == true && cuello == true && calidad_premium == true)
                {
                    Console.WriteLine("Camisa manga corta, cuello mao, calidad premium");
                    precioB += (float)(-precioB * 0.10 + precioB * 0.03 + precioB * 0.30);
                }
                else if (manga == true && cuello == false && calidad_premium == true)
                {
                    Console.WriteLine("Camisa manga corta, cuello normal, calidad premium");
                    precioB += (float)(-precioB * 0.10 + precioB * 0.30);
                }
              
                else if (manga == true && cuello == true && calidad_premium == false)
                {
                    Console.WriteLine("Camisa manga corta, cuello mao, calidad comun");
                    precioB += (float)(-precioB * 0.10 + precioB * 0.03);
                }
                else if (manga == true && cuello == false && calidad_premium == false)
                {
                    Console.WriteLine("Camisa manga corta, cuello comun, calidad comun");
                    precioB += (float)(-precioB * 0.10);
                }
                else if (manga == false && cuello == true && calidad_premium == true)
                {
                    Console.WriteLine("Camisa manga larga, cuello mao, calidad premium");
                    precioB += (float)(precioB * 0.03 + precioB * 0.30);
                }
                else if (manga == false && cuello == false && calidad_premium == true)
                {
                    Console.WriteLine("Camisa manga larga, cuello normal, calidad premium");
                    precioB += (float)(precioB * 0.30);
                }
                else if (manga == false && cuello == false && calidad_premium == false)
                {
                    Console.WriteLine("Camisa manga larga, cuello normal, calidad comun");

                }
                else if (manga == false && cuello == true && calidad_premium == false)
                {
                    Console.WriteLine("Camisa manga larga, cuello mao, calidad comun");
                    precioB += (float)(precioB * 0.03);
                }
                Console.WriteLine("Precio und=" + precio);
                Console.WriteLine("Precio undTotal=" + precioB);
                //Console.WriteLine(this.cant+"*"+precioB+"="+this.cant*precioB);
                Console.WriteLine("Consulta");
                Console.WriteLine(cantidad+ "*" + precioB + "=" + cantidad * precioB);
                
                return cantidad*precioB;
            }
            else
            {
                return 0;
            }
            
        }
    }
}
