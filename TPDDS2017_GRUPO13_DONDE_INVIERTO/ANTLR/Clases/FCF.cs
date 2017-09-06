using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR.Clases
{
    class FCF : ICuenta
    {
        private String valor;

        public FCF(String valor)
        {
            this.valor = valor;
        }

        public double getResultado()
        {
            return 0;
        }

        public String getResultadoString()
        {
            return valor;
        }
    }
}
