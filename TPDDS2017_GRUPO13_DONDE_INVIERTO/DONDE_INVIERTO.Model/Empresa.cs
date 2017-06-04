using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DONDE_INVIERTO.Model
{
    public class Empresa : Model
    {

        [Required]
        public string Nombre { get; set; }

        public List<Periodo> Periodos { get; set; }
    }
}
