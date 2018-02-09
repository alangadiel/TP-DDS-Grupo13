using DONDE_INVIERTO.ANTLR;
using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DONDE_INVIERTO.Service
{
    public class MetodologiaService
    {
        public virtual List<ITipoCondicion> Condiciones { get; set; }

        public bool EsDeseableInvertir(EmpresaView emp, List<ComponenteOperando> lista)
        {
            //Me fijo que se cumplan todas las condiciones de esta metodologia
            return this.Condiciones.All(x => x.Analizar(emp, lista));
        }

        public List<Empresa> ObtenerEmpresasDeseables(List<Empresa> empresas, List<ComponenteOperando> lista)
        {
            List<Empresa> deseables = new List<Empresa>();
            deseables = empresas.Where(x => this.EsDeseableInvertir(x, lista)).ToList();
            return deseables;
        }
    }
}
