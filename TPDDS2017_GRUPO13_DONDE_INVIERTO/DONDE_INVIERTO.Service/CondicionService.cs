using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.DataStorage;
using DONDE_INVIERTO.Model.Views;
using DONDE_INVIERTO.ANTLR;

namespace DONDE_INVIERTO.Service
{
    public class CondicionService
    {
        public List<CondicionView> List()
        {
            var indicadores = Context.Session.Query<ComponenteOperando>();
            var tipos = Context.Session.Query<TipoCondicion>();
            return Context.Session.Query<Condicion>()
                .Select(cond => new CondicionView
                {
                    Id = cond.Id,
                    Descripcion = cond.Descripcion,
                    Tipo = tipos.FirstOrDefault(tipo => tipo.Id == cond.TipoCondicionId),
                    Indicador = indicadores.FirstOrDefault(ind => ind.Id == cond.IndicadorId)
                }).ToList();
        }

        public void Save(CondicionView vista)
        {
            Context.Save(new Condicion
            {
                Id = vista.Id,
                Descripcion = vista.Descripcion,
                IndicadorId = vista.Indicador.Id,
                TipoCondicionId = vista.Tipo.Id,
            });
        }

        public void Delete(int id)
        {
            Context.Delete(Get(id));
        }

        public Condicion Get(int id)
        {
            return Context.Session.Query<Condicion>().
                Where(x => x.Id == id).First();
        }

        public List<ITipoCondicion> GetTiposCondicionByMetodologia(MetodologiaView metodologia)
        {
            var listTipoCond = new List<ITipoCondicion>();
            var tiposCond = Context.Session.Query<MetodologiaCondicion>()
                .Join(Context.Session.Query<Condicion>(),
                    mc => mc.CondicionId,
                    c => c.Id,
                    (mc, c) => new { mc, c })
                .Join(Context.Session.Query<TipoCondicion>(),
                    mc => mc.c.TipoCondicionId,
                    tc => tc.Id,
                    (mc, tc) => new { MetodologiaCondicion = mc.mc, Condicion = mc.c, TipoCondicion = tc })
                .Where(cond => cond.MetodologiaCondicion.MetodologiaId == metodologia.Id)
                .Select(cond => cond.TipoCondicion)
                .ToList();
            tiposCond.ForEach(tc =>
            {
                listTipoCond.Add(CondicionesFactory.FindCondicion(tc));
            });
            return listTipoCond.Distinct().ToList();
        }
    }
}
