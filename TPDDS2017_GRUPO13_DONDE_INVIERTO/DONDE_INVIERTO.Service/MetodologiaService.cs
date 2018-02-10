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

        public bool EsMejorParaInvertir(EmpresaView emp1, EmpresaView emp2, List<ComponenteOperando> lista)
        {
            return this.Condiciones.All(x => x.Analizar(emp1, emp2, lista));
        }

        public List<EmpresaView> ObtenerEmpresasDeseables(List<EmpresaView> empresas, List<ComponenteOperando> lista)
        {
            return empresas.Where(x => this.EsDeseableInvertir(x, lista)).ToList();
        }

        public List<EmpresaView> OrdenarEmpresas(List<EmpresaView> empresas, List<ComponenteOperando> lista)
        {
            empresas.Sort((emp1, emp2) => EsMejorParaInvertir(emp1, emp2, lista) ? 1 : 0 );
            return empresas;
        }
    }
}
