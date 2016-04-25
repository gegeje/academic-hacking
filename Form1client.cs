using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
namespace _6_october_kabdit_il_hilaly_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TcpClient myclient = new TcpClient(textBox1.Text, 5020);
            NetworkStream myns = myclient.GetStream();
            StreamWriter mysw = new StreamWriter(myns);
            mysw.WriteLine("sarina");
            mysw.Close();
            myns.Close();
            myclient.Close();

        }
    }
}
