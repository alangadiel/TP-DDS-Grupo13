using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR.Clases
{
    class Exponente : IOperador
    {
        public String getSimbolo()
        {
            return "^";
        }

        public double operar(IExpresion expresion1, IExpresion expresion2)
        {
            return Math.Pow(expresion1.getResultado(), expresion2.getResultado());
        }
    }
}
