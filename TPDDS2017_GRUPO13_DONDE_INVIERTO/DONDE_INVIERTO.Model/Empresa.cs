using System;
using System.Collections.Generic;
using System.Text;

namespace DONDE_INVIERTO.Model
{
    public class Empresa
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public List<Periodo> Periodos { get; set; }
    }
}
