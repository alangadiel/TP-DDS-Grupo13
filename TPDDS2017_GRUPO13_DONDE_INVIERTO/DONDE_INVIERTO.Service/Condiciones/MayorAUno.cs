using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using DONDE_INVIERTO.Service;
using System.Collections.Generic;
using System.Linq;

namespace DONDE_INVIERTO.ANTLR
{
    public class MayorAUno : ITipoCondicion
    {
        public TipoCondicion Tipo { get; set; }
        public ComponenteOperando Componente { get; set; }

        public bool Analizar(EmpresaView empresa, List<ComponenteOperando> componentes)
        {
            bool result = true;
            List<int> periodos = empresa.Balances.Select(x => x.Periodo).OrderBy(x => x).ToList();
            int i = 0;
            var service = new ComponenteService() { Componente = Componente };
            while (i < periodos.Count && result)
            {
                result = service.ObtenerValor(empresa, periodos[i], componentes) > 1;
                i++;
            }
            return result;
        }

        public bool Analizar(EmpresaView empresa1, EmpresaView empresa2, List<ComponenteOperando> componentes)
        {
            return true;
        }
    }
}