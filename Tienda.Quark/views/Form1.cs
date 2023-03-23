using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tienda.Quark.controller;
using Tienda.Quark.model;
using Tienda.Quark.views;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Tienda.Quark
{
    public partial class Form1 : Form
    {
        ConnectionBD ConnectionBD;
        ControllerTienda controllerTienda;
        List<Camisa> ControllerCamisaList;
        List<Pantalon> ControllerPantalonList;
        int n=0;
        public Form1()
        {
            InitializeComponent();

            controllerTienda = new ControllerTienda("Tienda Quark","Armenia,Quindio,Colombia");
            controllerTienda.createTienda();
            Console.WriteLine(controllerTienda.getControllerNameS());
            controllerTienda.createVededor("Breyner", "Ocampo", "1234");
            Console.WriteLine(controllerTienda.getControllerNameV());
            ControllerCamisaList = controllerTienda.getStockCamisa();
            ControllerPantalonList = controllerTienda.getStockPantalon();


            //Console.WriteLine(ControllerCamisaList.Count);
            //Console.WriteLine(ControllerCamisaList[0]);
            //Console.WriteLine(controllerTienda.cotizacionCamisa(ControllerCamisaList[0], 1, 10, 100, DateTime.Now));
            //Console.WriteLine(controllerTienda.cotizacionPantalon(ControllerPantalonList[0], 1, 10, 100, DateTime.Now));

            label1.Text = controllerTienda.getControllerNameS();
            label4.Text = controllerTienda.getControllerNameD();

            label2.Text = controllerTienda.getControllerNameV();
            label3.Text = controllerTienda.getControllerVId();

            groupBox1.Text = "Prenda";
            radioButton1.Text = "Camisa";
            checkBox1.Text = "Manga corta";
            checkBox2.Text = "Cuello mao";
            radioButton2.Text = "Pantalon";
            checkBox4.Text = "Chupin";


            radioButton4.Text = "Standard";
            radioButton3.Text = "Premium";

            this.ConnectionBD = new ConnectionBD();
            // ConnectionBD.getConnection();
            var dbCon = ConnectionBD.Istance();
            dbCon.Server = "127.0.0.1";
            dbCon.Database_name = "quark_store";
            dbCon.uid = "root";
            dbCon.pwd = "";
            Console.WriteLine(dbCon);
            Console.WriteLine(ConnectionBD.conn);
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                Console.WriteLine(dbCon.Server);
                ConnectionBD.Open(dbCon.conn);
      //          ConnectionBD.createPrenda(dbCon.conn);
                ConnectionBD.Close(dbCon.conn);
            }
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                Console.WriteLine(dbCon.Server);
                ConnectionBD.Open(dbCon.conn);
                ConnectionBD.getPrenda(dbCon.conn);
                ConnectionBD.Close(dbCon.conn);
            }


            button1.Enabled = false;
            radioButton2.Checked = true;
            radioButton3.Checked = true;

            textBox1.Text = "0";
            textBox2.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            


         bool calidad_premium = radioButton3.Checked;
         bool calidad_ = radioButton4.Checked;
         n += 1;
            
            try
            {
                int precio = Convert.ToInt32(textBox1.Text);
                int cant = Convert.ToInt32(textBox2.Text);

                    if (radioButton1.Checked)
                {
                    controllerTienda.tipo = "camisa";
                    bool manga = checkBox1.Checked;
                    bool cuello = checkBox2.Checked;
                    if (manga == true && cuello == true && calidad_premium == true)
                    {
                        Console.WriteLine("Camisa manga corta, cuello mao, calidad premium2222");
                        Console.WriteLine(ControllerCamisaList[0].calidad_premium);
                        label8.Text = ControllerCamisaList[0].cant.ToString();

                        if (cant > ControllerCamisaList[0].cant)
                        {
                            MessageBox.Show("Error Cantidad solicitada fuera del stock");

                        }
                            controllerTienda.calc = controllerTienda.cotizacionCamisa(ControllerCamisaList[0], n += 1, cant, precio, DateTime.Now);
                        Console.WriteLine(controllerTienda.calc);
                    }
                    else if (manga == true && cuello == true && calidad_ == true)
                    {
                        Console.WriteLine("Camisa manga corta, cuello comun, calidad comun22");
                        label8.Text = ControllerCamisaList[1].cant.ToString();
                        if (cant > ControllerCamisaList[1].cant)
                        {
                            MessageBox.Show("Error Cantidad solicitada fuera del stock");

                        }
                        controllerTienda.calc = controllerTienda.cotizacionCamisa(ControllerCamisaList[1], n += 1, cant, precio, DateTime.Now);
                    }

                    else if (manga == true && cuello == false && calidad_premium == true)
                    {
                        Console.WriteLine("Camisa manga corta, cuello comun, calidad pre3333");
                        label8.Text = ControllerCamisaList[2].cant.ToString();
                        if (cant > ControllerCamisaList[2].cant)
                        {
                            MessageBox.Show("Error Cantidad solicitada fuera del stock");

                        }
                        controllerTienda.calc = controllerTienda.cotizacionCamisa(ControllerCamisaList[2], n += 1, cant, precio, DateTime.Now);
                    }
                    else if (manga == true && cuello == false && calidad_ == true)
                    {
                        Console.WriteLine("Camisa manga corta, cuello comun, calidad comun4444");
                        label8.Text = ControllerCamisaList[3].cant.ToString();
                        if (cant > ControllerCamisaList[3].cant)
                        {
                            MessageBox.Show("Error Cantidad solicitada fuera del stock");

                        }
                        controllerTienda.calc = controllerTienda.cotizacionCamisa(ControllerCamisaList[3], n += 1, cant, precio, DateTime.Now);
                    }
                    else if (manga == false && cuello == true && calidad_premium == true)
                    {
                        Console.WriteLine("Camisa manga larga, cuello mao, calidad premium5555");
                        label8.Text = ControllerCamisaList[4].cant.ToString();
                        if (cant > ControllerCamisaList[4].cant)
                        {
                            MessageBox.Show("Error Cantidad solicitada fuera del stock");

                        }
                        controllerTienda.calc = controllerTienda.cotizacionCamisa(ControllerCamisaList[4], n += 1, cant, precio, DateTime.Now);
                    }
                    else if (manga == false && cuello == true && calidad_ == true)
                    {
                        Console.WriteLine("Camisa manga larga, cuello normal, calidad premium66666");
                        label8.Text = ControllerCamisaList[5].cant.ToString();
                        if (cant > ControllerCamisaList[5].cant)
                        {
                            MessageBox.Show("Error Cantidad solicitada fuera del stock");

                        }
                        controllerTienda.calc = controllerTienda.cotizacionCamisa(ControllerCamisaList[5], n += 1, cant, precio, DateTime.Now);
                    }
                    else if (manga == false && cuello == false && calidad_premium == true)
                    {
                        Console.WriteLine("Camisa manga larga, cuello mao, calidad comun88888");
                        label8.Text = ControllerCamisaList[6].cant.ToString();
                        if (cant > ControllerCamisaList[6].cant)
                        {
                            MessageBox.Show("Error Cantidad solicitada fuera del stock");

                        }
                        controllerTienda.calc = controllerTienda.cotizacionCamisa(ControllerCamisaList[6], n += 1, cant, precio, DateTime.Now);
                    }
                    else if (manga == false && cuello == false && calidad_ == true)
                    {
                        Console.WriteLine("Camisa manga larga, cuello normal, calidad comun77777");
                        label8.Text = ControllerCamisaList[7].cant.ToString();
                        if (cant > ControllerCamisaList[7].cant)
                        {
                            MessageBox.Show("Error Cantidad solicitada superior al stock contizado");

                        }
                        controllerTienda.calc = controllerTienda.cotizacionCamisa(ControllerCamisaList[7], n += 1, cant, precio, DateTime.Now);
                    }


                }
                else if (radioButton2.Checked)
                {
                    Console.WriteLine("");
                    bool chupin = checkBox4.Checked;

                    controllerTienda.tipo = "pantalon";

                    //MessageBox.Show(calidad_.ToString()+calidad_premium.ToString()+ chupin.ToString());


                    if (chupin == true && calidad_premium == true)
                    {
                        Console.WriteLine("Pantalon chupin, calidad premium1111");
                        label8.Text = ControllerCamisaList[0].cant.ToString();
                        controllerTienda.calc = controllerTienda.cotizacionPantalon(ControllerPantalonList[0], n += 1, cant, precio, DateTime.Now);
                    }
                    else if (chupin == false && calidad_premium == true)
                    {
                        Console.WriteLine("Pantalon chupin,  calidad comun2222");
                        label8.Text = ControllerCamisaList[1].cant.ToString();
                        controllerTienda.calc = controllerTienda.cotizacionPantalon(ControllerPantalonList[1], n += 1, cant, precio, DateTime.Now);

                    }
                    else if (chupin == true && calidad_ == true)
                    {
                        Console.WriteLine("Pantalon comun,  calidad chupin33333");
                        label8.Text = ControllerCamisaList[2].cant.ToString();
                        controllerTienda.calc = controllerTienda.cotizacionPantalon(ControllerPantalonList[2], n += 1, cant, precio, DateTime.Now);

                    }
                    else if (chupin == false && calidad_ == true)
                    {
                        Console.WriteLine("Pantalon comun,  calidad comun4444");
                        label8.Text = ControllerCamisaList[3].cant.ToString();
                        controllerTienda.calc = controllerTienda.cotizacionPantalon(ControllerPantalonList[3], n += 1, cant, precio, DateTime.Now);

                    }
                }

                label9.Text = controllerTienda.calc.ToString();
                
                var dbCon = ConnectionBD.Istance();
                if (dbCon.IsConnect())
                {
                    //suppose col0 and col1 are defined as VARCHAR in the DB
                    Console.WriteLine(dbCon.Server);
                    ConnectionBD.Open(dbCon.conn);
                    //          ConnectionBD.createPrenda(dbCon.conn);
                    ConnectionBD.createCotizacion(dbCon.conn, controllerTienda);
                    ConnectionBD.Close(dbCon.conn);
                }

                
            }
            catch(Exception ex) {

                MessageBox.Show("Error ", ex.Message);
            }


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void OpenWindow(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 open = new Form2();
            //this.Visible = false;
            open.Show();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                checkBox4.Enabled = false;
            }
            else
            {
                checkBox4.Enabled = true;
              
            }
            if (radioButton1.Checked == true && (radioButton3.Checked == true || radioButton4.Checked == true))
            {

                button1.Enabled = true;

            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
              
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
              
            }

            if (radioButton2.Checked == true && (radioButton3.Checked == true || radioButton4.Checked == true))
            {

                button1.Enabled = true;

            }
            else
            {
                button1.Enabled = false;
            }

        }

     
    }

      
    }




