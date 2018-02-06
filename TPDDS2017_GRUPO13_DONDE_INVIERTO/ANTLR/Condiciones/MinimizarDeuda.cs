using ANTLR.Condiciones;
using DONDE_INVIERTO.Model;
using System;
using System.Collections.Generic;

namespace DONDE_INVIERTO.ANTLR
{
    public class MinimizarDeuda : ITipoCondicion
    {
        public TipoCondicion Tipo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Analizar(Empresa empresa, List<ComponenteOperando> componentesOperandos)
        {
            throw new NotImplementedException();
        }
    }
}