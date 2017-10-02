using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DONDE_INVIERTO.Model
{
    public class Empresa : Model
    {
        [Required]
        public virtual string Nombre { get; set; }

        public virtual DateTime Fecha_Creacion { get; set; }

        public virtual List<Periodo> Periodos { get; set; }
    }
}
