using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DONDE_INVIERTO.ANTLR
{
    public class MinimizarDeuda : ITipoCondicion
    {
        public TipoCondicion Tipo { get; set; }
        public Indicador Indicador { get; set; }

        public bool Analizar(EmpresaView empresa, List<Indicador> indicadores)
        {
            return true;
        }

        public bool Analizar(EmpresaView empresa1, EmpresaView empresa2, List<Indicador> indicadores)
        {
            int periodoActual = DateTime.Now.Year;
            var core = new IndicadorCore(Indicador);
            return core.ObtenerValor(empresa1, periodoActual, indicadores) < core.ObtenerValor(empresa2, periodoActual, indicadores);
        }
    }
}