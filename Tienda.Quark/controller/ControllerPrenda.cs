using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Quark.model;

namespace Tienda.Quark.controller
{
    internal class ControllerPrenda
    {
        public ControllerPrenda() { }
        public List<Camisa> CreateCamisa()
        {
            String tipoC = "camisa";
            //  Camisa( bool calidad, int cant,bool manga, bool cuello)
            // Manga corta
            Camisa NcamisaPreCoMao = new Camisa(tipoC,true, 100, true, true);
            Camisa NcamisaStandCoMao = new Camisa(tipoC,false, 100, true, true);
            Camisa NcamisaPreCoCo = new Camisa(tipoC,true, 150, true, false);
            Camisa NcamisaStandCoCo = new Camisa(tipoC, false, 150, true, false);

            // Larga
            Camisa NcamisaPreLaMao = new Camisa(tipoC, true, 75, false, true);
            Camisa NcamisaStandLaMao = new Camisa(tipoC, false, 75, false, true);
            Camisa NcamisaPreLaCo = new Camisa(tipoC, true, 175, false, false);
            Camisa NcamisaStandLaCo = new Camisa(tipoC, false, 175, false, false);

            var StockCamisa = new List<Camisa> { NcamisaPreCoMao, NcamisaStandCoMao,
                NcamisaPreCoCo, NcamisaStandCoCo, NcamisaPreLaMao,
                NcamisaStandLaMao,NcamisaPreLaCo,NcamisaStandLaCo };
            foreach (var name in StockCamisa)
            {
                Console.WriteLine($"Stock  {name.tipo}!");
            }
            //Console.WriteLine(NcamisaPreCoMao.getPrecio(1,100));

            return StockCamisa;
        }
        public List<Pantalon> CreatePantalon()
        {
            String tipoP = "pantalon";
            //  Pantalon( bool calidad, int cant, bool chupin) 
            Pantalon NpantalonPreChu = new Pantalon(tipoP,true, 750, true);
            Pantalon NpantalonCoChu = new Pantalon(tipoP,false, 750, true);
            Pantalon NpantalonPreCo = new Pantalon(tipoP, true, 250, false);
            Pantalon NpantalonCoco = new Pantalon(tipoP, false, 250, false);


            var StockPantalon = new List<Pantalon> { NpantalonPreChu,  NpantalonPreCo,
                NpantalonCoChu,NpantalonCoco };
            foreach (var name in StockPantalon)
            {
                Console.WriteLine($"Stock  {name.tipo}!");
            }
            //Console.WriteLine(NpantalonPreChu.getPrecio(1,100));
            //Console.WriteLine(NpantalonPreCo.getPrecio(1,100));
           // Console.WriteLine(NpantalonCoChu.getPrecio(1,100));
            //Console.WriteLine(NpantalonCoco.getPrecio(2,100));

            return StockPantalon;
        }

    }
}
