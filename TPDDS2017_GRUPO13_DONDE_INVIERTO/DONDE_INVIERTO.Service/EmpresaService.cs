using DONDE_INVIERTO.Model;
using System.Collections.Generic;
using System.Linq;


namespace DONDE_INVIERTO.Service
{
    public class EmpresaService
    {
        private Entity.Empresa Entity;

        public EmpresaService()
        {
            Entity = new DONDE_INVIERTO.Entity.Empresa();
        }

        public IEnumerable<Empresa> List()
        {
            return Entity.GetAll();
        }
    }
}
