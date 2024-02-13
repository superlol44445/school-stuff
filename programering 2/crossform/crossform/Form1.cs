using System.Runtime.CompilerServices;

namespace crossform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2(this,button1).ShowDialog();

            foreach(var control in Controls)
            {
                MessageBox.Show(control.ToString());
            }
        }
    }
}
