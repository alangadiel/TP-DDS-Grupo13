using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR.Clases2
{
    public class StrategyMenor : Strategy
    {
        public override bool Comparar(int a, int b)
        {
            return a < b;
        }
    }
}