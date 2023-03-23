using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data.Common;
using System.Data.Odbc;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MySqlX.XDevAPI.Relational;
using Mysqlx.Connection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using Microsoft.Win32;
using Tienda.Quark.controller;

namespace Tienda.Quark.model
{
    internal class ConnectionBD
    {
        public MySqlConnection conn { get; set; }
        public String Database_name { get; set; }
        public String Server { get; set; }
        public String uid { get; set; }
        public String pwd { get; set; }

        private static ConnectionBD _instance = null;

        string myConnectionString;

        public static ConnectionBD Istance()
        {
            if (_instance == null)
                _instance = new ConnectionBD();
            return _instance;
        }
        public bool IsConnect()
        {
            if (conn == null)
            {
                if (String.IsNullOrEmpty(Database_name))
                    return false;
                try
                {
                    string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", Server, Database_name, uid, pwd);

                    conn = new MySqlConnection(connstring);
                   

                   // String quee = "CREATE TABLE prenda(ID int  NOT NULL,prenda varchar(255)  NOT NULL,manga Boolean,cuello Boolean,tipo Boolean,calidad Boolean );";

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Erro" + ex.Message);
                    //conn.Close();
                }
               
            }

            return true;
        }
        public void Open(MySqlConnection conn)
        {
            conn.Open();
        }
        public void Close(MySqlConnection conn)
        {
            conn.Close();
        }
        public void createPrenda(MySqlConnection conn)
        {
            try
            {
            
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO quark_store.prenda(ID, prenda, manga, cuello, tipo, calidad) VALUES(@id, @prenda, @cuello, @manga, @tipo, @calidad);";
                comm.Parameters.AddWithValue("@id", 1);
                comm.Parameters.AddWithValue("@prenda", "pantalon");
                comm.Parameters.AddWithValue("@cuello", null);
                comm.Parameters.AddWithValue("@manga", null);
                comm.Parameters.AddWithValue("@tipo", false);
                comm.Parameters.AddWithValue("@calidad", true);


                comm.ExecuteNonQuery();

        

                //conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Erro" + ex.Message);
            }

        }
        public void createCotizacion(MySqlConnection conn, ControllerTienda controllerTienda)
        {
            try
            {

                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO cotizacion(ID,date_cot ,cod_vend,nombreVend, prenda_tipo, cantidad, calc_cotizacion) VALUES(@id, @date, @cod,@nameV ,@prenda, @cant,@calc);\r\n";
                comm.Parameters.AddWithValue("@id", 1);
                comm.Parameters.AddWithValue("@date",controllerTienda.getControllerdateV());
                comm.Parameters.AddWithValue("@cod", controllerTienda.getControllerVId());
                comm.Parameters.AddWithValue("@nameV", controllerTienda.getControllerNameV()+" "+controllerTienda.getControllerLastNameV());
                comm.Parameters.AddWithValue("@prenda", controllerTienda.tipo);
                comm.Parameters.AddWithValue("@cant", controllerTienda.getControllerVcant());
                comm.Parameters.AddWithValue("@calc", controllerTienda.calc);


                comm.ExecuteNonQuery();



                //conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Erro" + ex.Message);
            }

        }

        public void getCotizacion(MySqlConnection conn, System.Windows.Forms.TextBox textBox1)
        {
            try
            {

                // string cadena = "SELECT PersonID, LastName, FirstName, Address, City\r\nFROM quark_store.cotizaciones;\r\n";


                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM cotizacion;";

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.AppendText(reader.GetString(0));
                    textBox1.AppendText(" ,");
                    textBox1.AppendText(reader.GetString(1));
                    textBox1.AppendText(" ,");
                    textBox1.AppendText(reader.GetString(2));
                    textBox1.AppendText(", ");
                    textBox1.AppendText(reader.GetString(3));
                    textBox1.AppendText(", ");
                    textBox1.AppendText(reader.GetString(4));
                    textBox1.AppendText(", ");
                    textBox1.AppendText(reader.GetString(5));
                    textBox1.AppendText(", $");
                    textBox1.AppendText(reader.GetString(6));
                  



                    textBox1.AppendText(Environment.NewLine);
                }



            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Erro" + ex.Message);

            }
        }
        public void getPrenda(MySqlConnection conn)
        {
            try
            {


            
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Select * from prenda";

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.ToString());
                    Console.WriteLine(reader.GetString(0));
                    Console.WriteLine(reader.GetBoolean(4));
                }



                //conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Erro" + ex.Message);
            }

        }
    }
}
    
