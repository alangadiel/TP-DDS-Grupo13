using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR.Clases2
{
    class Cuenta : IContenidoNodo
    {
        public string Nombre { get; set; }
        public double Valor { get; set; }
        /*
        public Cuenta(string nombre, int valor)
        {
            this.Valor = valor;
            this.Nombre = nombre;
        }*/

        public double getResultado()
        {
            return Valor;
        }

        public string getString()
        {
            return Nombre;
        }
        
    }
}
