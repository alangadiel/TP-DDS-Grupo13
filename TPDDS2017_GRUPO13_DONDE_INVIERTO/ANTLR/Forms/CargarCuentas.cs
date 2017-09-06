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
    public partial class CargarCuentas : Form
    {
        public CargarCuentas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.empresaSeleccionada != null)
            {
                Empresa empresa = Empresa.Empresas.Find(x => x.Nombre == Form1.empresaSeleccionada);
                int val;
                if (!int.TryParse(textBox3.Text, out val))
                {
                    //error
                    MessageBox.Show("Valor invalido");
                }
                empresa.addCuenta(textBox2.Text, val);
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay ninguna empresa seleccionada");
            }
        }
    }
}
