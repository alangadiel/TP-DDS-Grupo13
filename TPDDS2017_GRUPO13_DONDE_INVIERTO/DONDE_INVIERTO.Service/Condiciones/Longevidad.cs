using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using System;
using System.Collections.Generic;

namespace DONDE_INVIERTO.ANTLR
{
    public class Longevidad : ITipoCondicion
    {
        public TipoCondicion Tipo { get; set; }
        public ComponenteOperando Componente { get; set; }

+
        public bool Analizar(EmpresaView empresa, List<ComponenteOperando> componentes)
        {
            return empresa.FechaFundacion <= DateTime.Now.AddYears(-10);
        }

        public bool Analizar(EmpresaView empresa1, EmpresaView empresa2, List<ComponenteOperando> componentes)
        {
            return empresa1.FechaFundacion > empresa2.FechaFundacion;

        }
    }
}