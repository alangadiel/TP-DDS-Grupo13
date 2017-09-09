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

namespace ANTLR.Forms
{
    public partial class VerIndicadores : Form
    {
        public static string indicadorSeleccionado { get; set; }

        public VerIndicadores()
        {
            InitializeComponent();

            listBox1.Items.Clear();

            foreach (Indicador indicador in Indicador.Indicadores)
            {
                listBox1.Items.Add(indicador.Nombre);
            }
        }

        private TreeNode agregarAlTreeView(BinaryTreeNode<IContenidoNodo> nodo)
        {
            TreeNode newNode = new TreeNode("Error");
            if (nodo.Value != null) newNode = new TreeNode(nodo.Value.getString());
            if (nodo.Left != null) newNode.Nodes.Add(agregarAlTreeView(nodo.Left));
            if (nodo.Right != null) newNode.Nodes.Add(agregarAlTreeView(nodo.Right));

            return newNode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Indicador indicador = Indicador.Indicadores.Find(x => x.Nombre == indicadorSeleccionado);

            treeView1.Nodes.Clear();
            
            BinaryTreeNode<IContenidoNodo> nodo = indicador.BinaryTree.Root;
            treeView1.Nodes.Add(agregarAlTreeView(nodo));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            indicadorSeleccionado = Indicador.Indicadores[listBox1.SelectedIndex].Nombre;
        }
    }
}
