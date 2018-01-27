using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR.Clases2
{
    public class Indicador : IContenidoNodo
    {
        public static List<Indicador> Indicadores = new List<Indicador>();
        public static BinaryTree<IContenidoNodo> getBinaryTree (string Nombre)
        {
            return Indicadores.Find(x => x.Nombre == Nombre).BinaryTree;
        }

        public static bool IsValid (string Nombre)
        {
            if (Indicadores.Count == 0)
            {
                return false;
            } else
            {
                return Indicadores.Any(x => x.Nombre == Nombre);
            }
            
        }

        public string getString()
        {
            return this.Nombre;
        }

        public BinaryTree<IContenidoNodo> BinaryTree { get; set; }
        public string Nombre { get; set;  }
        public Indicador(BinaryTree<IContenidoNodo> arbol, string nombre)
        {
            this.Nombre = nombre;
            this.BinaryTree = arbol;
        }
        public Indicador(string nombre)
        {
            this.Nombre = nombre;
            this.BinaryTree = new BinaryTree<IContenidoNodo>();
        }

        public bool Calcular(out double resultado)
        {
            return Resolver(out resultado, BinaryTree.Root);
        }

        private bool Resolver(out double resultado, BinaryTreeNode<IContenidoNodo> nodo)
        {
            if(nodo.Value is Operador)
            {
                double izq, der;
                if (Resolver(out izq, nodo.Left) && Resolver(out der, nodo.Right))
                {
                    resultado = ((Operador)nodo.Value).Operar(izq, der);
                    return true;
                }
                else
                {
                    resultado = 0;
                    return false;
                }
            }
            else if(nodo.Value is Numero)
            {
                resultado = ((Numero)nodo.Value).getResultado();
                return true;
            }
            else if (nodo.Value is Cuenta)
            {
                resultado = ((Cuenta)nodo.Value).Valor;
                return true;
            }
            else if (nodo.Value is Indicador)
            {
                return ((Indicador)nodo.Value).Calcular(out resultado);
            }
            else
            {
                resultado = 0;
                return false;
            }
        }
    }
}
