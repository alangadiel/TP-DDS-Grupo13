using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using System.Collections.Generic;
using System.Linq;

namespace DONDE_INVIERTO.ANTLR
{
    public class MargenesCreciente : ITipoCondicion
    {
        public TipoCondicion Tipo { get; set; }
        public ComponenteOperando Componente { get; set; }

        public bool Analizar(EmpresaView empresa, List<ComponenteOperando> componentes)
        {
            bool result = true;
            List<int> periodos = empresa.Balances.Select(x => x.Periodo).OrderBy(x => x).ToList();
            int i = 0;
            var core = new IndicadorCore(Componente);
            while (i < periodos.Count - 1 && result)
            {
                result = core.ObtenerValor(empresa, periodos[i], componentes) < core.ObtenerValor(empresa, periodos[i + 1], componentes);
                i++;
            }
            return result;
        }

        public bool Analizar(EmpresaView empresa1, EmpresaView empresa2, List<ComponenteOperando> componentes)
        {
            return true; //no hay criterio de descarte, solo de ordenamiento
        }
    }
}