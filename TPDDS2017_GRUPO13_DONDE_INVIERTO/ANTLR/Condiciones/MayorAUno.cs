using ANTLR.Condiciones;
using DONDE_INVIERTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DONDE_INVIERTO.ANTLR
{
    public class MayorAUno : ITipoCondicion
    {
        public TipoCondicion Tipo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Indicador Indicador { get; set; }

        public bool Analizar(Empresa empresa, List<ComponenteOperando> componentesOperandos)
        {
            bool result = true;
            List<int> periodos = this.ObtenerPeriodosAConsultar(empresa);
            int i = 0;
            while (i < periodos.Count && result)
            {
                result = this.Indicador.ObtenerValor(empresa, i, lista) > 1;
                i++;
            }
            return result;
        }
    }
}