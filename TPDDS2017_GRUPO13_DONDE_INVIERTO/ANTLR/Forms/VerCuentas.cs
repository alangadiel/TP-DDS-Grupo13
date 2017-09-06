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
using System.Linq;

namespace ANTLR.Forms
{
    public partial class VerCuentas : Form
    {
        public VerCuentas()
        {
            InitializeComponent();
            if (Form1.empresaSeleccionada != null)
            {
                Empresa empresa = Empresa.Empresas.Find(x => x.Nombre == Form1.empresaSeleccionada);

                for (int i = 0; i < empresa.Cuentas.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = empresa.Cuentas[i].Nombre;
                    dataGridView1.Rows[i].Cells[1].Value = empresa.Cuentas[i].Valor;
                }
            }
            else
            {
                MessageBox.Show("No hay ninguna empresa seleccionada");
                this.Close();
            }
        }
    }
}
