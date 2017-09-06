using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR.Clases2
{
    public class BinaryTree<T>
    {
        private BinaryTreeNode<T> root;
        //public Indicador Indicador;
        //public string Nombre;

        public BinaryTree()
        {
            //this.Indicador = i;
            root = null;
        }

        public virtual void Clear()
        {
            root = null;
        }

        public BinaryTreeNode<T> Root
        {
            get
            {
                return root;
            }
            set
            {
                root = value;
            }
        }
    }
}
