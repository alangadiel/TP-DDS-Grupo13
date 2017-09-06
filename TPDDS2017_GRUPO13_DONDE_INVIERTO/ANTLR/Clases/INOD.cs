using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR.Clases
{
    class INOD : ICuenta
    {
        private String valor;

        public INOD(String valor)
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
