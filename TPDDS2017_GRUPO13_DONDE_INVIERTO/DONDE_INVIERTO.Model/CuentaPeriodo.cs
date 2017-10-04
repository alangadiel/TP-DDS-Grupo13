using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DONDE_INVIERTO.Model
{
    public class CuentaPeriodo
    {
        public virtual IList<Periodo> Periodo { get; set; }

        public virtual IList<Cuenta> Cuenta { get; set; }
    }
}
