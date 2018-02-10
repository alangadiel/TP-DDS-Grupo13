using DONDE_INVIERTO.DataStorage;
using DONDE_INVIERTO.Model;
using System.Collections.Generic;


namespace DONDE_INVIERTO.Service
{
    public class EmpresaService
    {
        public IList<Empresa> List()
        {
            return Context.ReadAll<Empresa>();
        }

        public void Save(Empresa empresa)
        {
             Context.Session.Save(empresa);
        }

        public void Delete(Empresa empresa)
        {
            Context.Delete(empresa);
        }

        public Empresa Get(Empresa empresa)
        {
            return Context.Get(empresa);
        }
    }
}
