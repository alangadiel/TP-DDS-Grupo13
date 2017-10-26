using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR.Clases
{
    interface ITermino : IExpresion
    {
        string getResultadoString();
    }
}
