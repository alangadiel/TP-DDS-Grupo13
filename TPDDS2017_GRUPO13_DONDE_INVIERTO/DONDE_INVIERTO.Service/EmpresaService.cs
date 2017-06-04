using DONDE_INVIERTO.Model;
using System.Collections.Generic;
using System.Linq;


namespace DONDE_INVIERTO.Service
{
    public class EmpresaService
    {

        public EmpresaService()
        {
           
        }

        public IEnumerable<Empresa> List()
        {
            return Entity.Empresa.Instance.GetAll();
        }

        public void Save(Empresa empresa)
        {
            Entity.Empresa.Instance.Save(empresa);
        }

        public void Delete(int Id)
        {
            Entity.Empresa.Instance.Delete(Id);
        }

        public Empresa Get(int Id)
        {
            return Entity.Empresa.Instance.Get(Id);
        }
    }
}
