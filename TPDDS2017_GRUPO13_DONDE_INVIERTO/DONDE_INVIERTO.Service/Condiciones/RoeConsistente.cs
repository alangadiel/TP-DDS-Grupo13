using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using System.Collections.Generic;
using System.Linq;

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

        public bool Analizar(EmpresaView empresa1, EmpresaView empresa2, List<Indicador> indicadores)
        {
            bool result = true;
            List<int> periodos1 = empresa1.Balances.Select(x => x.Periodo).OrderBy(x => x).ToList();
            List<int> periodos2 = empresa2.Balances.Select(x => x.Periodo).OrderBy(x => x).ToList();

            int i = 0;
            var core = new IndicadorCore(Indicador);
            while (i < periodos1.Count && i < periodos2.Count && result)
            {
                result = core.ObtenerValor(empresa1, periodos1[i], indicadores) > core.ObtenerValor(empresa2, periodos2[i], indicadores);
                i++;
            }
            return result;
        }
    }
}