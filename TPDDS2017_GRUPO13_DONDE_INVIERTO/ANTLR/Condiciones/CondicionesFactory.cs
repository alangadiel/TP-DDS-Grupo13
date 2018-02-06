using DONDE_INVIERTO.Model;
using System.Collections.Generic;

namespace DONDE_INVIERTO.ANTLR
{
    public static class CondicionesFactory
    {
        private static List<ITipoCondicion> tiposCondicion =
            new List<ITipoCondicion>()
            {
                new Longevidad(),
                new MargenesCreciente(),
                new MayorAUno(),
                new MinimizarDeuda(),
                new RoeConsistente()
            };

        public static ITipoCondicion FindCondicion(TipoCondicion tipoCondicion)
        {
            return tiposCondicion.Find(tcond => tcond.Tipo.Equals(tipoCondicion));
        }
    }
}