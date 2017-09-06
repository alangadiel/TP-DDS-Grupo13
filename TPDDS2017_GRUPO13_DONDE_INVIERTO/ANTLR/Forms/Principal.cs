using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using ANTLR.Clases;
using ANTLR.Clases2;
using ANTLR.Forms;

namespace ANTLR
{
    public partial class Form1 : Form
    {
        public static string empresaSeleccionada { get; set; }
        public Form1()
        {
            InitializeComponent();



            //listBox1.DataSource = Empresa.Empresas;
            foreach (Empresa empresa in Empresa.Empresas)
            {
                listBox1.Items.Add(empresa.Nombre);
            }

            foreach (Metodologia metodologia in Metodologia.Metodologias)
            {
                listBox1.Items.Add(metodologia.Nombre);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f = new CargarCuentas();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var f = new CargarIndicadores();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var f = new VerIndicadores();
            f.Show();
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var f = new CargarMetodologias();
            f.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            empresaSeleccionada = Empresa.Empresas[listBox1.SelectedIndex].Nombre;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            empresaSeleccionada = null;
            listBox1.Items.Clear();
            Empresa.OrdenarEmpresas();
            foreach (Empresa empresa in Empresa.Empresas)
            {
                listBox1.Items.Add(empresa.Nombre);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var f = new VerCuentas();
            if (empresaSeleccionada != null)
                f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var f = new VerMetodologias();
            if (empresaSeleccionada != null)
                f.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            var f = new CargarEmpresas();
            f.Show();
        }
    }
}
