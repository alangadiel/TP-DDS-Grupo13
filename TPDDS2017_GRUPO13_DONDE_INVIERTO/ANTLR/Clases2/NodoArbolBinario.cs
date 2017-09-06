using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR
{
    public class NodoArbolBinario
    {
        
        public NodoArbolBinario ramaIzquierda;
        public NodoArbolBinario ramaDerecha;
        public NodoArbolBinario raiz;
        public Type tipo { get; set; }
        public object contenido { get; set; }

        public NodoArbolBinario(ContenidoNodo cont, NodoArbolBinario r)
        {
            contenido = cont;
            raiz = r;
        }
    }
}
