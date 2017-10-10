using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DONDE_INVIERTO.Model
{
    public class Metodologia : Model
    {
        [Required]
        public virtual string Nombre { get; set; }

        public virtual IList<Condicion> Condicion { get; set; }

        public virtual Indicador Indicador { get; set; }
    }
}
