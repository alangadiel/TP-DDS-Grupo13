using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using System.Collections.Generic;

namespace DONDE_INVIERTO.ANTLR
{
    public class RoeConsistente : ITipoCondicion
    {
        public TipoCondicion Tipo { get; set; }
        public Indicador Indicador { get; set; }

        public bool Analizar(EmpresaView empresa, List<Indicador> indicadores)
        {
            return true;
        }
    }
}