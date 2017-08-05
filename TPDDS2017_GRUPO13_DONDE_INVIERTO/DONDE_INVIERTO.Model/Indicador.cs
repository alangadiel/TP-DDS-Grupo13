using ANTLR.Clases2;
using System.ComponentModel.DataAnnotations;

namespace DONDE_INVIERTO.Model
{
    public class Indicador : Model
    {
        [Required]
        public string Nombre { get; set; }

        public BinaryTree<IContenidoNodo> BinaryTree { get; set; }

        [Required]
        public string Contenido { get; set; }
    }
}
