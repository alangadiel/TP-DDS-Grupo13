using DONDE_INVIERTO.Model;
using System.Collections.Generic;

namespace DONDE_INVIERTO.ANTLR
{
    public abstract class ComponenteOperando
    {
        public int Id { get; set; }
        public int? IndicadorPadre_Id { get; set; }
        public string Nombre { get; set; }
        public abstract double ObtenerValor(Empresa empresa, int periodo, List<ComponenteOperando> listaOperandos);
    }
}