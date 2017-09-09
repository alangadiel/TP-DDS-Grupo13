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
    }
}
