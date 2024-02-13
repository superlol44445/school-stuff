using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crossform
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        private Button buttonfromotherform;
        public Form2(Form1 form1, Button buttonfromotherform)
        {
            InitializeComponent();
            this.form1 = form1;
            this.buttonfromotherform = buttonfromotherform;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.Visible = !form1.Visible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonfromotherform.Text = "hej";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttonfromotherform.Dispose();
        }
    }
}
