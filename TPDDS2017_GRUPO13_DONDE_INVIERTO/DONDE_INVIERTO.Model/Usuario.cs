using System;
using System.ComponentModel.DataAnnotations;

namespace DONDE_INVIERTO.Model
{
    public class Usuario : Model
    {
        [Required]
        public virtual string UserName { get; set; }

        [Required]
        public virtual string Contrasenia { get; set; }

        public virtual string Nombre { get; set; }

        public virtual string Apellido { get; set; }

        public virtual DateTime FechaAlta { get; set; }

    }
}
