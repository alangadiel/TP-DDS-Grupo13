using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR.Clases2
{
    public class Operador : IContenidoNodo
    {
        public enum Operadores { Suma = '+', Resta = '-', Multiplicacion = '*', Division = '/' , Potenciacion = '^' }

        public Operadores contenido { get; set; }
        public Operador(string o)
        { 
            switch (o[0])
            {
                case '+':
                    contenido = Operadores.Suma;
                    break;
                case '-':
                    contenido = Operadores.Resta;
                    break;
                case '*':
                    contenido = Operadores.Multiplicacion;
                    break;
                case '/':
                    contenido = Operadores.Division;
                    break;
                case '^':
                    contenido = Operadores.Potenciacion;
                    break;
            }
        }

        public static bool esOperador(String cadena)
        {
            if (cadena == "+" || cadena == "-" || cadena == "*" || cadena == "/" || cadena == "^")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getString()
        {
            return contenido.ToString();
        }

        internal double Operar(double izq, double der)
        {
            switch (contenido)
            {
                case Operadores.Suma: return izq + der;
                case Operadores.Resta: return izq - der;
                case Operadores.Multiplicacion: return izq * der;
                case Operadores.Division: return izq / der;
                case Operadores.Potenciacion: return Math.Pow(izq, der);
                default: return 0;
            }
        }
    }
}
