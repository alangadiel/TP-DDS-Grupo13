using DONDE_INVIERTO.Model;
using System.Collections.Generic;
using System.Linq;

namespace DONDE_INVIERTO.ANTLR
{
   public abstract class Cond
    {
        public Cond()
        {

        }
        public Cond(string descripcion,int indicador_id)
        {
            this.Descripcion = descripcion;
            this.Indicador_Id = indicador_id;
        }
        public int Id { get; set; }
        public virtual Indicador Indicador { get;set; }
        public TipoCondicion Tipo { get; set; }
        public int? Indicador_Id { get; set; }
        public string Descripcion { get; set; }
        //Cada condicion será una clase, que tiene que implementar su metodo "ANALIZAR"
        public abstract bool Analizar(Empresa empresa, List<ComponenteOperando> lista);
        protected List<int> ObtenerPeriodosAConsultar(Empresa emp)
        {
            return emp.Balances.Select(x => x.Periodo).OrderBy(x=>x).ToList();
        }
    }
}
