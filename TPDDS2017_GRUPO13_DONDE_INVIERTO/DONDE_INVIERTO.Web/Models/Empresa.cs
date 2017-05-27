using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DONDE_INVIERTO.Web.Models
{
    public class Empresa
    {
        public string nombre { get; set; }
        public List<Periodo> periodos { get; set; }
    }
}