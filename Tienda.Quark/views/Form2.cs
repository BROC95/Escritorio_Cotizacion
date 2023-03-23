using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Tienda.Quark.model;

namespace Tienda.Quark.views
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            ConnectionBD ConnectionBD = new ConnectionBD();
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
                
                Console.WriteLine(dbCon.Server);
                ConnectionBD.Open(dbCon.conn);
                ConnectionBD.getCotizacion(dbCon.conn,textBox1);
                ConnectionBD.Close(dbCon.conn);
            }


        }
    }
}
