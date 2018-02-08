using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DONDE_INVIERTO.Model.Condiciones
{
    public class RoeConsistente : Condicion
    {
        public RoeConsistente()
        {
        }

        public RoeConsistente(string descripcion, int indicador_id): base(descripcion,indicador_id)
        {

        }
        public override bool Analizar(Empresa empresa, List<ComponenteOperando> lista)
        {
            throw new NotImplementedException();
        }
    }
}