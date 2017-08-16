using System;
using System.Collections.Generic;
using System.Text;

namespace DONDE_INVIERTO.Model
{
    public class Periodo : Model
    {
        public DateTime Inicio { get; set; }

        public DateTime Fin { get; set; }

        public Cuenta Cuenta { get; set; }

        public int EmpresaId { get; set; }

        public bool Anual { get; set; }

        public bool Semestral { get; set; }
    }
}
