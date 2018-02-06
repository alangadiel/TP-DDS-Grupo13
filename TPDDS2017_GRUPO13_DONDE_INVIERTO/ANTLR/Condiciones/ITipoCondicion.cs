using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using System.Collections.Generic;

namespace DONDE_INVIERTO.ANTLR
{
    public interface ITipoCondicion
    {
        TipoCondicion Tipo { get; set; }

        Indicador Indicador { get; set; }

        bool Analizar(EmpresaView empresa, List<Indicador> indicadores);
    }
}
