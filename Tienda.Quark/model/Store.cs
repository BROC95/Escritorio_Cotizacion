using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tienda.Quark.model
{


    internal class Store
    {
        public String nombre;
        public String direccion;
        public List<Camisa> listaCamisa{ get; set; }
        public List<Pantalon> listaPantalon { get; set; }


        public Store(String nombre,String Direccion, List<Pantalon> listaP,List<Camisa> listaC) {
        this.nombre = nombre;
        this.direccion = Direccion; 
        this.listaPantalon = listaP;
        this.listaCamisa = listaC;

        
        }
        public Vendedor createVendedor(String nombre_V,String lastname_V,String cod)
        {

            Vendedor vend = new Vendedor(nombre_V, lastname_V, cod);
            return vend;

        }

        public override String ToString()
        {
            return base.ToString() + ": " + nombre+ ", " + direccion+ ", " + listaCamisa;
        }


    }
}
