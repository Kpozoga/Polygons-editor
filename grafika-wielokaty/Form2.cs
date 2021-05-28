using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafika_wielokaty
{
    
    public partial class Form2 : Form
    {
        public double deg;
        public Form2()
        {

            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = deg.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double.TryParse(textBox1.Text,out deg);
        }
    }
}
