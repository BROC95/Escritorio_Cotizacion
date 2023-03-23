using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Quark.model;


namespace Tienda.Quark.controller
{
    internal class ControllerTienda
    {
        ControllerPrenda controllerPrenda;
        ControllerCotizacion controllerCotizacion;


        String controllerName;
        String controllerDireccion;
        Store controllerStore;
        Vendedor controllerVendedor;
        public String tipo;
        public float calc;
        public ControllerTienda(String nameS,String Direccion) {
            controllerPrenda = new ControllerPrenda();
            controllerName = nameS;
            controllerDireccion = Direccion;
        }

        public void createTienda()
        {
            controllerStore=new Store(controllerName, controllerDireccion, controllerPrenda.CreatePantalon(), controllerPrenda.CreateCamisa());

        }
        public String getControllerNameS() { return  controllerStore.nombre; }
        public String getControllerNameD() { return  controllerStore.direccion; }

        public void createVededor(String nombre_V,String lastname_V,String cod)
        {
         controllerVendedor=   controllerStore.createVendedor(nombre_V, lastname_V, cod);
        }
        public String getControllerNameV() { return controllerVendedor.nombre; }
        public DateTime getControllerdateV() { return controllerVendedor.getDateCot(); }
        public String getControllerLastNameV() { return controllerVendedor.lastname; }
        public String getControllerVId() { return controllerVendedor.id_code; }
        public String getControllerTipoC() { return controllerCotizacion.getTipoC(); }
        public String getControllerTipoP() { return controllerCotizacion.getTipoP(); }
        public int getControllerVcant() { return controllerVendedor.getCantCot(); }

        public List<Camisa> getStockCamisa()
        {
            return controllerStore.listaCamisa;
        }
        public List<Pantalon> getStockPantalon()
        {
            return controllerStore.listaPantalon;
        }

        public float cotizacionCamisa( Camisa camisa,int id_cot,int cant,float precio,DateTime date_col)
        {
            controllerCotizacion = new ControllerCotizacion(this.controllerVendedor, camisa);
            return controllerCotizacion.getCotizacionCamisa(id_cot,cant,precio,date_col);

        }
        public float cotizacionPantalon(Pantalon pantalon, int id_cot, int cant, float precio, DateTime date_col)
        {
            controllerCotizacion = new ControllerCotizacion(this.controllerVendedor, pantalon);
            return controllerCotizacion.getCotizacionPant(id_cot, cant, precio, date_col);

        }
    }
}
