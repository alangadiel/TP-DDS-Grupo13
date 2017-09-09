using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR.Clases
{
    class Division : IOperador
    {
        public String getSimbolo()
        {
            return "/";
        }

        public double operar(IExpresion expresion1, IExpresion expresion2)
        {
            if(expresion2.getResultado() != 0)
            {
                return expresion1.getResultado() / expresion2.getResultado();
            }
            else
            {
                throw new Exception("No se puede dividir por 0");
            }
        }
    }
}
