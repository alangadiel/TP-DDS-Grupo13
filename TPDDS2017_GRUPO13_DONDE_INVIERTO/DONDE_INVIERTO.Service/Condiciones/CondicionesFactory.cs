using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Service;
using System.Collections.Generic;

namespace DONDE_INVIERTO.ANTLR
{
    public static class CondicionesFactory
    {
        private static List<ITipoCondicion> tiposCondicion =
            new List<ITipoCondicion>()
            {
                new Longevidad() { Tipo = TipoCondicionService.GetAll().Find(cond => cond.Id == 1) },
                new MargenesCreciente() { Tipo = TipoCondicionService.GetAll().Find(cond => cond.Id == 2) },
                new MayorAUno() { Tipo = TipoCondicionService.GetAll().Find(cond => cond.Id == 3) },
                new MinimizarDeuda() { Tipo = TipoCondicionService.GetAll().Find(cond => cond.Id == 4) },
                new RoeConsistente() { Tipo = TipoCondicionService.GetAll().Find(cond => cond.Id == 5) },
            };

        public static ITipoCondicion FindCondicion(TipoCondicion tipoCondicion)
        {
            return tiposCondicion.Find(tcond => tcond.Tipo.Equals(tipoCondicion));
        }
    }
}