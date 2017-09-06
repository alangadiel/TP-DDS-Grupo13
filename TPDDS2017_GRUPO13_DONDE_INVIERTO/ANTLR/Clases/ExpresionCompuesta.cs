using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ANTLR.Clases;


namespace ANTLR.Clases
{
    public class ExpresionCompuesta : IExpresion
    {
        public List<IExpresion> expresiones { get; set; }
        public List<IOperador> operadores { get; set; }
        private double n;

        public ExpresionCompuesta(IExpresion expresion1, IExpresion expresion2, IOperador operador)
        {
            /*this.expresion1 = expresion1;
            this.operador = operador;
            this.expresion2 = expresion2;*/
        }

        public ExpresionCompuesta()
        {
            expresiones = new List<IExpresion>();
            operadores = new List<IOperador>();
        }

        public double getResultado()
        {
            if (operadores.Count == 0)
            {
                //throw new Exception("No hay operadores definidos");
                return 0;
            }
            else
            {
                IExpresion expresionAuxiliar = new ExpresionCompuesta();

                expresionAuxiliar = expresiones[0];

                for (int i = 0; i < operadores.Count; i++)
                {
                    n = operadores[i].operar(expresionAuxiliar, expresiones[i + 1]);
                    //expresionAuxiliar = new Numero(n);
                }

                return n;
            }
            
            //return operadores.operar(expresion1, expresion2);
        }
    }
}
