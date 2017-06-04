using System;
using System.Collections.Generic;
using System.Text;

namespace DONDE_INVIERTO.Model
{
    public class Periodo
    {
        public DateTime Inicio { get; set; }

        public DateTime Fin { get; set; }

        public List<Cuenta> Cuentas { get; set; }
    }
}
