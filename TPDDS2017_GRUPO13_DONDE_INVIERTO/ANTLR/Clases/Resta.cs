using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR.Clases
{
    class Resta : IOperador
    {
        public String getSimbolo()
        {
            return "-";
        }

        public double operar(IExpresion expresion1, IExpresion expresion2)
        {
            return expresion1.getResultado() - expresion2.getResultado();
        }
    }
}
