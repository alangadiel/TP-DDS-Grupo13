using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR.Clases2
{
    class Constante : IContenidoNodo
    {
        private string valor;

        public Constante(string valor)
        {
            this.valor = valor;
        }

        public double getResultado()
        {
            return 0;
        }

        public string getString()
        {
            return valor;
        }
    }
}
