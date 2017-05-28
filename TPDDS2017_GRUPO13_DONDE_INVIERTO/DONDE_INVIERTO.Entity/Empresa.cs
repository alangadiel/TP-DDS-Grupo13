using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DONDE_INVIERTO.Model;

namespace DONDE_INVIERTO.Entity
{
    public class Empresa
    {
        List<Model.Empresa> Empresas;

        public Empresa()
        {
            Empresas = new List<Model.Empresa>();
            Model.Empresa emp1 = new Model.Empresa { Id = 1, Nombre = "Nombre Empresa 1" };
            Model.Empresa emp2 = new Model.Empresa { Id = 2, Nombre = "Nombre Empresa 2" };
            Empresas.Add(emp1);
            Empresas.Add(emp2);
        }

        public IEnumerable<Model.Empresa> GetAll()
        {
            return Empresas;
        }

    }
}
