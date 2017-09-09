using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR.Clases
{
    public interface IOperador
    {
        String getSimbolo();

        double operar(IExpresion expresion1, IExpresion expresion2);
    }
}
