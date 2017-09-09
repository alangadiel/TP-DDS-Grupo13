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


namespace ANTLR
{
    public partial class CargarIndicadores : Form
    {
        /*
        
        

        private void button1_Click(object sender, EventArgs e)
        {
            CargarIndicadores.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }*/

        public CargarIndicadores()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private TreeNode agregarAlTreeView(BinaryTreeNode<IContenidoNodo> nodo)
        {
            TreeNode newNode = new TreeNode("Error");
            if (nodo.Value != null) newNode = new TreeNode(nodo.Value.getString());
            if (nodo.Left != null) newNode.Nodes.Add(agregarAlTreeView(nodo.Left));
            if (nodo.Right != null) newNode.Nodes.Add(agregarAlTreeView(nodo.Right));

            return newNode;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Indicador.IsValid(textBox2.Text))
            {
                treeView1.Nodes.Clear();
                BinaryTreeNode<IContenidoNodo> nodo = Indicador.getBinaryTree(textBox2.Text).Root;
                treeView1.Nodes.Add(agregarAlTreeView(nodo));
            }
            else
            {
                MessageBox.Show("No se encuentra el indicador");
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!Indicador.IsValid(textBox2.Text))
            {
                GramaticaLexer lexer = new GramaticaLexer(new AntlrInputStream(textBox1.Text));
                CommonTokenStream tokens = new CommonTokenStream(lexer);
                GramaticaParser parser = new GramaticaParser(tokens);
                parser.BuildParseTree = true;
                GramaticaParser.IndicadorContext indicadorContext = parser.indicador();
                ParseTreeWalker walker = new ParseTreeWalker();
                Listener listener = new Listener(textBox2.Text);
                walker.Walk(listener, indicadorContext);

                //lo muestro en el tree view
                treeView1.Nodes.Clear();
                BinaryTreeNode<IContenidoNodo> nodo = listener.Indicador.BinaryTree.Root;
                treeView1.Nodes.Add(agregarAlTreeView(nodo));

                //guardar Listener.ArbolBinario
                Indicador.Indicadores.Add(listener.Indicador);
            }
            else
            {
                MessageBox.Show("Ya existe el indicador");
            }
        }
    }
}
