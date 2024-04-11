using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace client_thingy
{
    public partial class Form1 : Form
    {
        TcpClient client = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ip = textBox1.Text;
            int.TryParse(textBox2.Text, out int port);
            client = new TcpClient(ip,port);   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(client == null)
            {
                return;
            }
            var StringBytes = Encoding.UTF8.GetBytes(textBox3.Text);
            client.GetStream().WriteByte((byte)StringBytes.Length);
            client.GetStream().Write(StringBytes,0,StringBytes.Length);
        }
    }
}