using ANTLR.Condiciones;
using DONDE_INVIERTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DONDE_INVIERTO.ANTLR
{
    public class RoeConsistente : ITipoCondicion
    {
        public TipoCondicion Tipo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Analizar(Empresa empresa, List<ComponenteOperando> componentesOperandos)
        {
            throw new NotImplementedException();
        }
    }
}