using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IParseTree = Antlr4.Runtime.Tree;
using Antlr4.Runtime;
using System.Windows.Forms;
using ANTLR.Clases2;
using System.Text.RegularExpressions;

namespace ANTLR
{
 

    public class Listener : GramaticaBaseListener
    {
        //private Dictionary<String, IOperador> operadores;
        //public ExpresionCompuesta expresionActual;
        private bool s;
        public Indicador Indicador { get; set; }
        Regex regExConstante = new Regex(@"[a-zA-Z]+");
        Regex regExNumero = new Regex(@"[0-9]+");
        Regex regExCuenta = new Regex(@"EBITDA|FDS|FCF|INOD|INOC");
        //public static NodoArbolBinario NodoActual = Arbol;
        //private bool lado; //true=izq, flase=der
        private string nombreDelArbol;
        public Listener(string nombre) : base()
        {
            nombreDelArbol = nombre;
            s = true;
        }

       /* public IExpresion getExpresion()
        {
            return expresionActual;
        }
        */
        override
        public void EnterIndicador(GramaticaParser.IndicadorContext ctx)
        {
            if (s)
            {

                this.Indicador = new Indicador(nombreDelArbol);
                BinaryTree<IContenidoNodo> ArbolBinario = this.Indicador.BinaryTree;
                IParseTree.IParseTree nodo;
                if (ctx.ChildCount < 3)
                {
                    nodo = limpiarArbol(ctx.GetChild(0));
                    if (nodo != null) nodo = nodo.GetChild(1) ?? nodo;
                }
                else
                {
                   nodo = ctx.GetChild(1) ?? ctx.GetChild(0);
                }
                if (nodo != null && Operador.esOperador(nodo.GetText()))
                {
                    ArbolBinario.Root = obtenerNodo(nodo);
                    ArbolBinario.Root.Left = obtenerNodo(nodo.Parent.GetChild(0));
                    ArbolBinario.Root.Right = obtenerNodo(nodo.Parent.GetChild(2));
                } else
                {
                    ArbolBinario.Root = obtenerNodo(nodo);
                }
                s = false;
            }
        }

        private IParseTree.IParseTree limpiarArbol(IParseTree.IParseTree nodo) {
            if (nodo is IParseTree.IErrorNode) {
                System.Windows.Forms.MessageBox.Show("Error en nodo: " + nodo.GetText());
                // todo: manejar el error
                return null;
            } else {
                switch (nodo.ChildCount) {
                    case 0: return nodo; //es hoja
                    case 1: return limpiarArbol(nodo.GetChild(0)); //saltar
                    case 3: return (nodo.GetChild(0).GetText() == "(" && nodo.GetChild(2).GetText() == ")") ? 
                        //en una rama, si hay parentesis saltarlos, sino no.
                        limpiarArbol(nodo.GetChild(1)) : nodo;
                    default: return null;
                }
            }
        }

        //fuente: https://msdn.microsoft.com/en-us/library/ms379572(v=vs.80).aspx

        private IContenidoNodo getObjeto(IParseTree.IParseTree nodo)
        {
            if (Operador.esOperador(nodo.GetText()))
            {
                return new Operador(nodo.GetText());
            }
            else if (regExNumero.IsMatch(nodo.GetText()))
            {
                return new Numero(Double.Parse(nodo.GetText()));
            }
            else if (regExCuenta.IsMatch(nodo.GetText()))
            {
                var cu = new Cuenta();
                cu.Nombre = nodo.GetText();
                return cu;
            }
            else if (regExConstante.IsMatch(nodo.GetText()))
            {
                return new Constante(nodo.GetText());
            }

            return null;
        }
        private BinaryTreeNode<IContenidoNodo> getObjetoEnNodo(IParseTree.IParseTree nodo)
        {
            if (Indicador.IsValid(nodo.GetText()))
                return Indicador.getBinaryTree(nodo.GetText()).Root;
             else 
                return new BinaryTreeNode<IContenidoNodo>(getObjeto(nodo));
        }

        private BinaryTreeNode<IContenidoNodo> obtenerNodo(IParseTree.IParseTree nodo)
        {
            BinaryTreeNode<IContenidoNodo> nodoBinario = new BinaryTreeNode<IContenidoNodo>();
            if (nodo != null)
            {
                IParseTree.IParseTree nodoLimpio = limpiarArbol(nodo);
                switch (nodoLimpio.ChildCount)
                {
                    case 0:
                        return getObjetoEnNodo(nodoLimpio);
                    case 3:
                        nodoBinario = getObjetoEnNodo(nodoLimpio.GetChild(1));
                        nodoBinario.Left = obtenerNodo(nodoLimpio.GetChild(0));
                        nodoBinario.Right = obtenerNodo(nodoLimpio.GetChild(2));
                        return nodoBinario;
                }
            }
            return nodoBinario;
        }
    }
}