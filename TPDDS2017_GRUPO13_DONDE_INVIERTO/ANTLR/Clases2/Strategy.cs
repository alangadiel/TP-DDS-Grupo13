using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR.Clases2
{
    public abstract class Strategy
    {
        public static bool IsValid(string s)
        {
            switch (s)
            {
                case "<":
                    return true;
                case ">":
                    return true;
                default:
                    return false;
            }
        }

        public static Strategy ToStrategy(string s)
        {
            switch (s)
            {
                case "<":
                    return new StrategyMenor();
                case ">":
                    return new StrategyMayor();
                default:
                    return null;
            }
        }
        public string Nombre { get; set; }

        //Retorna True si a>b
        public abstract bool Comparar(int a, int b);

    }
}