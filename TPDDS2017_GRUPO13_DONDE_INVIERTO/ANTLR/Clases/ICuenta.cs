using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR.Clases
{
    interface ICuenta : IExpresion
    {
        double getResultado();
        String getResultadoString();
    }
}
