using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using DONDE_INVIERTO.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DONDE_INVIERTO.ANTLR
{
    public class MinimizarDeuda : ITipoCondicion
    {
        public TipoCondicion Tipo { get; set; }
        public ComponenteOperando Componente { get; set; }

        public bool Analizar(EmpresaView empresa, List<ComponenteOperando> componentes)
        {
            return true;
        }

        public bool Analizar(EmpresaView empresa1, EmpresaView empresa2, List<ComponenteOperando> componentes)
        {
            int periodoActual = DateTime.Now.Year;
            var service = new ComponenteService() { Componente = Componente };
            return service.ObtenerValor(empresa1, periodoActual, componentes) > service.ObtenerValor(empresa2, periodoActual, componentes);
            //ponemos el signo > y no < para que lo ordene de forma ascendente
        }
    }
}