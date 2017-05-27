using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DONDE_INVIERTO.Web.Models
{
    public class Periodo
    {
        public DateTime fechaInicio { get; set; }

        public DateTime fechaFin { get; set; }

        public List<Cuenta> cuentas { get; set; }
    }
}