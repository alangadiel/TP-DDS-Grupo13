using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using DONDE_INVIERTO.Service;
using System.Collections.Generic;
using System.Linq;

namespace DONDE_INVIERTO.ANTLR
{
    public class RoeConsistente : ITipoCondicion
    {
        public TipoCondicion Tipo { get; set; }
        public ComponenteOperando Componente { get; set; }

        public bool Analizar(EmpresaView empresa, List<ComponenteOperando> componentes)
        {
            return true;
        }

        public bool Analizar(EmpresaView empresa1, EmpresaView empresa2, List<ComponenteOperando> componentes)
        {
            bool result = true;
            List<int> periodos1 = empresa1.Balances.Select(x => x.Periodo).OrderBy(x => x).ToList();
            List<int> periodos2 = empresa2.Balances.Select(x => x.Periodo).OrderBy(x => x).ToList();

            int i = 0;
            var service = new ComponenteService() { Componente = Componente };
            while (i < periodos1.Count && i < periodos2.Count && result)
            {
                result = service.ObtenerValor(empresa1, periodos1[i], componentes) > service.ObtenerValor(empresa2, periodos2[i], componentes);
                i++;
            }
            return result;
        }
    }
}