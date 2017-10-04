using System;
using System.Collections.Generic;
using System.Text;

namespace DONDE_INVIERTO.Model
{
    public class Periodo : Model
    {
        public virtual DateTime Anio { get; set; }

        public virtual int Semestre { get; set; }
    }
}
