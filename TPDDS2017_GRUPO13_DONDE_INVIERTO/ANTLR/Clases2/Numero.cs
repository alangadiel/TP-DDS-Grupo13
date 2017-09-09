using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR.Clases2
{
    class Numero : IContenidoNodo
    {
        private double valor;

        public Numero(double valor)
        {
            this.valor = valor;
        }

        public double getResultado()
        {
            return valor;
        }

        public string getString()
        {
            return valor.ToString();
        }
    }
}
