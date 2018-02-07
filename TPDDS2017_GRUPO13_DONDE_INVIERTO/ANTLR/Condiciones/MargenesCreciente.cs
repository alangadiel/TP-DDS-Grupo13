using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using System.Collections.Generic;
using System.Linq;

namespace DONDE_INVIERTO.ANTLR
{
    public class MargenesCreciente : ITipoCondicion
    {
        public TipoCondicion Tipo { get; set; }
        public Indicador Indicador { get; set; }

        public bool Analizar(EmpresaView empresa, List<Indicador> indicadores)
        {
            bool result = true;
            List<int> periodos = empresa.Balances.Select(x => x.Periodo).OrderBy(x => x).ToList();
            int i = 0;
            var core = new IndicadorCore(Indicador);
            while (i < periodos.Count - 1 && result)
            {
                result = core.ObtenerValor(empresa, periodos[i], indicadores) < core.ObtenerValor(empresa, periodos[i + 1], indicadores);
                i++;
            }
            return result;
        }

        public bool Analizar(EmpresaView empresa1, EmpresaView empresa2, List<Indicador> indicadores)
        {
            return true; //no hay criterio de descarte, solo de ordenamiento
        }
    }
}