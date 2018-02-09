using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DONDE_INVIERTO.Model
{
    public class Metodologia
    {
        public Metodologia()
        {
            this.Condiciones = new List<Condicion>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual List<Condicion> Condiciones { get; set; }

        public bool EsDeseableInvertir(Empresa emp, List<ComponenteOperando> lista)
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