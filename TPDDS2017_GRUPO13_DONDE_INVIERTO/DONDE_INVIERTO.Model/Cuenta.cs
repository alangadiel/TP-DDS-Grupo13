using System.ComponentModel.DataAnnotations;

namespace DONDE_INVIERTO.Model
{
    public class Cuenta : Model
    {

        [Required]
        public virtual string Nombre { get; set; }

        [Required]
        public virtual Empresa Empresa { get; set; }


    }
}
