using DONDE_INVIERTO.DataStorage;
using DONDE_INVIERTO.Model;
using System.Collections.Generic;
using System.Linq;


namespace DONDE_INVIERTO.Service
{
    public class EmpresaService
    {
        public List<Empresa> List()
        {
            return Context.Session.Query<Empresa>().OrderBy(emp => emp.Cuit).ToList();
        }

        public void Save(Empresa empresa)
        {
             Context.Save(empresa);
        }

        public void Delete(int id)
        {
            var empresa = Get(id);
            Context.Delete(empresa);
        }

        public Empresa Get(int id)
        {
            return Context.Session.Query<Empresa>().
                Where(emp => emp.Id == id).First();
        }
    }
}
