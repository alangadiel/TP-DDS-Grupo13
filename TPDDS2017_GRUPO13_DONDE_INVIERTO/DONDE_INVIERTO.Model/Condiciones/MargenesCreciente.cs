using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DONDE_INVIERTO.Model
{
    public class MargenesCreciente : Condicion
    {
        public MargenesCreciente()
        {
        }

        public MargenesCreciente(string descripcion,int indicador_id) :base(descripcion,indicador_id)
        {

        }
        public override bool Analizar(Empresa empresa ,List<ComponenteOperando> lista)
        {
            bool result = true;
            List<int> periodos = this.ObtenerPeriodosAConsultar(empresa);
            int i=0;        
            while(i<periodos.Count-1 && result)
            {
                result= this.Indicador.ObtenerValor(empresa, periodos[i], lista) < this.Indicador.ObtenerValor(empresa, periodos[i+1], lista);
                i++;
            }
            return result;
        }
    }
}