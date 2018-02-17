using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using System;
using System.Collections.Generic;

namespace DONDE_INVIERTO.Service
{
    public class ComponenteService
    {
        public ComponenteOperando Componente { get; set; }

        public double ObtenerValor(EmpresaView empresa, int periodo, List<ComponenteOperando> listaOperandos)
        {
            if (Componente.Formula != null)
                return (new IndicadorService()).ObtenerValor(Componente, empresa, periodo, listaOperandos);

            else return (new CuentaService()).ObtenerValor(Componente, empresa, periodo, listaOperandos);
        }
    }
}
