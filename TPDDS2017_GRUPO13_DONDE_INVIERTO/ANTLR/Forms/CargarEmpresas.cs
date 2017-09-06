using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ANTLR.Clases2;

namespace ANTLR
{
    public partial class CargarEmpresas : Form
    {

        public CargarEmpresas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var empresa = new Empresa(textBox1.Text);
            this.Close();
            //Form1.listBox1.Items.Add(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
