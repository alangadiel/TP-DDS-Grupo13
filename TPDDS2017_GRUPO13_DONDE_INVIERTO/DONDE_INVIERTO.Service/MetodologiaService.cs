using DONDE_INVIERTO.ANTLR;
using DONDE_INVIERTO.DataStorage;
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

        public List<MetodologiaView> GetAll()
        {
            var metodologiaViewList = new List<MetodologiaView>();
            var metodologias = Context.Session.Query<Metodologia>().ToList();
            metodologias.ForEach(metodologia =>
            {
                var condiciones = Context.Session.Query<MetodologiaCondicion>()
                    .Where(mc=>mc.MetodologiaId==metodologia.Id)
                    .Join(Context.Session.Query<Condicion>(),
                        mc => mc.CondicionId,
                        c => c.Id,
                        (mc, c) => c)
                    .ToList();
                metodologiaViewList.Add(new MetodologiaView()
                {
                    Id = metodologia.Id,
                    Nombre = metodologia.Nombre,
                    Condiciones = condiciones
                });
            });
            return metodologiaViewList;
        }

        public MetodologiaView GetById(int id)
        {
            return GetAll().Where(met => met.Id == id).FirstOrDefault();
        }

        public void Save(Metodologia metodologia, List<int> condicionesIds)
        {
            Context.Save(metodologia);
            foreach(var id in condicionesIds)
                Context.Save(new MetodologiaCondicion() { MetodologiaId = metodologia.Id, CondicionId = id });
        }

        public void Delete(int metodologiaId)
        {
            var metodologia = Context.Session.Query<Metodologia>().Where(met => met.Id == metodologiaId).First();
            var metodologiasCondiciones = Context.Session.Query<MetodologiaCondicion>().Where(mc => mc.MetodologiaId == metodologia.Id).ToList();
            Context.Delete<MetodologiaCondicion>(metodologiasCondiciones);
            Context.Delete(metodologia);
        }
    }
}
