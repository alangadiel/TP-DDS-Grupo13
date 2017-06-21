using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DONDE_INVIERTO.Service
{
    public class PeriodoService
    {
        public void Save(Model.Periodo periodo)
        {
            Entity.Periodo.Instance.Save(periodo);
        }
    }
}
