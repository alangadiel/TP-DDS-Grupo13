using System.ComponentModel.DataAnnotations;

namespace DONDE_INVIERTO.Model
{
    public class Usuario : Model
    {
        [Required]
        public virtual string Nombre { get; set; }

        public virtual string Contrasenia { get; set; }

    }
}
