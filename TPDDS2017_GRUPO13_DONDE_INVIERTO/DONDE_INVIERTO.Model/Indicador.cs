using ANTLR.Clases2;
using System.ComponentModel.DataAnnotations;

namespace DONDE_INVIERTO.Model
{
    public class Indicador : Model
    {
        [Required]
        public virtual string Nombre { get; set; }

        public virtual BinaryTree<IContenidoNodo> BinaryTree { get; set; }

        [Required]
        public virtual string Contenido { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
