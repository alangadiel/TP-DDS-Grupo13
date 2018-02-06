using DONDE_INVIERTO.ANTLR;
using DONDE_INVIERTO.Model;
using System.Collections.Generic;

namespace ANTLR.Condiciones
{
    public interface ITipoCondicion
    {
        TipoCondicion Tipo { get; set; }
        DONDE_INVIERTO.Model.Indicador Indicador { get; set; }
        bool Analizar(Empresa empresa, List<ComponenteOperando> componentesOperandos);
    }
}
