using System.ComponentModel.DataAnnotations;

namespace DONDE_INVIERTO.Model
{
    public class Cuenta : Model
    {

        [Required]
        public string Nombre { get; set; }

        [Required]
        public decimal Valor { get; set; }


    }
}
